using UnityEngine;

public class DistroyOutofBound : MonoBehaviour
{
    public float upBound = 2;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.z > upBound)
        {
            Destroy(gameObject);
        }
    }
}
