using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction move;
    [SerializeField] InputAction rotation;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] float rotationForce = 100f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        move.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessMove();
        ProcessRotation();

    }

    private void ProcessMove()
    {
        if (move.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * jumpForce * Time.fixedDeltaTime);
        }
    }

    private void ProcessRotation()
    {
        float rotationValue = rotation.ReadValue<float>();
        if(rotationValue < 0)
        {
            ApplyRotation(rotationForce);
        }
        else if (rotationValue > 0)
        {
            ApplyRotation(-rotationForce);
        }
    }

    private void ApplyRotation(float rotateThisFram)
    {
        transform.Rotate(Vector3.forward * rotateThisFram * Time.fixedDeltaTime);
    }
}
