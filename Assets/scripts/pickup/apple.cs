using UnityEngine;

public class apple : pickups
{
    levelgenerator levelgen;
    public void Init(levelgenerator levelgen)
    {
        this.levelgen = levelgen;
    }
    protected override void Onpickup()
    {
        levelgen.changemovespeed(2f);
        
    }
}
