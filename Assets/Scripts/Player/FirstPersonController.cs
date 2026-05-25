using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("MovementSpeed")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("JumpParamiters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityMultiplier = 1.0f;

    [Header("LookParamiters")]
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float upDownLookrange = 80f;

    [Header("References")]
    //player character controller
    [SerializeField] private CharacterController characterController;
    //this is the first person player camera.
    [SerializeField] private Camera mainCamera;
    //has all the inputs in the current version of the game. reference this one if new controlls need to be added
    [SerializeField] private PlayerInputHandler playerInputHandler;

    private Vector3 currentMovement;
    private float verticalRotation;
    private float CurrentSpeed => walkSpeed * (playerInputHandler.SprintTriggered ? sprintMultiplier : 1);

    //Enables first person controlls if set to true
    public bool PlayerControllsEnabled = true;

    //Check if player is active when pausing
    public bool PlayerControllsPause = true;

    public bool GrabberEnabled = false;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        //game is paused until button in 'introDone' is pressed. remove this and enable the code above if you instantly want to play
        Time.timeScale = 0f;
        PlayerControllsEnabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    private void Update()
    {
        //overall check if the player can move, disables using pause buttons.
        if (PlayerControllsEnabled)
        {
            HandleMovement();
            HandleRotation();
        }

        //Enables the top down grab script so it doesn't intervere with normal gameplay, can be edited to also include first person grabbing
        if (GrabberEnabled)
        {
            this.GetComponent<Grabber>().enabled = true;
        }
        else
        {
            this.GetComponent <Grabber>().enabled = false;
        }

    }

    private Vector3 CalculateWorldDirection()
    {
        //prepare world direction for movement controll
        Vector3 inputDirection = new Vector3(playerInputHandler.MovementInput.x, 0f, playerInputHandler.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    private void HandleJumping()
    {
        if (characterController.isGrounded)
            //use the character controller to see if the player is grounded, if yes, move on.
        {
            currentMovement.y = -0.5f;

            if (playerInputHandler.JumpTriggered)
            {
                currentMovement.y = jumpForce;
            }
        }
        else
        {
            currentMovement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        //set the movement direction depending on the button. 
        Vector3 worldDirection = CalculateWorldDirection();
        currentMovement.x = worldDirection.x * CurrentSpeed;
        currentMovement.z = worldDirection.z * CurrentSpeed;

        HandleJumping();
        //WASD input
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalRotation(float rotationAmount)
    {
        //horizontal rotation. rotation amount is given in 'HandleRotation'
        transform.Rotate(0, rotationAmount, 0);
    }

    private void ApplyVerticalRotation(float rotationAmount)
    {
        //Vertical rotation. rotation amount is given in 'HandleRotation'. has extra setting so the player can't infinitly look up and down.
        verticalRotation = Mathf.Clamp(verticalRotation - rotationAmount, -upDownLookrange, upDownLookrange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void HandleRotation()
    {
        //uses the mouse input for first person controll, can also be used by a controll stick.
        float mouseXRotation = playerInputHandler.RotationInput.x * mouseSensitivity;
        float mouseYRotation = playerInputHandler.RotationInput.y * mouseSensitivity;

        ApplyHorizontalRotation (mouseXRotation);
        ApplyVerticalRotation (mouseYRotation);
    }

}
