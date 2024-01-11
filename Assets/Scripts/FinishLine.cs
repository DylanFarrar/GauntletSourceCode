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
        timer = GetComponent<Timer>();
        bestTime = PlayerPrefs.GetFloat("bestTime");
        if(bestTime <= 0) {bestTime = 100;}
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            finishTime = timer.GetTime();

            if(bestTime > finishTime || bestTime == 0){
                bestTime = finishTime;
                PlayerPrefs.SetFloat("bestTime", finishTime);
            }
            
            PlayerPrefs.SetFloat("lastTime", finishTime);

            SceneManager.LoadScene(sceneName: "TitleScreen");
        }
	}
}
