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
        sensitivity = PlayerPrefs.GetFloat("sensitivity");
        slider.SetValueWithoutNotify(sensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        slider.onValueChanged.AddListener(delegate {setSensitivity(); });
    }
    
    public void setSensitivity(){
        sensitivity = slider.value;
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
    }
}
