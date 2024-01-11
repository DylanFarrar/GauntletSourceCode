using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody _rb;
    public float currentTime;
    public float despawnTime;

    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        //makes the bullet despawn after a set time
        currentTime += Time.deltaTime;
        if (currentTime > despawnTime) {Destroy(gameObject);}
    }

    //gets a reference to the rigidbody
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    //sets bullets velocity
    public void Fire(float speed, Vector3 direction) {
        _rb.velocity = direction * speed;
    }
}
