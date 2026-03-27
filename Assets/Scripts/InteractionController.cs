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

    IInteractable currentTargetedInteractable;

    public void Update()
    {
        UpdateCurrentInteractable();
        UpdateInteractionText();
        CheckForInteractionInput();
    }
    void UpdateCurrentInteractable()
    {
        var ray = playerCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        Physics.Raycast(ray, out var hit, interactionDistance);
        currentTargetedInteractable = hit.collider?.GetComponent<IInteractable>();
    }

    void UpdateInteractionText()
    {
        if (currentTargetedInteractable == null)
        {
            interactionText.text = string.Empty;
            return;
        }

        interactionText.text = currentTargetedInteractable.InteractMessage;
    }

    void CheckForInteractionInput()
    {
        if (playerInputHandler.InteractTriggered && currentTargetedInteractable != null) 
        {
            currentTargetedInteractable.Interact(playerCamera);
        }
    }
}
