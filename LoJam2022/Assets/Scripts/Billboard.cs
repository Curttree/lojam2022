using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : Building
{
    Marketing marketing;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        marketing = gameObject.GetComponent<Marketing>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Purchase()
    {
        if (isActive)
        {
            marketing.ClearCampaign();
            return;
        }
        base.Purchase();
    }

}
