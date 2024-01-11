using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            if (SceneManager.GetActiveScene().name == "MainLevel")
                SceneManager.LoadScene(sceneName: "TitleScreen");
            else{
                PlayerPrefs.SetFloat("startUp", 0);
                Application.Quit();
            }
        }
    }
}
