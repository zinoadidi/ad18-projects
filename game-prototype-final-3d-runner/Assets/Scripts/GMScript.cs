using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager.

public class GMScript : MonoBehaviour
{
    public static float VerticalVelocity = 0.0f;
    public static float HorizontallVelocity = 0.0f;
    public static float ZAxis = 0.0f;

    public static string GameState = "active";
    public static int PlayerScore = 0;
    public static int LivesLeft = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        
    }

    public static void ShowPlayerStats(){
        Debug.Log("Game State:");
        Debug.Log(GameState);
        Debug.Log("Player Score:");
        Debug.Log(PlayerScore);
        Debug.Log("Lives Left:");
        Debug.Log(LivesLeft);
    }

    public static void EndGame(){
        ShowPlayerStats();
        GameState = "active";
        //SceneManager.LoadScene("Game");
        SceneManager.LoadScene("GameOver");
    }
}


