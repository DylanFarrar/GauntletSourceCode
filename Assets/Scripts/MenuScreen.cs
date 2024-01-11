using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public float bestTime;
    public float lastTime;
    public float totalEnemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        //locks the cursor in the menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //checks the best and last times from the player
        bestTime = PlayerPrefs.GetFloat("bestTime");
        lastTime = PlayerPrefs.GetFloat("lastTime");
    }

    // Update is called once per frame
    void Update()
    {
        //if the player hits space all variables are set for the start of a run
        if(Input.GetButton("Jump"))
        {
            totalEnemiesKilled = 0;
            PlayerPrefs.SetFloat("totalEnemiesKilled", totalEnemiesKilled);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            float startUp = 1;
            PlayerPrefs.SetFloat("startUp", startUp);
            SceneManager.LoadScene(sceneName: "MainLevel");
        }
    }
}
