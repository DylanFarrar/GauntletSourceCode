using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestTime : MonoBehaviour
{
    private float bestTime;
    private float startUp;

    // Start is called before the first frame update
    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("bestTime");
        startUp = PlayerPrefs.GetFloat("startUp", 0);

        TMP_Text textmeshPro = GetComponent<TMP_Text>();

        if(startUp != 0){
            textmeshPro.SetText("Best Time: {0:3} ", bestTime);
        }
        else{
            textmeshPro.SetText("<alpha=#00>");
        }
    }
}
