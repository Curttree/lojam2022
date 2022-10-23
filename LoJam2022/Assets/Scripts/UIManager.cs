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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLabel(fundraisingLabel, fundraisingManager.GetTotal());
        UpdateLabel(livesLabel, livesManager.GetTotal());
        UpdateLabel(fundraisingCooldown, fundraisingManager.GetRemainingCooldown());
        UpdateLabel(livesCooldown, livesManager.GetRemainingCooldown());
    }

    void UpdateLabel(TextMeshProUGUI label, float value)
    {
        label.text = value.ToString("n0");
    }
}
