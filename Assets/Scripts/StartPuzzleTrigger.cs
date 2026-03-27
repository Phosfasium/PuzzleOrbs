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

    public void Interact(Camera PlayerCamera, FirstPersonController FirstPersonController)
    {

        switchCam(PlayerCamera, FirstPersonController);
        FirstPersonController.PlayerControllsEnabled = false;
    }

    public void switchCam(Camera PlayerCamera, FirstPersonController FirstPersonController)
    {
        //PlayerCamera.enabled = false;
        //puzzleCam.enabled = true;
       


        PlayerCamera.enabled = !PlayerCamera.enabled;
        puzzleCam.enabled = !puzzleCam.enabled;
       
        


    }
}
