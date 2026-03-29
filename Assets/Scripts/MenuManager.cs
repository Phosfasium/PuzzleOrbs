using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private PauseGame pauseGame;
    private GameObject Player;
    private FirstPersonController firstPersonController;
    



    private bool isPaused;


    void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        Player = GameObject.FindWithTag("Player");
        firstPersonController = Player.GetComponent<FirstPersonController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGame.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    #region Pause/Unpause Functions

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        firstPersonController.PlayerControllsEnabled = false;
        
        OpenMainMenu();
    }

    public void UnPause()
    {
        isPaused= false;
        Time.timeScale = 1f;
        firstPersonController.PlayerControllsEnabled = true;

        CloseAllMenus();
    }

    #endregion

    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);
    }

    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
    }

}
