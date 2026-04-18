using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class GrabSphere : MonoBehaviour
{
    
    Rigidbody rb;
    Vector3 mousePosition;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        transform.position += Vector3.up;
        rb.useGravity = false;
        Debug.Log("apple");
    }
}
