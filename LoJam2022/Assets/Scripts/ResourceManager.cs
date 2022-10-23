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

    private float totalScore;
    private float remainingCooldown = 0;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void ActivePress()
    {
        if (remainingCooldown > 0f)
        {
            return;
        }
        remainingCooldown = cooldown;
        float roll = Random.Range(0.1f, 1f);
        if (roll <= percentageChangeToIncrease / 100f )
        {
            Debug.Log("Successful Roll");
            totalScore += gainPerInteraction;
        }
        else
        {
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
