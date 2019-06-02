using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControl : MonoBehaviour
{
    public static bool mTap,mSwipeLeft,mSwipeRight,mSwipeUp,mSwipeDown,isDragging;
    private Vector2 startTouch, swipeDelta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Reset(){
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
        isDragging = false;
    }
    // Update is called once per frame
    void Update()
    {
        mTap =false;
        mSwipeLeft =false;
        mSwipeRight = false;
        mSwipeUp= false;
        mSwipeDown = false;

        #region standalone input
        if(Input.GetMouseButtonDown(0)){
            mTap = true;
            isDragging = true;
            startTouch = Input.mousePosition; 
        }else if(Input.GetMouseButtonUp(0)){
            isDragging = false;
            Reset();
        }

        #endregion

        #region Mobile Input
        if(Input.touches.Length>0){
            if(Input.touches[0].phase == TouchPhase.Began){
                mTap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
                isDragging = false;
                Reset();
            }
        }

        #endregion
        //calculate the distance
        swipeDelta = Vector2.zero;
        if(isDragging){
            if(Input.touches.Length > 0){
                swipeDelta = Input.touches[0].position - startTouch;
            }else if(Input.GetMouseButton(0)){
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            } 
        }

        // did we cross the deadzone? 
        if(swipeDelta.magnitude > 125){
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x)> Mathf.Abs(y)){

                //Left or Right
                if(x < 0){
                    mSwipeLeft = true;
                }else{
                    mSwipeRight = true;
                }
            }else{
                //up or down
                if(y < 0){
                    mSwipeDown = true;
                }else{
                    mSwipeUp = true;
                }
            }

            Reset();
        }

    }
}
