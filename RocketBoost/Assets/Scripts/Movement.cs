using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction move;
    [SerializeField] float jumpForce = 100f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        move.Enable();
    }

    private void FixedUpdate()
    {
        if (move.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * jumpForce * Time.fixedDeltaTime);
        }
    }
}
