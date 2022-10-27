using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI factoid;
    [SerializeField]
    private TextMeshProUGUI effect;

    bool active;
    float displayedTime;
    float maxDisplayTime = 5f;

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            displayedTime += Time.deltaTime;
            if (displayedTime >= maxDisplayTime)
            {
                active = false;
                for(int index = 0; index < transform.childCount; index++)
                {
                    transform.GetChild(index).gameObject.SetActive(false);
                }
            }
        }
    }

    public void PopUp(Achievement ach)
    {
        active = true;
        title.text = ach.Name;
        factoid.text = ach.Factoid;
        effect.text = ach.BonusEffectDescription;
        for (int index = 0; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(true);
        }
    }
}
