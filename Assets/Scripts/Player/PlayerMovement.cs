using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Controls controls;
    private Camera mainCamera;

    private Vector2 mouseScreenPos;

    public WeaponHolder weaponHolder;
    public GameObject rangedWeaponPrefab;
    public GameObject meleeWeaponPrefab;

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
        if (Input.GetKeyDown(KeyCode.Alpha1))
            weaponHolder.EquipWeapon(rangedWeaponPrefab);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            weaponHolder.EquipWeapon(meleeWeaponPrefab);

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

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log(ctx.ReadValue<Vector2>());
            weaponHolder.UseWeapon(ctx.ReadValue<Vector2>());
        }
    }
}
