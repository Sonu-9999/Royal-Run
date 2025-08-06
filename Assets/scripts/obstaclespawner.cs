using System.Collections;
using UnityEngine;

public class obstaclespawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnrange = 4f;
    
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]; // Randomly select an obstacle prefab
            Vector3 spawnPosition= new Vector3( Random.Range(-spawnrange, spawnrange), 2, Random.Range(45, 60));
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation,obstacleParent);
            
        }
    }
}
