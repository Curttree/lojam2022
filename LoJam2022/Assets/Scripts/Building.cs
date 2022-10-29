using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool isActive;
    public int cost;
    public int count;

    private SpriteRenderer sprite;

    //TODO: Remove direct reference. Have an intermediate class that can redirect to proper spot.
    public ResourceManager moneyManager;
    public PeopleManager peopleManager;

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
        if (isActive)
        {
            count++;
            return;
        }
        moneyManager.IncreaseTotal(-cost);
        isActive = true; 
        if (sprite)
        {
            sprite.enabled = isActive;
        }
    }
}
