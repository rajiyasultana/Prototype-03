using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerInputActions m_playerInputActions;
    private readonly float m_jumpForce = 5f;
    private readonly float m_moveSpeed = 10f;

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
        Vector3 input = context.ReadValue<Vector3>(); 

        m_rigidbody.velocity = new Vector3(input.x * m_moveSpeed, m_rigidbody.velocity.y, input.z * m_moveSpeed);
    }
    
}
