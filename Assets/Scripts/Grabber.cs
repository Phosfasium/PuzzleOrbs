using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    private Camera camera;
    [SerializeField]
    public float BallHeight;


    void Update()
    {
        //TODO. change the getmousebuttondown to new inputsystem (see pausegame script plus firstpersoncontroller)
        if(playerInputHandler.GrabFireOnce)
        {
            camera = Camera.allCameras[0];
            Debug.Log(Camera.allCameras[0]);
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Drag"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                Vector3 position = new Vector3(playerInputHandler.TopDownMouseInput.x, playerInputHandler.TopDownMouseInput.y, camera.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = camera.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, BallHeight + 1f, worldPosition.z);
                selectedObject.GetComponent<Collider>().isTrigger = false;
                selectedObject.GetComponent<Rigidbody>().isKinematic = false;
                selectedObject = null;
                Cursor.visible = true;
            }
        }

        if(selectedObject != null)
        {
            
            Vector3 position = new Vector3(playerInputHandler.TopDownMouseInput.x, playerInputHandler.TopDownMouseInput.y, camera.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = camera.ScreenToWorldPoint(position);
            //TODO: Ballheight is a temporary solution. input the starting height of the ball there.
            selectedObject.transform.position = new Vector3(worldPosition.x, BallHeight + 1f, worldPosition.z);
            //Debug.Log(selectedObject.transform.position);
            selectedObject.GetComponent<Collider>().isTrigger = true;
            selectedObject.GetComponent<Rigidbody>().isKinematic = true;
        }
   
    }

    private RaycastHit CastRay()
    {
        Debug.Log(camera != null);
        Vector3 screenMousePosFar = new Vector3(playerInputHandler.TopDownMouseInput.x, playerInputHandler.TopDownMouseInput.y, camera.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(playerInputHandler.TopDownMouseInput.x, playerInputHandler.TopDownMouseInput.y, camera.nearClipPlane);
        Vector3 worldMousePosFar = camera.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = camera.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        Debug.Log(worldMousePosNear);
        Debug.Log(worldMousePosFar);
        Debug.Log(hit);
        
        return hit;
    }
}
