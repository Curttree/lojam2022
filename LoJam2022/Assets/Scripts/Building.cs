using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool isActive;
    public int cost;

    private SpriteRenderer sprite;

    //TODO: Remove direct reference. Have an intermediate class that can redirect to proper spot.
    public ResourceManager moneyManager;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.enabled = isActive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Purchase()
    {
        //TODO: Add a check on the button to make sure you have enough money.
        moneyManager.IncreaseTotal(-cost);
        isActive = true; 
        if (sprite)
        {
            sprite.enabled = isActive;
        }
    }
}
