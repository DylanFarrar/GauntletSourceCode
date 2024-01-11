using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastTime : MonoBehaviour
{
    private float lastTime = 0;
    private float startUp;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = PlayerPrefs.GetFloat("lastTime");
        startUp = PlayerPrefs.GetFloat("startUp");

        TMP_Text textmeshPro = GetComponent<TMP_Text>();

        if(startUp != 0){
            textmeshPro.SetText("Last Time: {0:3} ", lastTime);
        }
        else{
            textmeshPro.SetText("<alpha=#00>");
        }
    }
}
