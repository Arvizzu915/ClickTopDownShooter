using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Controls controls;
    private Camera mainCamera;

    private Vector2 mouseScreenPos;

    Vector2 movementCollision= new Vector2(1,1);
    float speed = .0625f;
    public LayerMask Walls;
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
     
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        Vector2 direction = ctx.ReadValue<Vector2>();
        direction=new Vector2(Mathf.Clamp(direction.x, -100, 100), Mathf.Clamp(direction.y, -100, 100));
        if (Physics2D.Raycast(transform.position, Vector2.down, .23f, Walls)) { direction.y = Mathf.Clamp(direction.y, 0, 1); }
        if (Physics2D.Raycast(transform.position, Vector2.left, .23f, Walls)) { direction.x = Mathf.Clamp(direction.x, 0, 1); }
        if (Physics2D.Raycast(transform.position, Vector2.right, .23f, Walls)) { direction.x = Mathf.Clamp(direction.x, -1, 0); }
        if (Physics2D.Raycast(transform.position, Vector2.up, .23f, Walls)) { direction.y = Mathf.Clamp(direction.y, -1, 0); }
     
        transform.Translate(speed*direction*Time.deltaTime);
        //playerRB.AddForce(direction*speed*Time.fixedDeltaTime);
    }

    //InputActions

    
}
