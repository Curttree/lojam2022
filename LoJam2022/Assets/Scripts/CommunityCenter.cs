using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunityCenter : Building
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
        ribbonManager.IncreaseChance(peopleManager.GetCounsellorCount() * peopleManager.GetCounsellorBuff());
        StartCoroutine(CollectInterest());
    }
    public void PurchaseCounsellor()
    {
        ribbonManager.IncreaseChance(count * peopleManager.GetCounsellorBuff());
        StartCoroutine(CollectInterest());
    }
    IEnumerator CollectInterest()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(passiveClick);
            ribbonManager.PassiveClick(count);
        }
    }
}
