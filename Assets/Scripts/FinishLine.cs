using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private float finishTime;
    public Timer timer;
    public float bestTime;

    // Start is called before the first frame update
    void Start()
    {
        //checks for the players best time
        timer = GetComponent<Timer>();
        bestTime = PlayerPrefs.GetFloat("bestTime");
        //checks if the best time is somehow negative and sets it to 100 seconds
        if(bestTime <= 0) {bestTime = 100;}
    }

    //if the player collides with the finish line the game checks if they beat the best time and then loads the menu
    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            finishTime = timer.GetTime();

            if(bestTime > finishTime || bestTime == 0)
            {
                bestTime = finishTime;
                PlayerPrefs.SetFloat("bestTime", finishTime);
            }
            
            PlayerPrefs.SetFloat("lastTime", finishTime);

            SceneManager.LoadScene(sceneName: "TitleScreen");
        }
	}
}
