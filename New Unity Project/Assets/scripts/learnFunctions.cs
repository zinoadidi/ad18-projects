using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnFunctions : MonoBehaviour {

	// Use this for initialization
	int myInt = 7;
	void Start () {
		myInt = multiplyBy2(myInt);	
		Debug.Log(myInt);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int multiplyBy2(int num){
		return num * 2;
	}
}
