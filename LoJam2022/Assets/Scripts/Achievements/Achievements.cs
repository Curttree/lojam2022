using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour, IObserver
{
    [SerializeField]
    private UIManager ui;
    [SerializeField]
    List<Sprite> achievementIcons = new List<Sprite>();
    public Dictionary<eAchievement, Achievement> achievementList = new Dictionary<eAchievement, Achievement>();
    private int lifetimeClicks;
    private Subject subject = new Subject();

    //TODO: Remove direct reference. Have an intermediate class that can redirect to proper spot.
    public ResourceManager lifeManager;

    void Start()
    {
        IObserver audioManager = GameObject.FindGameObjectWithTag("AudioManager")?.GetComponent<AudioManager>();
        if (audioManager != null)
        {
            subject.AddObserver(ref audioManager);
        }

        achievementList.Add(eAchievement.TheFightHasBegun, new Achievement("The fight has just begun", achievementIcons[0], "'The willpower to keep going is the number one determinant of remission'", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.KnowledgeIsPower, new Achievement("Knowledge is power", achievementIcons[0], "'Leukemia makes up about 3.2 percent of all cancer types in the U.S.'", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.Perseverance, new Achievement("Perseverance", achievementIcons[0], "'Willpower is an important factor in the fight against Lukemia'", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.TopFundraiser, new Achievement("Top fundraiser", achievementIcons[0], "''", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.CuttingEdge, new Achievement("Cutting edge", achievementIcons[0], "'Researchers are developing targeted therapies that are better for the wellbeing of patients'", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.ABrighterTomorrow, new Achievement("A brighter tomorrow", achievementIcons[0], "'Leukemia Mortality rates have fallen by approximately 2% every year since 2009'", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.CelebritySpokesperson, new Achievement("Celebrity spokesperson", achievementIcons[0], "''", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.FundsOfFury, new Achievement("Funds of fury", achievementIcons[0], "'Donations propel life-enhancing research into blood cancer treatments'", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.Hope, new Achievement("Hope", achievementIcons[0], "'The 5-year relative survival rate for all types of leukemia is 65 percent'", "Gives passive +0.1% chance to save a life"));
        achievementList.Add(eAchievement.InspiringKindness, new Achievement("Inspiring kindness", achievementIcons[0], "''", "Gives passive +0.1% chance to save a life"));
    }

    public void onNotify(eEvent triggeredEvent)
    {
        switch (triggeredEvent)
        {
            case eEvent.ClickRibbon:
                clickAchievementProgress();
                break;
            default:
                break;
        }
    }
    
    private void clickAchievementProgress()
    {
        lifetimeClicks++;

        //Having this as an if statement in case we want to increment by more than one at a time..
        if (lifetimeClicks == 25)
        {
            Unlock(eAchievement.TheFightHasBegun);
        }
    }

    private void Unlock(eAchievement achievement)
    {
        if (!achievementList.ContainsKey(achievement))
        {
            Debug.Log($"Missing info for achievement: {achievementList[achievement].Name}");
            return;
        }
        subject.Notify(eEvent.AchievementUnlocked);
        ui.PopAchievement(achievementList[achievement]);
        //Bonus effects should go here.
        switch (achievement)
        {
            case eAchievement.TheFightHasBegun:
                lifeManager.IncreaseChance(0.1f);
                break;
            default:
                Debug.Log($"Missing effect for achievement: {achievementList[achievement].Name}");
                break;
        }
    }
}
