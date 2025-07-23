using UnityEngine;

public class apple : pickups
{
    protected override void Onpickup()
    {
        Debug.Log("power up!");
    }
}
