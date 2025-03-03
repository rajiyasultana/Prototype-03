using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse); 
        }
        
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
