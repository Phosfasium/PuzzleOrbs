using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player_Movement";

    [Header("Action Name References")]
    [SerializeField] private string movement = "Movement";
    [SerializeField] private string rotation = "Rotation";
    [SerializeField] private string topDownMouse = "TopDownMouse";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string interact = "Interact";
    [SerializeField] private string pause = "Pause";
    [SerializeField] private string grab = "Grab";

    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction topDownMouseAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction interactAction;
    public InputAction pauseAction;
    private InputAction grabAction;

    public Vector2 MovementInput { get; private set; }
    public Vector2 RotationInput { get; private set; }
    public Vector2 TopDownMouseInput { get; private set; }
    public bool JumpTriggered { get; private set; }
    public bool SprintTriggered { get; private set; }
    public bool InteractTriggered { get; private set; }
    public bool PauseTriggered {  get; private set; }
    public bool GrabTriggered { get; private set; }

    [Header("FireOnceTrigger")]
    public bool MenuFireOnce { get; private set; }
    public bool GrabFireOnce { get; private set; }



    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

        movementAction = mapReference.FindAction(movement);
        rotationAction = mapReference.FindAction(rotation);
        topDownMouseAction = mapReference.FindAction(topDownMouse);
        jumpAction = mapReference.FindAction(jump);
        sprintAction = mapReference.FindAction(sprint);
        interactAction = mapReference.FindAction(interact);
        pauseAction = mapReference.FindAction(pause);
        grabAction = mapReference.FindAction(grab);



        subscribeActionValuesToInputEvents();
    }


    private void subscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        topDownMouseAction.performed += inputInfo => TopDownMouseInput = inputInfo.ReadValue<Vector2>();
        topDownMouseAction.canceled += inputInfo => TopDownMouseInput = Vector2.zero;

        jumpAction.performed += inputInfo => JumpTriggered = true;
        jumpAction.canceled += inputInfo => JumpTriggered = false;

        sprintAction.performed += inputInfo => SprintTriggered = true;
        sprintAction.canceled += inputInfo => SprintTriggered = false;

        interactAction.performed += inputInfo => InteractTriggered = true;
        interactAction.canceled += inputInfo => InteractTriggered = false;

        grabAction.started += inputInfo => GrabTriggered = true;
        grabAction.canceled += inputInfo => GrabTriggered = false;     
    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }

    private void Update()
    {
        MenuFireOnce = pauseAction.WasPressedThisFrame();
        GrabFireOnce = grabAction.WasPressedThisFrame();
    }

}
