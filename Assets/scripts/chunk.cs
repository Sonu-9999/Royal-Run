using System.Collections.Generic;
using UnityEngine;

public class chunk : MonoBehaviour
{
    [SerializeField] GameObject fence;
    [SerializeField] GameObject apple;
    [SerializeField] GameObject coin;
    [SerializeField] float applespawnchance = 0.3f;
    [SerializeField] float coinsapwnchance = 0.5f;

    float[] fencelanes = { -2f, 1f, 3.7f };
    List<int> availablelanes = new List<int> { 0, 1, 2 };
    float[] pickuplanes = { -3.0f, -0.1f, 2.7f };
    float spawnspace = 2f;
    void Start()
    {
        Spawnfence();
        SpawnApple();
        SpawnCoin();

    }
    void Spawnfence()

    {

        int fencestospawn = Random.Range(0, fencelanes.Length); // Randomly choose how many fences to spawn (0 to 2)

        for (int i = 0; i < fencestospawn; i++)
        {
            if (availablelanes.Count == 0) // If no lanes are available, break the loop
            {
                break;
            }
            int selectedlane = selectlane();
            Vector3 position = new Vector3(fencelanes[selectedlane], transform.position.y, transform.position.z);
            Instantiate(fence, position, Quaternion.identity, this.transform); //this.transform is parent of fence
                                                                               // Set the parent of the fence to its chunk(the road)
        }


    }

    private int selectlane()
    {
        int randomlane = Random.Range(0, availablelanes.Count); //select a random lane
        int selectedlane = availablelanes[randomlane]; //get the lane chosen by random function
        availablelanes.RemoveAt(randomlane); //remove the lane from the list so that it cannot be chosen again
        return selectedlane;
    }

    void SpawnApple()
    {
        if (Random.value > applespawnchance) return;
        if (availablelanes.Count <= 0) return;
        int selectedlane = selectlane();
        Vector3 position = new Vector3(pickuplanes[selectedlane], transform.position.y, transform.position.z);
        Instantiate(apple, position, Quaternion.identity, this.transform);
    }
    void SpawnCoin()
    {

        if (Random.value > coinsapwnchance || availablelanes.Count <= 0) return;
        int coinstospawn = Random.Range(1, 6);
        int selectedlane = selectlane();
        float topofchunkz = transform.position.z + 5f;
        for (int i = 0; i < coinstospawn; i++)
        {
            float spawnpositionz = topofchunkz + (i * spawnspace);
            Vector3 position = new Vector3(pickuplanes[selectedlane], transform.position.y, spawnpositionz);
            Instantiate(coin, position, Quaternion.identity, this.transform);
        }

    }
}
