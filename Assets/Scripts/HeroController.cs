﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour {

    //public NavMeshAgent Agent;
    public Movement Movement { get; private set; }

	// Use this for initialization
	void Start () {
        Movement = GetComponent<Movement>();
	}
}
