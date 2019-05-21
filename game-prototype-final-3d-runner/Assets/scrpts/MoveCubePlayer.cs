using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubePlayer : MonoBehaviour
{

    public KeyCode MoveCubePlayerLeftKey;
    
    public KeyCode MoveCubePlayerRightKey;

    public float HorizontalVelocity = 0;
  
    public int LaneTracker = 2;
    public string ControlLock = "no";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody> ().velocity = new Vector3 (HorizontalVelocity, 0, 4);
       
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
        
    }

    IEnumerator stopSlide(){
        yield return new WaitForSeconds (.5f);
        HorizontalVelocity = 0;
        ControlLock = "no";

    }
}
