﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			GetComponent<Renderer>().material.color = Color.red;
		}
		if(Input.GetKeyDown(KeyCode.G)){
			GetComponent<Renderer>().material.color = Color.green;
		}
		if(Input.GetKeyDown(KeyCode.B)){
			GetComponent<Renderer>().material.color = Color.blue;
		}
		if(Input.GetKeyDown(KeyCode.A)){
			GetComponent<Renderer>().material.color = Color.yellow;
		}


		/* switch(Input.GetKeyDown(KeyCode.R){
			case
			GetComponent<Renderer>().material.color = Color.red;
		} */
	}
}
