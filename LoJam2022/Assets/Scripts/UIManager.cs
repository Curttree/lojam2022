using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private ResourceManager fundraisingManager;

    [SerializeField]
    private TextMeshProUGUI fundraisingLabel;

    [SerializeField]
    private TextMeshProUGUI fundraisingCooldown;

    [SerializeField]
    private ResourceManager livesManager;

    [SerializeField]
    private TextMeshProUGUI livesLabel;

    [SerializeField]
    private TextMeshProUGUI livesCooldown;

    [SerializeField]
    private TextMeshProUGUI livesCurrent;

    [SerializeField]
    private TextMeshProUGUI livesTotal;

    private int DEBUG_current;
    private int DEBUG_total;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesManager.GetClicks(ref DEBUG_current, ref DEBUG_total);

        UpdateLabel(fundraisingLabel, fundraisingManager.GetTotal());
        UpdateLabel(livesLabel, livesManager.GetTotal());
        //UpdateLabel(fundraisingCooldown, fundraisingManager.GetRemainingCooldown());
        //UpdateLabel(livesCooldown, livesManager.GetRemainingCooldown());
        UpdateLabel(livesCurrent, DEBUG_current);
        UpdateLabel(livesTotal, DEBUG_total);

    }

    void UpdateLabel(TextMeshProUGUI label, float value)
    {
        label.text = value.ToString("n0");
    }
}
