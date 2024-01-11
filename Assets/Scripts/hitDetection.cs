using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hitDetection : MonoBehaviour
{
    public float dropSpeed = 3f;
    public float totalEnemiesKilled;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * dropSpeed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            totalEnemiesKilled = PlayerPrefs.GetFloat("totalEnemiesKilled");
            totalEnemiesKilled++;
            PlayerPrefs.SetFloat("totalEnemiesKilled", totalEnemiesKilled);
            Destroy(collision.gameObject);
        }

		Destroy(gameObject);
	}
}
