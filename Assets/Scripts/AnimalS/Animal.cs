using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
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
    private Transform door_zone_to_walk;

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
     public bool canFear = true;
    float Angle;
    List<RandomPoint> rngPointList;
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
          if (state == State.start)
        {
           /* if (CheckDistance(transform.position, door_zone_to_walk.position) < 0.5)
            {
                if(animalType == AnimalType.Horse)
                    Debug.Log("NextStage");
                agent.speed = 1.3f;
                agent.destination = random_point;
                timer = 0;
                state = State.walk;
            }*/
        }
        else if (state == State.stay)
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
            //  agent.speed = ChangeSpeedByAnimationCurve(distCur, distMax);
            agent.speed = 1.3f;
            if (CheckDistance(transform.position, random_point) < 0.1 || walkingTimer > 2)  // Переработать время
            {
                walkingTimer = 0;
                _animation.Idle_Animation();
                state = State.stay;
            }


        }
        else if (state == State.runToEat)
        {
            walkingTimer += Time.deltaTime;
            if (CheckDistance(transform.position, eatPos) < .2 || walkingTimer > 10)  // Переработать время
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

            if (eating)
            {
                if (CheckDistance(transform.position, random_point) < 0.3 || walkingTimer > 20)  // Переработать время
                {
                    RotateToEat(true);
                }
            }
            else if (!eating)
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

            if (!isFearing && !eating)
            {
                RotateAnimal(isFearing);

                if (timer > 1)
                {
                    _animation.Walk_Animation();
                    state = State.walk;
                    agent.destination = random_point;
                    timer = 0;
                }
            }
            else if (isFearing)
            {
                RotateAnimal(isFearing);
                if (timer > .3)
                {
                    _animation.Run_Animation();
                    Fear_run_away();
                    timer = 0;
                }
            }
            if (eating)
            {
                RotateAnimal(false);

                if (timer > .5)
                {
                    timer = 0;
                    _animation.Run_Animation(); //анимация еды
                    agent.speed = 1.7f;
                    agent.SetDestination(eatPos);
                    state = State.runToEat;

                }
            }
        }
        else if (state == State.eating)
        {
            _animation.Eat_Animation();
        }
        else if (state == State.rotateToEat)
        {
            timer += Time.deltaTime;
            RotateToEat(false);
            if (timer > .3)
            {
                state = State.eating;
                timer = 0;
            }
        }
    }
    public void NewPoint()
    {
        ResetAgentDestination();
        var rng = Random.Range(0, rngPointList.Count - 1);
        random_point = rngPointList[rng].GetRandomPoint();

        distMax = CheckDistance(transform.position, random_point);
        targetToRotate = random_point - transform.position;
        rotation = Quaternion.LookRotation(targetToRotate);
        _animation.Idle_Animation();
        state = State.rotate;

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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Angle, 0), rotateSpeed);
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
            Vector3 direction = targetPos - transform.position;
            Angle = Quaternion.LookRotation(direction, Vector3.up).eulerAngles.y + 180;

            float angleBetween = Vector3.SignedAngle(direction, transform.forward, Vector3.up);

            if (Mathf.Abs(angleBetween) > 165)
            {
                Fear_run_away();
            }
            else
            {
                timer = 0;

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
             /*   NewPoint();
                Debug.Log("S");
*/

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
        state = State.start;
        ResetAgentDestination();
        agent.enabled = false;
        transform.position = startPos;
        agent.enabled = true;
    }

    public void NewPos(List<RandomPoint> rngPoint, Transform doorZone)
    {
        /*        var rngPoint = Random.Range(0, rngPointList.Count -1);
                random_point = rngPointList[rngPoint].GetRandomPoint();
                door_zone_to_walk = doorZone;
                targetToRotate = random_point - transform.position;
                rotation = Quaternion.LookRotation(targetToRotate);
                distMax = CheckDistance(transform.position, random_point);

                agent.destination = door_zone_to_walk.position;
                _animation.Run_Animation();
                state = State.start;
        */


        rngPointList = rngPoint;
        var rng = Random.Range(0, rngPointList.Count - 1);
        random_point = rngPointList[rng].GetRandomPoint();
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);

        ResetAgentDestination();
        agent.enabled = false;
        transform.position = random_point;
        agent.enabled = true;
        state = State.stay;


    }

}
