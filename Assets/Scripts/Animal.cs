using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour, IMoveAnimal
{
    public enum AnimalType
    {
        Pig,
        Horse
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
    private float walking_speed;
    private float run_speed;
    private float min_Time_ToStay, max_Time_To_Stay;
    private float timeToMove;
    private float timer;
    private float walkingTimer;
    private int priority;
    private Vector3 random_point;

    [SerializeField] private float firstWalk_Sphere_Radius;

    [Header("GameObjects")]
    [SerializeField] private Transform zone_to_run;
    public Transform zone_to_walk;


    [Header("Temporary settings")]  //вынести после настройки в скриптабл обж
    public float patrol_Sphere_Raduis;
    public float fear_Sphere_Raduis;

    [Header("NavMesh")]
    private NavMeshPath nav_mesh_path;
    private NavMeshAgent agent;
    private NavMeshHit hit;


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
        walking_speed = animalSettings.walking_speed;
        run_speed = animalSettings.run_speed;
        min_Time_ToStay = animalSettings.min_Time_ToStay;
        max_Time_To_Stay = animalSettings.max_Time_To_Stay;
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = priority;
        nav_mesh_path = new NavMeshPath();
        

    }
    private void ActionByState()
    {
        if(state == State.stay)
        {
            timer += Time.deltaTime;

            if (timer > timeToMove)
            {
                Patroling_In_Main_zone();
            }
        }
        else if (state == State.walk)
        {
            walkingTimer += Time.deltaTime;

            if (Vector3.Distance(transform.position, random_point) < 0.01 || walkingTimer > 5)
            {
                walkingTimer = 0;
                state = State.stay;
            }      
        }
    }
    public void RotateAnimal(Transform point)
    {
        if (canFear)
        {
            Vector3 targetPos = point.position;
            targetPos.y = transform.position.y;
            Vector3 targetDir = targetPos - transform.position;
            Vector3 forward = transform.forward;
            float angleBetween = Vector3.SignedAngle(targetDir, forward, Vector3.up);
            transform.Rotate(new Vector3(0, 180 - angleBetween, 0));

            // and run
            Fear_run_away();
        }
    }
    public void Fear_run_away()
    {
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);

 //       int check = 0;
        bool forceQuit = false;
        bool get_correct_point = false;
        while (!get_correct_point)// || !forceQuit)
        {
            NavMeshHit navMesh_hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * fear_Sphere_Raduis + zone_to_run.position, out navMesh_hit, fear_Sphere_Raduis + 1, NavMesh.AllAreas);
            random_point = navMesh_hit.position;

            agent.CalculatePath(random_point, nav_mesh_path);

            if (nav_mesh_path.status == NavMeshPathStatus.PathComplete)
            {
                get_correct_point = true;
            }
        //    check++;
        /*    if(check > 30)
            {
                forceQuit = true;
                Debug.Log("forceQuit");
            }*/
        }
        if (get_correct_point)
        {
            agent.speed = run_speed;
            state = State.walk;
            timer = 0;
            agent.SetDestination(random_point);
        }
      /*  else if (forceQuit)
        {
            Find_First_Point();
        }*/
    }
    public void Find_First_Point()
    {
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);

        bool get_correct_point = false;
        while (!get_correct_point)
        {
            NavMeshHit navMesh_hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * firstWalk_Sphere_Radius + zone_to_walk.position, out navMesh_hit, firstWalk_Sphere_Radius + 1, NavMesh.AllAreas);
            random_point = navMesh_hit.position;

            agent.CalculatePath(random_point, nav_mesh_path);

            if (nav_mesh_path.status == NavMeshPathStatus.PathComplete)
            {
                get_correct_point = true;
            }
        }
        transform.LookAt(nav_mesh_path.corners[1]);
        agent.speed = walking_speed;
        state = State.walk;
        timer = 0;
        agent.SetDestination(random_point);
    }
    public void Patroling_In_Main_zone()
    {
        timeToMove = Random.Range(min_Time_ToStay, max_Time_To_Stay + 1);

        int check = 0;
        bool forceQuit = false; 
        bool get_correct_point = false;
        while (!get_correct_point || !forceQuit)
        {
            NavMeshHit navMesh_hit;
            NavMesh.SamplePosition(Random.insideUnitSphere * patrol_Sphere_Raduis + transform.position, out navMesh_hit, patrol_Sphere_Raduis + 1, NavMesh.AllAreas);
            random_point = navMesh_hit.position;

            agent.CalculatePath(random_point, nav_mesh_path);

            if (nav_mesh_path.status == NavMeshPathStatus.PathComplete)
            {
                get_correct_point = true;
            }
            check++;
            if (check > 50)
            {
                forceQuit = true;
            }

        }
        if (get_correct_point)
        {
            transform.LookAt(nav_mesh_path.corners[1]);
            agent.speed = walking_speed;
            state = State.walk;
            timer = 0;
            agent.SetDestination(random_point);
        }
        else if(forceQuit)
        {

            Find_First_Point();
        }
    }
    
    private void OnDrawGizmos()
    {
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, patrol_Sphere_Raduis);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(zone_to_run.position, fear_Sphere_Raduis);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(zone_to_walk.position, firstWalk_Sphere_Radius);
    }
    public void SetPriority(int value)
    {
        priority = value;
    }
}
