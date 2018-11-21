using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Movement Movement { get; private set; }

	// Use this for initialization
	void Start () {
        Movement = GetComponent<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
