using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerCenter : Building
{
    [SerializeField]
    private float chanceIncrease;
    [SerializeField]
    private float passiveClick;
    public ResourceManager ribbonManager;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Purchase()
    {
        base.Purchase();
        ribbonManager.IncreaseChance(chanceIncrease);
        ribbonManager.clicksModifier++; 
        StartCoroutine(CollectInterest());
    }
    IEnumerator CollectInterest()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(passiveClick);
            ribbonManager.PassiveClick((int)(count + (count * peopleManager.GetNurseBuff() * peopleManager.GetNurseCount())));
        }
    }
}
