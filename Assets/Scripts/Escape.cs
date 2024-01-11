using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //checks for if player presses escape
        if(Input.GetKey(KeyCode.Escape)){
            if (SceneManager.GetActiveScene().name == "MainLevel")
                //goes to menu if current in main level
                SceneManager.LoadScene(sceneName: "TitleScreen");
            else{
                //closes the game if in the menu
                PlayerPrefs.SetFloat("startUp", 0);
                Application.Quit();
            }
        }
    }
}
