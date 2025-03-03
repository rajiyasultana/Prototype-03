using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = System.Numerics.Vector2;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerInputActions m_playerInputActions;
    private readonly float m_jumpForce = 5f;
    private readonly float m_moveSpeed = 5f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        
        m_playerInputActions = new PlayerInputActions();
        m_playerInputActions.Player.Enable();
        
        m_playerInputActions.Player.Jump.performed += Jump;
        m_playerInputActions.Player.Move.performed += Move;
    }

    private void OnDestroy()
    {
        m_playerInputActions.Player.Jump.performed -= Jump;
        m_playerInputActions.Player.Move.performed -= Move;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse); 
        }
        
    }

    private void Move(InputAction.CallbackContext context)
    {
        Vector3 input = context.ReadValue<Vector3>(); // ✅ Correctly reading Vector3

        m_rigidbody.velocity = new Vector3(input.x * m_moveSpeed, m_rigidbody.velocity.y, input.z * m_moveSpeed);
    }
    /*public float horizontalInput;
    public float speed = 8;
    public float xRange = 12;

    public GameObject projectilePrefeb;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput *  Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Lunch a projectile from the player.
            Instantiate(projectilePrefeb, transform.position, projectilePrefeb.transform.rotation);
        }
    }*/
}
