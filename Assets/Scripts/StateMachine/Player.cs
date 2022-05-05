using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
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
    [SerializeField]
    private float patrolRadius;


  //  [HideInInspector] 
    public bool inSide;
    [HideInInspector]
    public Animation_animal _animation;


    [SerializeField]
    public Transform fearZoneToRun;


 //   [HideInInspector]
    public bool dayIsActive;
 //   [HideInInspector]
    public List<RandomPoint> pointToGoOutSide;
    [HideInInspector]
    public List<RandomPoint> pointToGoInSide;
    [HideInInspector]
    public NavMeshAgent _agent;
    [HideInInspector]
    public Vector3 eatPoint;
    [HideInInspector]
    public Vector3 randomPatrolingDestination;
  //  [HideInInspector]
    public bool IsFearing = false;
    [HideInInspector]
    public bool IsEating = false; 
 //   [HideInInspector]
    public bool EnterinToWrongPaddock = false;
    [HideInInspector]
    public Transform pointFromFear;
    [HideInInspector]
    public bool canFear = false;

    public Vector3 tg;
    private Vector3 startPos;

    private StateMachine _sm;

    // States
    private State _IdleState;
    private State _RotateState;
    private State _WalkingState;
    private State _RunState;
    private State _RotateToEatState;
    private State _FearingState;
    // End States

    public NavMeshPath path;
    public AudioSource _audio;
    public Vector3 startDestination;
    public bool _check;
    public Vector3 test;
    public bool soundIsOn = true;
    void Start()
    {
        StartInitialise();
        StateInitialise();
        FindNewZone();
        _audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("SoundOn"))
        {
            if (PlayerPrefs.GetInt("SoundOn") == 1)
            {
                soundIsOn = true;
            }
            else
            {
                soundIsOn = false;
            }
        }
        else
        {
            soundIsOn = true;
        }
    }
    void Update()
    {
        _sm.currentState.Update();
    }

    #region Start Initialise
    private void StartInitialise()
    {
        _animation = GetComponent<Animation_animal>();
     //   startPos = transform.position;
        _agent = GetComponent<NavMeshAgent>();
    }
    private void StateInitialise()
    {
        _sm = new StateMachine();

        _IdleState = new IdleState(this);
        _RotateState = new RotateState(this);
        _WalkingState = new WalkingState(this);
        _RunState = new RunState(this);
        _sm.Initialize(_IdleState);

    }

    #endregion

    #region StartRun
    public void FindNewZone()
    {
  //      startPos = transform.position;

        StartCoroutine(FinsdStartDayDestination());
    }
    IEnumerator FinsdStartDayDestination()
    {
    
        yield return new WaitForSeconds(.2f);

        path = new NavMeshPath();
        startPos = transform.position;
        test = pointToGoOutSide[Random.Range(0, pointToGoOutSide.Count)].GetRandomPoint();
        _agent.CalculatePath(test, path);
        
    }
    public void StartDayRun()
    {
        dayIsActive = true;
    //    _agent.ResetPath();
        _agent.enabled = false;
        transform.position = startPos;
        _agent.enabled = true;
        _agent.SetPath(path);
        _sm.ChangeState(_RunState);
    }
    #endregion
    public void SwitchState(State currentState)
    {
        if (currentState == _IdleState)
        {
            FindNewNearZone();
            _sm.ChangeState(_RotateState);
        }
        else if (currentState == _RotateState)
        {

            if (IsFearing || IsEating && Vector3.Distance(transform.position, eatPoint) > 0.4f )
            {
                _sm.ChangeState(_RunState);
            }
            else if(!IsEating && !IsFearing && !EnterinToWrongPaddock)
            {
                _sm.ChangeState(_WalkingState);
            }
            else if(EnterinToWrongPaddock)
            {
                EnterinToWrongPaddock = false;
                _sm.ChangeState(_RunState);
            }
            else
            {
                _sm.ChangeState(_IdleState);
            }
        }
        else if( currentState == _WalkingState)
        {
            _sm.ChangeState(_IdleState);
        }
        else if(currentState == _RunState)
        {
            if (IsEating)
            {
                randomPatrolingDestination = eatPoint;
                _sm.ChangeState(_RotateState);
            }
            else if (!IsEating)
            {
                _sm.ChangeState(_IdleState);
            }
        }

    }
    public void FearAnimal( Transform point)
    {
        if (canFear)
        {
            _agent.ResetPath();
            IsFearing = true;
            pointFromFear = point;
            _sm.ChangeState(_RotateState);
        }
    }
    public void FindNewNearZone()
    {
        if (inSide)
            randomPatrolingDestination = pointToGoInSide[Random.Range(0, pointToGoInSide.Count)].GetRandomPoint();
        else
            randomPatrolingDestination = GetRandomPoint();
    }
    public void StartPatroling() => SwitchState(_IdleState);
    public void ResetAnimal()
    {
        inSide = true;
        _sm.ChangeState(_IdleState);
        _agent.ResetPath();
        _agent.enabled = false;
        transform.position = startPos;
        _agent.enabled = true;
    }



    public void WrongWay()
    {
        dayIsActive = true;
        randomPatrolingDestination = pointToGoOutSide[Random.Range(0, pointToGoOutSide.Count)].GetRandomPoint();
        _agent.ResetPath();
        _sm.ChangeState(_RotateState);
    }
    public void RunAway()
    {
        _agent.SetDestination(randomPatrolingDestination);
        _sm.ChangeState(_RunState);
    }
    public void SetEatPoint(Vector3 point) => eatPoint = point;
    public void StartEating(Vector3 point)
    {
        _agent.ResetPath();

        IsEating = true;
        SetEatPoint(point);
        _sm.ChangeState(_RotateState); 
    }
    public void FinishEating()
    {
        IsEating = false;
        _sm.ChangeState(_IdleState);
    }
    public Vector3 GetRandomPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * patrolRadius + transform.position;
        Vector3 pos = new Vector3(randomPos.x, 0, randomPos.z);
        return pos;
    }

    public void PlaySound()
    {
        if (animalType != AnimalType.Ostrich && soundIsOn)
        {
            _audio.Play();
        }
    }
/*    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2.41f);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, startDestination);
    }*/

}