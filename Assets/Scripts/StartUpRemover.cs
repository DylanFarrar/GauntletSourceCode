using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUpRemover : MonoBehaviour
{
    

    //this was used early in development and later not used but I wanted it to stay included for future reference and so are other references if startUp



    private float startUp;

    // Start is called before the first frame update
    void Start()
    {
        startUp = PlayerPrefs.GetFloat("startUp", 0);

        TMP_Text textmeshPro = GetComponent<TMP_Text>();

        if(startUp != 0){
            
        }
        else{
            textmeshPro.SetText("<alpha=#00>");
        }
    }
}
