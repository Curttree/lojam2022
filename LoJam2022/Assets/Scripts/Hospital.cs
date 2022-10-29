using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : Building
{
    public ResourceManager ribbonManager;
    public float chanceIncrease;
    private Subject subject = new Subject();
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        IObserver ach = GameObject.FindGameObjectWithTag("Achievements")?.GetComponent<Achievements>();
        if (ach != null)
        {
            subject.AddObserver(ref ach);
        }
    }

    public override void Purchase()
    {
        base.Purchase();
        ribbonManager.IncreaseChance(chanceIncrease);
        subject.Notify(eEvent.HospitalPurchase);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
