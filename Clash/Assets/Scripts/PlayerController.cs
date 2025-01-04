using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
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
    }
}
