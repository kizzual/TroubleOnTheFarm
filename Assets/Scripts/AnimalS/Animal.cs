using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour, IMoveAnimal
{
    public enum AnimalType
    {
        Goose,
        Goat,
        Ostrich,
        Pig,
        Cow,
        Horse,
        Sheep,
        Chicken
    }
    public AnimalType animalType;
    public enum State
    {
        start,
        stay,
        walk,
        rotate,
        run
    }
    public State state;

    [SerializeField] private AnimalSettings animalSettings;
    
    [Header("Main Stats")]
    private float run_speed;
    private float min_Time_ToStay, max_Time_To_Stay;
    private float timeToMove;
    private float timer;
    private float walkingTimer;
    private int priority;
    private Vector3 random_point;
    private Vector3 targetToRotate;
    private bool isFearing = false;
    [HideInInspector] public bool inSide;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private AnimationCurve speed_Curve;
    [HideInInspector] public float radius_walk_zone;

    [Header("GameObjects")]
    [SerializeField] private Transform zone_to_run;
     public Transform zone_to_walk;
    private Animation_animal _animation;


    [Header("Temporary settings")]  //вынести после настройки в скриптабл обж
    public float patrol_Sphere_Raduis;
    public float fear_Sphere_Raduis;

    [Header("NavMesh")]
    private NavMeshPath nav_mesh_path;
    private  NavMeshAgent agent;
    private NavMeshHit hit;

    private float distMax;
    private float distCur;
    private Quaternion rotation;
    private Vector3 axis;

    [HideInInspector] public bool canFear = true;
    private void Start()
    {
        Initialize();
        Find_First_Point();
    }
    private void Update()
    {
        ActionByState();
    }
    private void Initialize()
    {
        state = State.start;
        _animation = GetComponent<Animation_animal>();
        run_speed = animalSettings.run_speed;
        min_Time_ToStay = animalSettings.min_Time_ToStay;
        max_Time_To_Stay = animalSettings.max_Time_To_Stay;
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = priority;
        nav_mesh_path = new NavMeshPath();


    }
    private void ActionByState()
    {
        if (state == State.stay)
        {
            timer += Time.deltaTime;

            if (timer > timeToMove)
            {
                timer = 0;
                Patroling_In_Main_zone();
            }
        }
        else if (state == State.walk)
        {
            walkingTimer += Time.deltaTime;

            distCur = CheckDistance(transform.position, random_point);
            agent.speed = ChangeSpeedByAnimationCurve(distCur, distMax);

            if (CheckDistance(transform.position, random_point) < 0.01 || walkingTimer > 20)  // Переработать время
            {
                walkingTimer = 0;
                _animation.Idle_Animation();
                state = State.stay;
            }
        }
        else if (state == State.run)
        {
            walkingTimer += Time.deltaTime;

            agent.speed = run_speed;
            if (CheckDistance(transform.position, random_point) < 0.01 || walkingTimer > 20)  // Переработать время
            {
                walkingTimer = 0;
                _animation.Idle_Animation();
                state = State.stay;
            }
        }
        else if (state == State.rotate)
        {
            timer += Time.deltaTime;

            if(!isFearing)
            {
                RotateAnimal(isFearing);
                if (timer > .3)
                {
                    _animation.Walk_Animation();
                    state = State.walk;
                    agent.SetDestination(random_point);
                    timer = 0;
                }
            }
            else if(isFearing)
            {
                RotateAnimal(isFearing);
                if (timer > .3)
                {
                    _animation.Run_Animation();
                    Fear_run_away();
                    timer = 0;
                }
            }         
        }
    }
    private float ChangeSpeedByAnimationCurve(float currentDistance, float maxDistance)
    {
       return speed_Curve.Evaluate(1 - currentDistance / maxDistance);
    }
    private float CheckDistance(Vector3 mainPosition, Vector3 targetPosition)
    {
        return Vector3.Distance(mainPosition, targetPosition);
    }
    private void RotateAnimal(bool IsFearing)
    {
        if(IsFearing)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(axis), rotateSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed);
        }
    }
    public void FearingAnimal(Transform point)
    {
        if (canFear)
        {
            ResetAgentDestination();
            Vector3 targetPos = point.position;
            targetPos.y = transform.position.y;
            axis = transform.position - targetPos;
            Vector3 targetDir = targetPos - transform.position;

            float angleBetween = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);
            if (Mathf.Abs(angleBetween) > 165)
            {
                Fear_run_away();
            }
            else
            {
                isFearing = true;
                state = State.rotate;
            }
        }
    }
    public void Fear_run_away()
    {
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);

        random_point = zone_to_run.position;

        distMax = CheckDistance(transform.position, random_point);

        agent.SetDestination(random_point);
        state = State.run;
        isFearing = false;

    }
    public void Find_First_Point()
    {
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);
        int check = 0;

        bool get_correct_point = false;
        while (!get_correct_point || check < 100)
        {
            check++;
            NavMeshHit navMesh_hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * radius_walk_zone + zone_to_walk.position, out navMesh_hit, radius_walk_zone + 1, NavMesh.AllAreas);
            random_point = navMesh_hit.position;

            agent.CalculatePath(random_point, nav_mesh_path);

            if (nav_mesh_path.status == NavMeshPathStatus.PathComplete)
            {
                get_correct_point = true;
            }
        }

        targetToRotate = random_point - transform.position;
        rotation = Quaternion.LookRotation(targetToRotate);

        distMax = CheckDistance(transform.position, random_point);
        state = State.rotate;
        if (check >= 100)
        {
        }
    }
    public void Patroling_In_Main_zone()
    {
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);

        int check = 0;
        bool get_correct_point = false;
        while (!get_correct_point || check < 100)
        {
            check++;
            NavMeshHit navMesh_hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * patrol_Sphere_Raduis + transform.position, out navMesh_hit, patrol_Sphere_Raduis + 1, NavMesh.AllAreas);
            random_point = navMesh_hit.position;

            agent.CalculatePath(random_point, nav_mesh_path); 

            if (nav_mesh_path.status == NavMeshPathStatus.PathComplete)
            {
                get_correct_point = true;
            }
            
        }
        if (get_correct_point)
        {
            distMax = CheckDistance(transform.position, random_point);
            targetToRotate = random_point - transform.position;
            rotation = Quaternion.LookRotation(targetToRotate);

            state = State.rotate;
        }
        if (check >= 100)
        {
        }
    }
    private void OnDrawGizmos()
    {
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, patrol_Sphere_Raduis);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(zone_to_run.position, fear_Sphere_Raduis);
        Gizmos.color = Color.red;
        Gizmos.DrawLine (transform.position, random_point);
    }
    public void SetPriority(int value)
    {
        priority = value;
    }
    public void ResetAgentDestination()
    {
        agent.ResetPath();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            ResetAgentDestination();
            _animation.Idle_Animation();
            state = State.stay;
        }
    }
}
