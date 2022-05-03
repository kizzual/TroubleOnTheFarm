using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wtf : MonoBehaviour
{
    //   private List<NavMeshAgent> _agents;

    public List<NavMeshAgent> agents;
    public float distance = 1000;
    public Vector3 target;
    void Start()
    {
        for (int i = 0; i < agents.Count; i++)
        {
            target = agents[i].transform.position + Vector3.forward * distance;
            NavMeshPath path = new NavMeshPath();
            agents[i].CalculatePath(target, path);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target);
    }

    void Update()
    {
        bool pathPending = false;
        for (int i = 0; i < agents.Count; i++)
        {
           
            if (agents[i].pathPending)
            {
                pathPending = true;
                break;
            }
        }
   /*     if (!pathPending)
        {
            Debug.Log("s");
            StartAgents();
        }*/
    }
   private void StartAgents()
    {
        for (int i = 0; i < agents.Count; i++)
        {
            agents[i].destination = target;
        }
    }

    /*
   public void GetAgents(List<NavMeshAgent> agents)
   {

   }

   private Vector3 GetRandomPoint() => _randomPoints[Random.Range(0, _randomPoints.Count)].GetRandomPoint();*/
}
