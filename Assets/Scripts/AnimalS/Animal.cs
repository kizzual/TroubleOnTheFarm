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

    public int Weight;
    public enum State
    {
        start,
        stay,
        walk,
        rotate,
        run,
        runToEat,
        rotateToEat,
        eating
    }
    public State state;

    [SerializeField] private AnimalSettings animalSettings;
    
    [Header("Main Stats")]
    private float run_speed;
    private float min_Time_ToStay, max_Time_To_Stay;
    private float timeToMove;
    private float timer ;
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
    private Vector3 startPos;

    public bool eating;
    private Feed_buster feed;
    private Vector3 eatPos; 

    public bool active = false;
    [HideInInspector] public bool canFear = true;
    private void Start()
    {
        Initialize();
        startPos = transform.position;
    //    Find_First_Point();
    }
    private void Update()
    {
        ActionByState();
    }
    private void Initialize()
    {
     //   state = State.start;
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
        else if( state == State.runToEat)
        {
            walkingTimer += Time.deltaTime;
            Debug.Log(CheckDistance(transform.position, eatPos));
            if (CheckDistance(transform.position, eatPos) < .5 || walkingTimer > 10)  // Переработать время
            {
                _animation.Idle_Animation();
                state = State.rotateToEat;
                timer = 0;
                walkingTimer = 0;
            }
            
        }
        else if (state == State.run)
        {
            walkingTimer += Time.deltaTime;
            timer += Time.deltaTime;
            agent.speed = run_speed;

            if(eating)
            {
                if (CheckDistance(transform.position, random_point) < 0.3 || walkingTimer > 20)  // Переработать время
                {
                    RotateToEat(true);
                }
            }
            else if(!eating)
            {
                if (CheckDistance(transform.position, random_point) < 0.1 || walkingTimer > 20)  // Переработать время
                {
                    walkingTimer = 0;
                    _animation.Idle_Animation();
                    state = State.stay;
                }
            }         
        }
        else if (state == State.rotate)
        {
            timer += Time.deltaTime;

            if(!isFearing && !eating)
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
            if(eating)
            {
                RotateAnimal(false);

                if (timer > .5)
                {
                    timer = 0;
                    _animation.Run_Animation(); //анимация еды

                    agent.SetDestination(eatPos);
                    state = State.runToEat;

                }
            }
        }
        else if (state == State.eating)
        {
            Debug.Log("EATING");
        }
        else if (state == State.rotateToEat)
        {
            RotateToEat(false);
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
    /*    NavMeshHit navMesh_hit;
        NavMesh.SamplePosition(Random.insideUnitSphere * radius_walk_zone + zone_to_walk.position, out navMesh_hit, radius_walk_zone + 1, NavMesh.AllAreas);
        random_point = navMesh_hit.position;*/

        targetToRotate = random_point - transform.position;
        rotation = Quaternion.LookRotation(targetToRotate);

        distMax = CheckDistance(transform.position, random_point);
        state = State.rotate;
        if (check >= 100)
        {
        }
    }
    private void RotateToEat(bool fromFear)
    {
        if(fromFear)
        {
            _animation.Idle_Animation();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(eatPos - transform.position), rotateSpeed);
            if (timer > 3)
            {
                timer = 0;
                agent.SetDestination(eatPos);
                state = State.runToEat;
                _animation.Run_Animation();
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(feed.transform.position - transform.position), rotateSpeed);
            if (timer > .3)
            {
                timer = 0;
                _animation.Idle_Animation(); //анимация еды
                state = State.eating;
            }
        }
    }
    public void UsedFeedBuster( Vector3 destination,Feed_buster feedBuster)
    {
        feed = feedBuster;
        eatPos = destination;
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);
        
        _animation.Idle_Animation();
        targetToRotate = random_point - transform.position;
        timer = 0;
        state = State.rotate;

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
        if(other.TryGetComponent(out Animal animal))
        {
            if(active)
            {
                if (Weight >= animal.Weight)
                {
                    animal.FearingAnimal(transform);
                }
                else
                {
                    FearingAnimal(animal.transform);
                }
            }
            
       //     ResetAgentDestination();
      //      _animation.Idle_Animation();
      //      state = State.stay;
        }
    }

    public void ResetAnimal()
    {
        inSide = true;
        state = Animal.State.start;
        ResetAgentDestination();
        agent.enabled = false;
        transform.position = startPos;
        agent.enabled = true;
    }

}
