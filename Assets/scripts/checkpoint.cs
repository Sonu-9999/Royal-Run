using JetBrains.Annotations;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    gamemanager manager;
    void Start()
    {
        manager=FindFirstObjectByType<gamemanager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.IncreaseTime();
        }
    }
}
