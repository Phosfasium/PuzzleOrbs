using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class MouseMovement : MonoBehaviour
{
    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        transform.position += Vector3.up;
        rb.useGravity = false;
        Debug.Log("apple");
    }

    private void OnMouseDrag()
    {
        if (rb.useGravity == false)
        {

        }
    }
}
