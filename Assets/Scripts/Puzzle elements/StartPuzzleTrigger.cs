using DefaultNamespace;
using UnityEngine;

public class StartPuzzleTrigger : MonoBehaviour,IInteractable
{
    [SerializeField]
    private Camera puzzleCam;

    [SerializeField]
    private GameObject _PuzzleCanvas;

    [SerializeField]
    private string objectInteractionMessage;
    public string InteractMessage => objectInteractionMessage;


    public void Start()
    {
        puzzleCam.enabled = false;

    }
    #region start the puzzle
    public void Interact(Camera PlayerCamera, FirstPersonController FirstPersonController)
    {
        //switch from first person to puzzle perspective with point and click controlls.
        switchCam(PlayerCamera, FirstPersonController);
        FirstPersonController.PlayerControllsEnabled = false;
        FirstPersonController.PlayerControllsPause = false;
        GetComponent<BoxCollider>().enabled = false;
        FirstPersonController.GrabberEnabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _PuzzleCanvas.SetActive(true);

    }

    public void switchCam(Camera PlayerCamera, FirstPersonController FirstPersonController)
    {
        //PlayerCamera.enabled = false;
        //puzzleCam.enabled = true;
        //switch to the right camera
        PlayerCamera.enabled = !PlayerCamera.enabled;
        puzzleCam.enabled = !puzzleCam.enabled;
    }
    #endregion
    public void ExitPuzzle(Camera PlayerCamera, FirstPersonController FirstPersonController)
    {
        //exit the puzzle and switch back to first person mode.
        FirstPersonController.PlayerControllsEnabled = true;
        FirstPersonController.PlayerControllsPause = true;
        GetComponent<BoxCollider>().enabled = true;
        FirstPersonController.GrabberEnabled = false;
        switchCam(PlayerCamera, FirstPersonController);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _PuzzleCanvas.SetActive(false);

    }
}
