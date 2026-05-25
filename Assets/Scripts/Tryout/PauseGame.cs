using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public bool MenuOpenCloseInput {  get; private set; }
    [SerializeField] private PlayerInputHandler playerInputHandler;


    void Update()
    {
        //check if the menu button was pressed for one frame. this code has become obsolete, has been added to 'MenuManager' and 'PlayerInputHandler'
        MenuOpenCloseInput = playerInputHandler.pauseAction.WasPressedThisFrame();
    }
}
