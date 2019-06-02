using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubePlayer : MonoBehaviour
{

    public KeyCode MoveCubePlayerLeftKey,MoveCubePlayerRightKey,MoveCubePlayerSpacebarKey;
    public float HorizontalVelocity = 0f;
    public float VerticalVelocity = 0f;
  
    public int LaneTracker = 2;
    public string ControlLock = "no";
    public string JumpLock = "no";
    // Start is called before the first frame update
    void Start()
    {
        GMScript.PlayerScore = 0;
        GMScript.LivesLeft = 3;
        GMScript.GameState = "active";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (HorizontalVelocity, VerticalVelocity, 2);
 
       GMScript.HorizontallVelocity = GetComponent<Rigidbody> ().velocity[0];
       GMScript.VerticalVelocity = GetComponent<Rigidbody> ().velocity[1];
       GMScript.ZAxis = GetComponent<Rigidbody> ().velocity[2];
    
        //jump();

        if(
            ((Input.GetKeyDown (MoveCubePlayerLeftKey)) ||
            (MobileControl.mSwipeLeft)) &&
            (LaneTracker > 1) && (ControlLock == "no") 
        ){
            Debug.Log("linetracker before left:"+LaneTracker);
             
            HorizontalVelocity = -2;
            StartCoroutine(stopSlide());
            LaneTracker -=1;
            Debug.Log("linetracker left:"+LaneTracker);
            ControlLock = "yes";

        }
        if(((Input.GetKeyDown (MoveCubePlayerRightKey)) || (MobileControl.mSwipeRight)) && (LaneTracker < 3) && (ControlLock == "no")){
            Debug.Log("linetracker before right:"+LaneTracker);
            
            HorizontalVelocity = 2;
            StartCoroutine(stopSlide());
            LaneTracker +=1;
            Debug.Log("linetracker right:"+LaneTracker);
            ControlLock = "yes";

        }
        if(Input.GetKeyDown (MoveCubePlayerSpacebarKey))
        {
            Debug.Log("jump initiated:");

            // Debug.Log(GetObject<CubeEnemy> ().Transform.Position.Y);
            jump();
            //stopJump();
            //resetJumpToZero();





            /* VerticalVelocity = -2;
            StartCoroutine(stopSlide());    
            ControlLock = "yes"; */

          

        }

        if (GMScript.LivesLeft <1){
            GMScript.EndGame(); 
        }
        
        
    }

    private void jump()
    {
        if(JumpLock == "no"){
            VerticalVelocity = 2;
            JumpLock = "yes";
          
            Debug.Log("jump completed:");
            Debug.Log(VerticalVelocity);
            StartCoroutine(stopJump());
        }
       
    }

    IEnumerator stopSlide(){
        yield return new WaitForSeconds (.5f);
        HorizontalVelocity = 0;
        ControlLock = "no";

    }
    IEnumerator stopJump(){
        yield return new WaitForSeconds (.1f);
        VerticalVelocity = 0;
        if(VerticalVelocity!=0){
            VerticalVelocity = 0;
        }
        resetJumpToZero();
    }
    IEnumerator resetJumpToZero(){
        yield return new WaitForSeconds (.10f);
        JumpLock = "no";
    }

    IEnumerator Blink() {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds (.3f);
        GetComponent<Renderer>().enabled = true;
        
    }
    void OnCollisionEnter(Collision other){
     if(other.gameObject.tag == "CubeEnemy"){
         Destroy(other.gameObject);         
         Blink();
         GMScript.LivesLeft -=1;
         GMScript.ShowPlayerStats();
         ///Destroy(gameObject);
         
     }
     if(other.gameObject.tag == "PowerUp"){
         Destroy(other.gameObject);
         GMScript.PlayerScore += 100;
         GMScript.ShowPlayerStats();
         
     }

     if(other.gameObject.tag == "Platform"){
         jump();
         
     }

    }
}
 

