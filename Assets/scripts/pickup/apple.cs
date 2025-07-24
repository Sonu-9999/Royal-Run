using UnityEngine;

public class apple : pickups
{
    levelgenerator lg;
    void Start()
    {
        lg= FindFirstObjectByType<levelgenerator>();
    }
    protected override void Onpickup()
    {
        lg.changemovespeed(2f);
        
    }
}
