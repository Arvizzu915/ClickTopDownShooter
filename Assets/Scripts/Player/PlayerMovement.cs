using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Controls controls;
    private Camera mainCamera;

    private Vector2 mouseScreenPos;

    private void Awake()
    {
        controls = new Controls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.InLevel.Enable();
        controls.InLevel.TrackMouse.performed += ctx => mouseScreenPos = ctx.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        controls.InLevel.Disable();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        worldPos.z = transform.position.z;

        // Get the screen boundaries in world space
        Vector3 minScreenBounds = mainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 maxScreenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Clamp the position
        float clampedX = Mathf.Clamp(worldPos.x, minScreenBounds.x, maxScreenBounds.x);
        float clampedY = Mathf.Clamp(worldPos.y, minScreenBounds.y, maxScreenBounds.y);

        transform.position = new Vector3(clampedX, clampedY, worldPos.z);
    }

    //InputActions

    
}
