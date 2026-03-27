using DefaultNamespace;
using UnityEngine;

public class StartPuzzleTrigger : MonoBehaviour,IInteractable
{
    [SerializeField]
    private Camera puzzleCam;

    [SerializeField]
    private string objectInteractionMessage;

    public string InteractMessage => objectInteractionMessage;
    public void Start()
    {
        puzzleCam.enabled = false;

    }

    public void Interact(Camera PlayerCamera)
    {
        switchCam(PlayerCamera);
    }

    void switchCam(Camera PlayerCamera)
    {
        PlayerCamera.enabled = false;
        puzzleCam.enabled = true;
    }
}
