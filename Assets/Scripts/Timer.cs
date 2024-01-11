using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float enemyNum = 19;
    public float penalty = 3;
    public float totalTimePenalty;
    private float totalEnemiesKilled;
    private float finalPenalty;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        //changes the timer during gameplay
        currentTime += Time.deltaTime;
    }

    public void Reset(){
        //sets the timer to 0 at the start
        currentTime = 0;
    }

    public float GetTime(){
        //does all the math to determine the final time after time penalties from not destroying enemies
        totalEnemiesKilled = PlayerPrefs.GetFloat("totalEnemiesKilled");
        finalPenalty = penalty * (enemyNum - totalEnemiesKilled);
        currentTime += finalPenalty;
        return currentTime;
    }
}
