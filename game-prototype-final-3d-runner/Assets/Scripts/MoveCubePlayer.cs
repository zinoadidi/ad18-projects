using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubePlayer : MonoBehaviour
{

    public KeyCode MoveCubePlayerLeftKey;
    
    public KeyCode MoveCubePlayerRightKey;
    public KeyCode MoveCubePlayerSpacebarKey;

    public float HorizontalVelocity = 0f;
    public float VerticalVelocity = 0f;
  
    public int LaneTracker = 2;
    public string ControlLock = "no";
    public string JumpLock = "no";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (HorizontalVelocity, VerticalVelocity, 2);
 
       GMScript.HorizontallVelocity = GetComponent<Rigidbody> ().velocity[0];
       GMScript.VerticalVelocity = GetComponent<Rigidbody> ().velocity[1];


        if((Input.GetKeyDown (MoveCubePlayerLeftKey)) && (LaneTracker > 1) && (ControlLock == "no")){
            Debug.Log("linetracker before left:"+LaneTracker);
             
            HorizontalVelocity = -2;
            StartCoroutine(stopSlide());
            LaneTracker -=1;
            Debug.Log("linetracker left:"+LaneTracker);
            ControlLock = "yes";

        }
        if((Input.GetKeyDown (MoveCubePlayerRightKey)) && (LaneTracker < 3) && (ControlLock == "no")){
            Debug.Log("linetracker before right:"+LaneTracker);
            
            HorizontalVelocity = 2;
            StartCoroutine(stopSlide());
            LaneTracker +=1;
            Debug.Log("linetracker right:"+LaneTracker);
            ControlLock = "yes";

        }
        if((Input.GetKeyDown (MoveCubePlayerSpacebarKey)) && (ControlLock == "no")){
            Debug.Log("jump initiated:");
        
           // Debug.Log(GetObject<CubeEnemy> ().Transform.Position.Y);
            VerticalVelocity = 10;
            JumpLock = "yes";
            StartCoroutine(stopJump());
            //stopJump();
            resetJumpToZero();

            


            
            /* VerticalVelocity = -2;
            StartCoroutine(stopSlide());    
            ControlLock = "yes"; */

            Debug.Log("jump completed:");
            Debug.Log(VerticalVelocity);

        }



        
        
    }

    IEnumerator stopSlide(){
        yield return new WaitForSeconds (.5f);
        HorizontalVelocity = 0;
        ControlLock = "no";

    }
    IEnumerator stopJump(){
        yield return new WaitForSeconds (.3f);
        VerticalVelocity = 0;
        if(VerticalVelocity!=0){
            VerticalVelocity = 0;
        }
    }
    IEnumerator resetJumpToZero(){
        yield return new WaitForSeconds (.3f);
        VerticalVelocity = 0;
        JumpLock = "no";
    }

    void OnCollisionEnter(Collision other){
     if(other.gameObject.tag == "CubeEnemy"){
         Destroy(gameObject);
         
     }
     if(other.gameObject.tag == "PowerUp"){
         Destroy(other.gameObject);
         
     }

     if(other.gameObject.name == "PowerUpHealthContainer"){
         Destroy(other.gameObject);
         
     }
    }
}
 

