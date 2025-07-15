
using System.Collections.Generic;

using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject chunkprefab;
    [SerializeField] int numberofchunks = 12;
    [SerializeField] Transform chunkparent;
    [SerializeField] float chunkspeed = 5f;
    //GameObject[] chunks = new GameObject[12];
    List<GameObject> chunks = new List<GameObject>();
    float chunkspace = 10f;
    void Start()
    {
        for (int i = 0; i < numberofchunks; i++)
        {
            spawnChunk(i);
        }

    }
    private void Update()
    {
        movechunk();
    }

    private void spawnChunk(int i)  //spawns 12 chunks at the start
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, chunkspace * i);
        GameObject chunk = Instantiate(chunkprefab, position, Quaternion.identity, chunkparent);
        chunks.Add(chunk);
    }
    private void movechunk()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (chunkspeed * Time.deltaTime));
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkspace)
            {
                chunks.Remove(chunk);  //removes the chunk from the list
                Destroy(chunk);
                GenerateChunk();
            }

        }
    }
    private void GenerateChunk()  // spawns a new chunk when the last one is destroyed
    {
        int i = chunks.Count-1;
        Vector3 position = new Vector3(transform.position.x, transform.position.y, chunkspace * i);
        GameObject chunk = Instantiate(chunkprefab, position, Quaternion.identity, chunkparent);
        chunks.Add(chunk);
        
    }
}
