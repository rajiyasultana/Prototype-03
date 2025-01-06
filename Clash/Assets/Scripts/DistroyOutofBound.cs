using UnityEngine;

public class DistroyOutofBound : MonoBehaviour
{
    public float upBound = 2;
    public float downBound = -10;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.z > upBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < downBound)
        {
            Destroy(gameObject);
        }
    }
}
