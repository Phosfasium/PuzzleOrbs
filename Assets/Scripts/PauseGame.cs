using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public bool MenuOpenCloseInput {  get; private set; }
    [SerializeField] private PlayerInputHandler playerInputHandler;


    // Update is called once per frame
    void Update()
    {
        MenuOpenCloseInput = playerInputHandler.pauseAction.WasPressedThisFrame();
    }
}
