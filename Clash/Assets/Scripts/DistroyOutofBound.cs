using UnityEngine;

public class DistroyOutofBound : MonoBehaviour
{
    public float upBound = 30;
    public float downBound = -30;
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
