using UnityEngine;

public class coin : pickups
{
    scoreboard sc;
    void Start()
    {
        sc= FindFirstObjectByType<scoreboard>();
    }
    protected override void Onpickup()
    {
        sc.AddScore(100);
        Destroy(gameObject);
    }
}
