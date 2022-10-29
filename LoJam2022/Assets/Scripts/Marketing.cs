using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marketing : MonoBehaviour
{
    public float marketingCost;
    bool activeCampaign;
    private SpriteRenderer sprite;
    public Sprite empty;
    public Sprite early;
    public Sprite funds;
    public Sprite involve;
    public ResourceManager moneyManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChargeForCampaign());
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClearCampaign()
    {
        activeCampaign = false;
        sprite.sprite = empty;
    }
    public void EarlyDetectionCampaign()
    {
        activeCampaign = true;
        sprite.sprite = early;
    }
    public void FundsCampaign()
    {
        activeCampaign = true;
        sprite.sprite = funds;
    }
    public void InvolveCampaign()
    {
        activeCampaign = true;
        sprite.sprite = involve;
    }

    IEnumerator ChargeForCampaign()
    {
        for (; ; )
        {
            if (activeCampaign)
            {
                moneyManager.IncreaseTotal(moneyManager.GetTotal() > marketingCost ? -marketingCost : -moneyManager.GetTotal());
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
