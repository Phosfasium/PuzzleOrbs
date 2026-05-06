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
        //Get the mouse input with the current active camera.
        if(playerInputHandler.GrabFireOnce)
        {
            camera = Camera.allCameras[0];
            Debug.Log(Camera.allCameras[0]);
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    //check if the item has the 'Drag' tag. must be placed on all orbs. 
                    if (!hit.collider.CompareTag("Drag"))
                    {
                        return;
                    }

                    //set the SelectObject. move to 'if(selectedObject != null)
                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                //release the ball. enable collision and gravity.
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
        //TODO find out how this exactly works. it gets the location of the mouse on screen.
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
