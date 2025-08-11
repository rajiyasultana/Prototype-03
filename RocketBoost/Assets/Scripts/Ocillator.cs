using UnityEngine;

public class Ocillator : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Vector3 movementVector;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float movementFactor;
    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + movementVector;
    }

    
    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPosition, endPosition, movementFactor);
    }
}
