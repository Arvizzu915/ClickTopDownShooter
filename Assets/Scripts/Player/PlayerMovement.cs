using UnityEditor.Experimental.GraphView;
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
        Cursor.lockState = CursorLockMode.Locked;

        controls.InLevel.Enable();
        //controls.InLevel.TrackMouse.performed += ctx => mouseScreenPos = ctx.ReadValue<Vector2>();
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

        
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        Vector2 direction = ctx.ReadValue<Vector2>();
        transform.Translate(new Vector2(3.5f,3.5f)*direction*Time.deltaTime);
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
