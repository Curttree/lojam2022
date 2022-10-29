using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public bool isActive = true;
    public bool requiresBuilding = false;
    public Building requiredBuilding;
    public int cost;
    public bool freeFirst = false;
    //TODO: Remove direct reference. Have an intermediate class that can redirect to proper spot.
    public ResourceManager moneyManager;
    private Image image;
    private Button button;



    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        button = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (freeFirst || (!isActive && moneyManager.GetTotal() >= cost && (!requiresBuilding || requiredBuilding.isActive)))
        {
            image.color = Color.white;
            button.enabled = true;
            isActive = true;
        }
        else if (isActive && (moneyManager.GetTotal() < cost || (requiresBuilding && !requiredBuilding.isActive)))
        {
            image.color = Color.grey;
            button.enabled = false;
            isActive = false;
        }
    }
}
