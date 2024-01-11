using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public Slider slider;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        //checks for the palyers sensitivity and sets it to .6 by default
        sensitivity = PlayerPrefs.GetFloat("sensitivity", 0.6f);
        slider.SetValueWithoutNotify(sensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        //checks for the slider being interacted with
        slider.onValueChanged.AddListener(delegate {setSensitivity(); });
    }
    
    public void setSensitivity(){
        //sets the players sensitivity from the slider
        sensitivity = slider.value;
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }
}
