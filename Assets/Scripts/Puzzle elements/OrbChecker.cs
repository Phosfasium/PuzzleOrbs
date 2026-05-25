using UnityEngine;

public class OrbChecker : MonoBehaviour
{
    public bool hasOrb = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private Transform Origin;
    [SerializeField]
    private LayerMask puzzleOrb;


    private void Update()
    {
        Debug.DrawRay(Origin.position, Vector3.up * 1, Color.red);
    }
    public void CallFunction()
    {
        if (Physics.Raycast(Origin.position, Vector3.up, 1, puzzleOrb))
        {
            hasOrb = true;
            Debug.Log("an orb has been detected");
        }
    }
}
