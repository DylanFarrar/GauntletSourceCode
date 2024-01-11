using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Projectile projectilePrefab;
    public float fireRate;
    public float timeSinceLastShot;
    public float fireRateInterval;
    private float lastShotTime;
    private float currentTime;
    
    void Start()
    {
        //finds the seconds between shots
        fireRateInterval = 1 / (fireRate / 60);
        //sets all variables to begin firing
        timeSinceLastShot = 0;
        lastShotTime = 0;
        currentTime = 0;
    }

    private void Update() {

        //
        currentTime += Time.deltaTime;

        timeSinceLastShot = currentTime - lastShotTime;

        //checks if it is time to fire agian then checks for input
        if (fireRateInterval < timeSinceLastShot)
        {
            if (Input.GetMouseButton(0))
            {
                //sets variables for the projectile
                var position = transform.position + transform.forward;
                Quaternion rotation = transform.rotation;
                var projectile = Instantiate(projectilePrefab, position, rotation);
                projectile.Fire(projectileSpeed, transform.forward);
                lastShotTime = currentTime;
            }
        }
    } 
}
