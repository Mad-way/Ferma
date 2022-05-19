using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public List<Transform> points = new List<Transform>();
    int i = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.Warp(transform.position);

        PointUpdate();
        if (points.Count > 0) 
            agent.SetDestination(points[i].position);
        //Debug.Log(points.Count);
        //Debug.Log(agent.pathEndPosition);
    }

    public void PointUpdate()
    {
        i = Random.Range(0, points.Count);
    }

    void Update()
    {
        //Transform pointsObjects = GameObject.FindGameObjectsWithTag("Points").transform;
        if (Vector3.Distance(transform.position, agent.pathEndPosition) <= 0.5f)
        {
            PointUpdate();

            if (points.Count > 0)
                agent.SetDestination(points[i].position);
        }
    }
}
