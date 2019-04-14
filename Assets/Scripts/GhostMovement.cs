﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos =  GameObject.FindGameObjectWithTag("Player").transform.position;
        agent.SetDestination(pos);

    }
}