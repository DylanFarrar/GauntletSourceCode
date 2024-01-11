using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LungeController : MonoBehaviour
{
    private FpsController fpsController;
    private Vector3 moveDirection = Vector3.zero;
    private float lungeForce;
    private bool isLunging = false;
    private float lastLunge;

    public CharacterController controller;
    public float initialLungeForce = 10.0f;
    public float lungeHeight = 10f;
    public float delay = 2f;
    public bool canLunge = true;
    public float horizontalRatio = .5f;

    void Start()
    {
        //creates a reference to components of the class
        fpsController = GetComponent<FpsController>();
    }

    void Update()
    {
        //checks if the character is able to lunge then runs StartLunge()
        if (Input.GetKey("q") && !isLunging && canLunge && fpsController.canMove)
        {
            StartLunge();
        }

        //runs the funtion for every frame of the lunge
        if (isLunging)
        {
            Lunge();
        }

        //checks for is the delay between lunges has elapsed
        if (Time.time - lastLunge > delay)
        {
            canLunge = true;
        }
    }

    //sets all initial values for the start of the lunge 
    //makes it so the player cannot lunge again until line 41 becomes true
    //remembers the time the lunge takes place to compare against the lunges delay
    //makes isLunging = true so the next frame causes line 35 to be true
    //sets the starting force applied to the lunge
    void StartLunge()
    {
        canLunge = false;
        lastLunge = Time.time;
        isLunging = true;
        lungeForce = initialLungeForce;
    }

    void Lunge()
    {
        //makes vector directions easier to reference later in code
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //sets the direction and velocity of the player during the lunge
        moveDirection = (forward * lungeForce) + (horizontalRatio * right * fpsController.walkSpeed * Input.GetAxis("Horizontal"));

        //applies the movement to the character
        controller.Move(moveDirection * Time.deltaTime);

        //applies vertical movement to the character
        controller.Move(Vector3.up * lungeHeight * Time.deltaTime);

        // Decay the lunge force over time
        lungeForce -= Time.deltaTime * initialLungeForce;

        if (lungeForce <= 0.0f)
        {
            isLunging = false;
            // Ensure the force doesn't go negative
            lungeForce = 0.0f; 
        }
    }
}
