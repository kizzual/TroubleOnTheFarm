using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dogs_Patroling : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private List<Transform> patroling_zone;
    private int randomPoint;
    [SerializeField] private Animation_animal anim;
    private AudioSource _audio;
    public bool SoundIsOn;
    public enum State
    {
        walk,
        stay, 
        run
    }
    public State state;
    public Vector3 enemyPos;
    private float timer;
    private float WalkTimer;
    private float TimeBetweenPatrol;
    private float runTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation_animal>();
        TimeBetweenPatrol = Random.Range(5, 12);
        _audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(state == State.stay)
        {
            timer += Time.deltaTime;

            if (timer > TimeBetweenPatrol)
            {
                Patroling();
                anim.Walk_Animation();
                timer = 0;
            }
        }
        else if( state == State.walk)
        {
            WalkTimer += Time.deltaTime;
            if (Vector3.Distance(transform.position, patroling_zone[randomPoint].position) < .3 || WalkTimer > 5)
            {
                agent.ResetPath();
                anim.Idle_Animation();
                WalkTimer = 0;
                state = State.stay;
            }
        }
        else if(state == State.run)
        {
            if(Vector3.Distance (transform.position,enemyPos)< .2)
            {
                agent.ResetPath();

                anim.Idle_Animation();
                state = State.stay;
            }
        }
    }
    private void Patroling()
    {
        TimeBetweenPatrol = Random.Range(5, 12);
        agent.speed = 0.5f;
        randomPoint = Random.Range(0, patroling_zone.Count);
        state = State.walk;
        agent.SetDestination(patroling_zone[randomPoint].position);
    }
    public void EnemyComing(Transform pos)
    {
        enemyPos =  new Vector3(pos.position.x,pos.position.y,pos.position.z);
        state = State.run;
        agent.ResetPath();
        agent.speed = 1.3f;
        agent.SetDestination(enemyPos);
        anim.Run_Animation();
        if (SoundIsOn)
        {
            _audio.Play();
        }
    }
}
