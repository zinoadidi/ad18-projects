using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject templateNPC;

	public void Awake (){
		Debug.Log("Awake");
		
	}
	// Use this for initialization
	public void Start () {
		Debug.Log("Start");
	}
	
	// Update is called once per frame
	public void Update () {
		//Debug.Log("Update"+ Time.deltaTime);
		if(Input.GetKeyUp (KeyCode.Space)){
			Debug.Log("space is pressed");
		}
		if(Input.GetMouseButtonUp (0)){
			// Debug.Log("mouse clicked");
			//Debug.Log(templateNPC.name + " created :)");
			
			
			int y = 0;
			
			for(int i = 0; i < 6; i++) {
				y+=2;
				GameObject gameObjectNPC = Instantiate(templateNPC);
				gameObjectNPC.transform.position = new Vector3 (0,y,0);
			} 

		}
	}

	public void FixedUpdate () {
		//Debug.Log("Fixed");
		
	}
}
