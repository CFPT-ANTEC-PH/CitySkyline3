using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f; // Vitesse de déplacement de la caméra
    public float zoomSpeed = 10f; // Vitesse de zoom
    public float minZoomDistance = 2f; // Distance minimale de zoom
    public float maxZoomDistance = 20f; // Distance maximale de zoom

    public float mouseSensitivity = 2f;
    private float rotationX = 0;

    private Camera mainCamera;
    private Vector3 lastMousePosition;

    void Start()
    {
        mainCamera = Camera.main;
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        // Déplacement de la caméra avec les touches WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Zoom de la caméra avec la molette de la souris
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 zoomDirection = mainCamera.transform.forward * scrollInput * zoomSpeed * Time.deltaTime;

        Vector3 newPosition = mainCamera.transform.position + zoomDirection;
        newPosition.y = Mathf.Clamp(newPosition.y, minZoomDistance, maxZoomDistance);
        mainCamera.transform.position = newPosition;
        // Rotation de la caméra en fonction de la souris
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
