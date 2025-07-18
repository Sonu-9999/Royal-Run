using System.Collections.Generic;
using UnityEngine;

public class chunk : MonoBehaviour
{
    [SerializeField] GameObject fence;
    [SerializeField] float[] lanes = { -2f, 0f, 5f };
    void Start()
    {
        Spawnfence();
    }
    void Spawnfence()

    {
        List<int> availablelanes = new List<int> { 0, 1, 2 };
        int fencestospawn = Random.Range(0, lanes.Length); // Randomly choose how many fences to spawn (0 to 2)
        {
            for (int i = 0; i < fencestospawn; i++)
            {
                if(availablelanes.Count == 0) // If no lanes are available, break the loop
                {
                    break;
                }
                int randomlane = Random.Range(0, availablelanes.Count); //select a random lane
                int selectedlane = availablelanes[randomlane]; //get the lane chosen by random function
                availablelanes.RemoveAt(randomlane); //remove the lane from the list so that it cannot be chosen again
                Vector3 position = new Vector3(lanes[selectedlane], transform.position.y, transform.position.z);
                Instantiate(fence, position, Quaternion.identity, this.transform); //this.transform is parent of fence
                // Set the parent of the fence to its chunk(the road)
            }
        }

    }
}
