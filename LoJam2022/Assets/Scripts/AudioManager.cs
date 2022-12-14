using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour, IObserver
{
    [SerializeField]
    private AudioSource bg;
    [SerializeField]
    private AudioSource achievement;
    [SerializeField]
    private AudioSource click;
    [SerializeField]
    private AudioSource locked;
    [SerializeField]
    private AudioSource ribbonSuccess;
    [SerializeField]
    private AudioSource ribbonFail;
    bool shouldMute = true;
    public Image muteButton;
    public Sprite muteButtonMuted;
    public Sprite muteButtonActive;

    public void onNotify(eEvent triggeredEvent)
    {
        switch (triggeredEvent)
        {
            case eEvent.ClickRibbon:
                click.Play();
                break;
            case eEvent.RibbonSuccess:
                ribbonSuccess.Play();
                break;
            case eEvent.RibbonFail:
                ribbonFail.Play();
                break;
            case eEvent.AchievementUnlocked:
                achievement.Play();
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMute()
    {
        if (shouldMute)
        {
            muteButton.sprite = muteButtonMuted;
        }
        else
        {
            muteButton.sprite = muteButtonActive;
        }
        bg.mute = shouldMute;
        achievement.mute = shouldMute;
        click.mute = shouldMute;
        locked.mute = shouldMute;
        ribbonSuccess.mute = shouldMute;
        ribbonFail.mute = shouldMute;
        shouldMute = !shouldMute;
    }
    public void ModifyVolume(float value)
    {
        bg.volume += value;
        achievement.volume += value;
        click.volume += value;
        locked.volume += value;
        ribbonSuccess.volume += value;
        ribbonFail.volume += value;
    }
}
