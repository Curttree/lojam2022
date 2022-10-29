using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public ResourceManager moneyManager;

    private int bankers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetBankerCount()
    {
        return bankers;
    }

    public void PurchaseBanker(int cost)
    {
        moneyManager.IncreaseTotal(-cost);
        bankers++;
    }
}
