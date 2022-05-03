using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading;

public class AiControl : MonoBehaviour
{

    public  List<NavMeshAgent> _agents;
    public static AiControl instance;

    private List<NavMeshPath> path = new List<NavMeshPath>();
    public Container container;


    private void Start()
    {
        instance = this;
    }
    
    void Update()
    {

    }
    public  void StartAgents()
    {
        for (int i = 0; i < _agents.Count; i++)
        {
       //     _agents[i].GetComponent<Player>().Tester();
       //     _agents[i].SetPath(path[i]);
        }
    }

    public void GetAgents(Player animal)
    {
        _agents.Add(animal._agent);
    }
    public void ChechPath()
    {
        Debug.Log("s");
        for (int i = 0; i < _agents.Count; i++)
        {
            path.Add(new NavMeshPath());
            _agents[i].CalculatePath(GetRandomPoint(), path[i]);
        }
    }


    private  Vector3 GetRandomPoint() => container.RandomPoints[Random.Range(0, container.RandomPoints.Count)].GetRandomPoint();

}
