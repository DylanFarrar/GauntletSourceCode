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

    //checks if the collided object has the enemy tag
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //used playerprefs to track the total number of enemies killed
            totalEnemiesKilled = PlayerPrefs.GetFloat("totalEnemiesKilled");
            totalEnemiesKilled++;
            PlayerPrefs.SetFloat("totalEnemiesKilled", totalEnemiesKilled);
            //destroys object hit
            Destroy(collision.gameObject);
        }

        //destroys the bullet object
		Destroy(gameObject);
	}
}
