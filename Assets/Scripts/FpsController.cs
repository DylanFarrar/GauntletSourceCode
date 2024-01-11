using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class FpsController : MonoBehaviour
{
    CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private float curSpeedX;
    private float curSpeedY;

    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 16f;
    public float lookSpeed = 3f;
    public float lookXLimit = 45f;
    public bool canMove = true;
    public float inAirDecay = 1;
    public float jumpAcceleration = 1;
    public float deathHeight;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        lookSpeed = lookSpeed * PlayerPrefs.GetFloat("sensitivity");
    }

    // Update is called once per frame
    void Update()
    {
        //makes vector directions easier to reference later in code
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //checks for if the player is holding shift in current frame
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        //allows the player to change their directional movement only when on the ground
        if (characterController.isGrounded)
        {
            curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        }

        //causes in air decceleration over time
        if (!characterController.isGrounded)
        {
            if (curSpeedX > 0)
                curSpeedX -= inAirDecay * Time.deltaTime;
            else
                curSpeedX += inAirDecay * Time.deltaTime;
            if (curSpeedY > 0)
                curSpeedY -= inAirDecay * Time.deltaTime;
            else
                curSpeedY += inAirDecay * Time.deltaTime;
        }

        //jumping with an acceleration applied to allow both an increase in speed when jumping 
        //but also to allow the player to jump onto an object currently blocking there movement
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            curSpeedY += jumpAcceleration * Input.GetAxis("Horizontal");
            curSpeedX += jumpAcceleration * Input.GetAxis("Vertical");
        }

        //gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        //applies the character movement for the current frame
        characterController.Move(moveDirection * Time.deltaTime);

        //controls camera movement
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        //go back to the menu if the player falls off the map
        if (transform.position.y < deathHeight)
        {
            SceneManager.LoadScene(sceneName: "TitleScreen");
        }
    }
}