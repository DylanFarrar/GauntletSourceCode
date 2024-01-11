using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUp : MonoBehaviour
{
    private float startUp;

    // Start is called before the first frame update
    void Start()
    {
        startUp = PlayerPrefs.GetFloat("startUp", 0);

        TMP_Text textmeshPro = GetComponent<TMP_Text>();

        if(startUp != 0){
            textmeshPro.SetText("<alpha=#00>");
        }
    }
}
