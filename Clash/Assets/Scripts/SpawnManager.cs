using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefebs;
    public float spawnRangeX = 20;
    public float spawnPosZ = 20;

    void Start()
    {
        
    }

    void Update()
    {
        int enemyIndex = Random.Range(0, enemyPrefebs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.16f, spawnPosZ);
        if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(enemyPrefebs[enemyIndex], spawnPos, enemyPrefebs[enemyIndex].transform.rotation);
        }
    }
}
