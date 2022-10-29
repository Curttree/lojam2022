using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : Building
{
    public ResourceManager ribbonManager;
    public float chanceIncrease;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    public override void Purchase()
    {
        base.Purchase();
        ribbonManager.IncreaseChance(chanceIncrease);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
