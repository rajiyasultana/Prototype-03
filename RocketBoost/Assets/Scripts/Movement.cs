using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction move;
    [SerializeField] InputAction rotation;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] float rotationForce = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem rightTrustParticle;
    [SerializeField] ParticleSystem leftTrustParticle;

    Rigidbody rb;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            StartProcessMove();
        }
        else
        {
            StopProcessMove();
        }
    }
    private void StopProcessMove()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }
    private void StartProcessMove()
    {
        rb.AddRelativeForce(Vector3.up * jumpForce * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }
    private void ProcessRotation()
    {
        float rotationValue = rotation.ReadValue<float>();
        if(rotationValue < 0)
        {
            RotateRight();
        }
        else if (rotationValue > 0)
        {
            RotateLeft();
        }
        else
        {
            StopRotating();
        }
    }
    private void RotateRight()
    {
        ApplyRotation(rotationForce);
        if (!rightTrustParticle.isPlaying)
        {
            leftTrustParticle.Stop();
            rightTrustParticle.Play();
        }
    }
    private void RotateLeft()
    {
        ApplyRotation(-rotationForce);
        if (!leftTrustParticle.isPlaying)
        {
            rightTrustParticle.Stop();
            leftTrustParticle.Play();
        }
    }
    private void StopRotating()
    {
        rightTrustParticle.Stop();
        rightTrustParticle.Stop();
    }
    private void ApplyRotation(float rotateThisFram)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateThisFram * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
