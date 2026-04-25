using UnityEngine;

public class IntroDone : MonoBehaviour
{
    [SerializeField]
    private GameObject Introcanvas;

    private GameObject Player;
    private FirstPersonController firstPersonController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        firstPersonController = Player.GetComponent<FirstPersonController>();

    }
    public void introDone()
    {
        Time.timeScale = 1f;

            firstPersonController.PlayerControllsEnabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
        Introcanvas.SetActive(false);
    }
}
