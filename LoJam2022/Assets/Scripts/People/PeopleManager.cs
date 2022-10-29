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
    private int orderInLayer = 2;
    private bool FirstDoorToDoor = true;

    [SerializeField]
    private float doorToDoorPassive;
    [SerializeField]
    private float nurseBuff;
    [SerializeField]
    private float counsellorBuff;
    [SerializeField]
    private float doctorBuff;
    [SerializeField]
    private List<GameObject> people;
    [SerializeField]
    private UpgradeButton doorTodoorUpgrade;


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

    public void DoorToDoor(int cost)
    {
        if (!FirstDoorToDoor)
        {
            moneyManager.IncreaseTotal(-cost);
        }
        else
        {
            doorTodoorUpgrade.freeFirst = false;
        }
        SpawnCharacter(-1);
        StartCoroutine(GoDoorToDoor());
    }
    IEnumerator GoDoorToDoor()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(doorToDoorPassive);
            ribbonManager.DoorToDoor(false);
        }
    }

    public void SpawnCharacter(int specificPerson = -1)
    {
        if (specificPerson >= 0 && specificPerson < people.Count)
        {
            GameObject newbie = Instantiate(people[specificPerson]);
            newbie.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            orderInLayer++;
        }
        else
        {
            GameObject newbie = Instantiate(people[Random.Range(0, people.Count)]);
            newbie.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            orderInLayer++;
        }
    }
}
