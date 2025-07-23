using UnityEngine;

public class coin : pickups
{
    protected override void Onpickup()
    {
        Debug.Log("Add 100 points");
    }
}
