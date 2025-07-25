
using System;
using System.Collections.Generic;

using UnityEngine;

public class levelgenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] cameracontroller cameracontrol;
    [SerializeField] GameObject chunkprefab;
    [SerializeField] Transform chunkparent;
    [Header("Game Settings")]
    [SerializeField] int numberofchunks = 12;
    [SerializeField] float chunkspeed = 7f;
    [SerializeField] float minchunkspeed = 3f;
    [SerializeField] float maxchunkspeed = 16f;
    [SerializeField] float mingravity = -20f;
    [SerializeField] float maxgravity = -6f;
    
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
    public void changemovespeed(float speed)
    {
        float movespeed = chunkspeed + speed;
        float newmovespeed= Mathf.Clamp(movespeed, minchunkspeed, maxchunkspeed);

        if (newmovespeed != chunkspeed)
        {
            chunkspeed = newmovespeed; //ensures the speed does not go below a minimum value
            float newgravity = Physics.gravity.z - speed;
            newgravity = Mathf.Clamp(newgravity, mingravity, maxgravity); 
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newgravity); //changes the gravity to match the speed of the chunks
            cameracontrol.ChangeCameraFOV(speed); //changes the camera FOV to match the speed of the chunks
        }
        
    }

    private void spawnChunk(int i)  //spawns 12 chunks at the start
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, chunkspace * i);
        GameObject chunkGO = Instantiate(chunkprefab, position, Quaternion.identity, chunkparent);
        chunks.Add(chunkGO);
        chunk newchunk = chunkGO.GetComponent<chunk>();
        newchunk.Init(this); // Initialize the chunk with the level generator reference

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
        int i = chunks.Count - 1;
        Vector3 position = new Vector3(transform.position.x, transform.position.y, chunkspace * i);
        GameObject chunkGO = Instantiate(chunkprefab, position, Quaternion.identity, chunkparent);
        chunks.Add(chunkGO);
        chunk newchunk = chunkGO.GetComponent<chunk>();
        newchunk.Init(this);
        
    }
}
