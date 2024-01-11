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
        currentTime += Time.deltaTime;
    }

    public void Reset(){
        currentTime = 0;
    }

    public float GetTime(){
        totalEnemiesKilled = PlayerPrefs.GetFloat("totalEnemiesKilled");
        finalPenalty = penalty * (enemyNum - totalEnemiesKilled);
        currentTime += finalPenalty;
        return currentTime;
    }
}
