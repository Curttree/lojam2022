using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public ResourceManager ribbonManager;
    public ResourceManager moneyManager;

    private int bankers;
    private int nurses;
    private int counsellors;
    private int doctors;

    [SerializeField]
    private float nurseBuff;
    [SerializeField]
    private float counsellorBuff;
    [SerializeField]
    private float doctorBuff;


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
    public int GetDoctorCount()
    {
        return doctors;
    }

    public void PurchaseDoctor(int cost)
    {
        moneyManager.IncreaseTotal(-cost);
        ribbonManager.IncreaseChance(doctorBuff);
        doctors++;
    }
    public int GetNurseCount()
    {
        return nurses;
    }
    public float GetNurseBuff()
    {
        return nurseBuff;
    }

    public void PurchaseNurse(int cost)
    {
        moneyManager.IncreaseTotal(-cost);
        nurses++;
    }
    public int GetCounsellorCount()
    {
        return counsellors;
    }

    public void PurchaseCounsellor(int cost)
    {
        moneyManager.IncreaseTotal(-cost);
        counsellors++;
    }
    public float GetCounsellorBuff()
    {
        return counsellorBuff * ribbonManager.GetTotal();
    }
}
