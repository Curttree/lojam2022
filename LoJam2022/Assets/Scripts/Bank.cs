using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : Building
{
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        base.Start(); 
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Purchase()
    {
        base.Purchase();
        StartCoroutine(CollectInterest());
    }

    IEnumerator CollectInterest()
    {
        for (; ; )
        {
            //TODO: Check to see how many bankers exist.
            float interest = moneyManager.GetTotal() * 0.01f;
            interest += peopleManager.GetBankerCount() * 0.05f;
            moneyManager.IncreaseTotal(interest); 
            m_Animator.SetTrigger("Active");
            yield return new WaitForSeconds(6f);
        }
    }
}
