using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	public int health;
	// Use this for initialization
	public void Awake (){
		Debug.Log("NPC awake and health is "+ health);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
