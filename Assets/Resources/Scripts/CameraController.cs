using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // Pan Properties
    [Header("Panning")]
    public float panThreshold = 16; // The number of px on each side of the screen that will count towards panning the screen
    public float panSpeed = 32; // The speed at which the camera pans

    // Rotation Properties
    [Header("Rotation")]
    public float rotationSensitivity = 90;
    public float rotationSpeed = 45; // The speed at which the camera rotates during zoom
                                    //public float rotationThreshold = 8; // The threshold at which rotation stops. larger number = more narrow range of rotation

    // Zoom Properties
    [Header("Zoom")]
    public float zoomSensitivity = 1;
    public float zoomSpeed = 1;

    private float zoom = 0.5f;
    private float zoomLerp = 0;

    public Vector3 zoomedInOrientation, zoomedOutOrientation;
    private Quaternion zoomedInRot, zoomedOutRot;
    public float zoomedInHeight, zoomedOutHeight;

    Quaternion currRot = Quaternion.identity;


    bool freeRotate = false;
    float xDeg = 0;
    float yDeg = 0;

    // Use this for initialization
    void Start()
    {
        zoomLerp = zoom;
        zoomedInRot = Quaternion.Euler(zoomedInOrientation);
        zoomedOutRot = Quaternion.Euler(zoomedOutOrientation);
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position on screen
        float cursorX = Input.mousePosition.x;
        float cursorY = Input.mousePosition.y;
        
        // Get change in position for mouse
        float deltaMouseX = Input.GetAxis("Mouse X");
        float deltaMouseY = Input.GetAxis("Mouse Y");

        // Get current orientation and translation
        currRot = transform.rotation;

        // Lock mouse to remain within screen
        Cursor.lockState = CursorLockMode.Confined;

        // Free movement w/ Middle Mouse Click
        // If middle mouse button is pressed
        if(Input.GetMouseButtonDown(1))
        {
            xDeg = transform.rotation.eulerAngles.x;
            yDeg = transform.rotation.eulerAngles.y;
            freeRotate = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            freeRotate = false;
        }

        if (freeRotate)
        {
            xDeg -= deltaMouseY * Time.deltaTime * rotationSensitivity;
            yDeg += deltaMouseX * Time.deltaTime * rotationSensitivity;
            transform.rotation = Quaternion.Euler(xDeg, yDeg, 0);
        }
        else if (Input.GetMouseButton(2))
        {
            
            // Set rotation to identity so that translation is planar
            transform.rotation = Quaternion.identity;
            // Translate camera according to mouse delta
            transform.Translate(Vector3.right * -deltaMouseX * Time.deltaTime * panSpeed);
            transform.Translate(Vector3.forward * -deltaMouseY * Time.deltaTime * panSpeed);
            // Reset Rotation to initial
            transform.rotation = currRot;
        }
        else // Control camera with either WSAD keys or moving mouse to the edge
        {
            float sprintMult = 1.0f;
            if (Input.GetKey(KeyCode.LeftControl))
            {
                sprintMult = 0.34f;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                sprintMult = 2.0f;
            }
            if (cursorX < panThreshold || Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.identity;
                transform.Translate(Vector3.right * -panSpeed * Time.deltaTime * sprintMult);
                transform.rotation = currRot;
            }
            else if (cursorX >= Screen.width - panThreshold || Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.identity;
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime * sprintMult);
                transform.rotation = currRot;
            }

            if (cursorY < panThreshold || Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.identity;
                transform.Translate(Vector3.forward * -panSpeed * Time.deltaTime * sprintMult);
                transform.rotation = currRot;
            }
            else if (cursorY >= Screen.height - panThreshold || Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.identity;
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime * sprintMult);
                transform.rotation = currRot;
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            zoom += zoomSensitivity * Time.deltaTime * -scroll;
        }
        zoom = Mathf.Clamp(zoom, 0.0f, 1.0f);

    }

    void LateUpdate()
    {
        float zoomPercent = Mathf.Clamp(Time.deltaTime * zoomSpeed, 0.0f, 1.0f);
        zoomLerp = Mathf.Lerp(zoomLerp, zoom, zoomPercent);
        if (!freeRotate)
        {
            transform.rotation = Quaternion.Slerp(zoomedInRot, zoomedOutRot, zoomLerp);
        }
        Vector3 hpos = transform.position;
        hpos.y = Mathf.Lerp(zoomedInHeight, zoomedOutHeight, zoomLerp);
        hpos.z += (zoom - zoomLerp) * zoomSensitivity * Time.deltaTime;
        transform.position = hpos;

    }
}
