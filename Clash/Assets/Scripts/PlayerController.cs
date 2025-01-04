using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
