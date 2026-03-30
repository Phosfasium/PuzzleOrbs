using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("Canvasses")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;

    [Header("Other gameobjects")]
    [SerializeField] private PauseGame pauseGame;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _SettingsMenuFirst;

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
        if (firstPersonController.PlayerControllsPause == true)
        {
            firstPersonController.PlayerControllsEnabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        OpenMainMenu();
    }

    public void UnPause()
    {
        isPaused= false;
        Time.timeScale = 1f;
        if (firstPersonController.PlayerControllsPause == true)
        {
            firstPersonController.PlayerControllsEnabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        CloseAllMenus();
    }

    #endregion

    #region Canvas Activation/Deactivation

    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenSettingsFromMenuHandle()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_SettingsMenuFirst);
    }

    private void OpenMenuFromSettingsHandle()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion


    #region Main Menu Button Actions

    public void OnSettingsPress()
    {
        OpenSettingsFromMenuHandle();
    }

    public void OnResetLevelPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnResumePress()
    {
        UnPause ();
    }

    public void OnBackPress()
    {
        OpenMenuFromSettingsHandle();
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }
    #endregion

}
