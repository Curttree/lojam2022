using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private string label;

    [SerializeField]
    private float passiveGainPerSecond;

    [SerializeField]
    private float gainPerInteraction;

    [SerializeField]
    private float cooldown;

    [SerializeField]
    private float percentageChangeToIncrease;

    [SerializeField]
    private int clicksToRedeem;

    private Subject subject = new Subject();

    [SerializeField]
    private float totalScore;
    private float remainingCooldown = 0;
    private int currentClicks = 0;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        IObserver audioManager = GameObject.FindGameObjectWithTag("AudioManager")?.GetComponent<AudioManager>();
        if (audioManager != null)
        {
            subject.AddObserver(ref audioManager);
        }

        IObserver ach = GameObject.FindGameObjectWithTag("Achievements")?.GetComponent<Achievements>();
        if (ach != null)
        {
            subject.AddObserver(ref ach);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePassiveScore();
        UpdateCooldown();
    }

    public string GetLabel()
    {
        return label;
    }

    public float GetRemainingCooldown()
    {
        return remainingCooldown;
    }

    public float GetTotal()
    {
        return totalScore;
    }

    public void IncreaseChance(float increment)
    {
        percentageChangeToIncrease += increment;
    }
    public void IncreaseTotal(float increment)
    {
        totalScore += increment;
    }
    public void GetClicks(ref int current, ref int total)
    {
        current = currentClicks;
        total = clicksToRedeem;
    }

    public void ActivePress()
    {
        if (remainingCooldown > 0f)
        {
            return;
        }
        subject.Notify(eEvent.ClickRibbon);
        if (currentClicks < clicksToRedeem)
        {
            currentClicks++;
            if (currentClicks < clicksToRedeem)
            {
                //Still less..return.
                return;
            }
        }
        currentClicks = 0;
        remainingCooldown = cooldown;
        float roll = Random.Range(0f, 1f);
        if (roll <= percentageChangeToIncrease / 100f )
        {
            Debug.Log("Successful Roll");
            subject.Notify(eEvent.RibbonSuccess);
            totalScore += gainPerInteraction;
        }
        else
        {
            subject.Notify(eEvent.RibbonFail);
            Debug.Log("Unsuccessful Roll");
        }
    }

    private void UpdateCooldown()
    {
        if (remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;

            //Check to see if our cooldown has expired. If so, determine if a resource should be granted and set cooldown to 0.
            if (remainingCooldown <= 0)
            {
                remainingCooldown = 0;
            }
        }
    }

    private void UpdatePassiveScore()
    {
        totalScore += passiveGainPerSecond * Time.deltaTime;
    }
    
}
