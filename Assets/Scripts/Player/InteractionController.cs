using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DefaultNamespace;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;
    [SerializeField]
    TextMeshProUGUI interactionText;
    [SerializeField]
    float interactionDistance = 5f;
    [SerializeField] 
    private PlayerInputHandler playerInputHandler;
    [SerializeField]
    private FirstPersonController FirstPersonController;

    IInteractable currentTargetedInteractable;

    public void Update()
    {
        //check if the player is in first person mode.
        if (FirstPersonController.PlayerControllsEnabled == true)
        {
            UpdateCurrentInteractable();
            UpdateInteractionText();
            CheckForInteractionInput();
        }

    }
    void UpdateCurrentInteractable()
    {
        // get the center of the player camera, shoot a raycast and put the object with a script with IInteractable as a class in currentTargetedInteractable
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        Physics.Raycast(ray, out var hit, interactionDistance);
        currentTargetedInteractable = hit.collider?.GetComponent<IInteractable>();
    }

    void UpdateInteractionText()
    {
        
        if (currentTargetedInteractable == null)
        {
            //if there is nothing, make the field empty
            interactionText.text = string.Empty;
            return;
        }
        //if there is an IInteractable, add the text of the object.
        interactionText.text = currentTargetedInteractable.InteractMessage;
    }

    void CheckForInteractionInput()
    {
        // check the player input handler if a button is pressed. this is not set to 'was pressed this frame' in that script yet.
        if (playerInputHandler.InteractTriggered && currentTargetedInteractable != null) 
        {
            currentTargetedInteractable.Interact(playerCamera, FirstPersonController);
            interactionText.text = string.Empty;
        }
    }

    public void exitPuzzle()
    {
        //exit puzzle code. is in here due to the IInteractable check in this code. could be added to different script.
        currentTargetedInteractable.ExitPuzzle(playerCamera, FirstPersonController);
    }
}
