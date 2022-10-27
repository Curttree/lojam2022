using UnityEngine;

public struct Achievement
{
    public string Name;
    public Sprite Icon;
    public string Factoid;
    public string BonusEffectDescription;
    public Achievement (string name, Sprite icon, string factoid, string bonusEffectDescription)
    {
        Name = name;
        Icon = icon;
        Factoid = factoid;
        BonusEffectDescription = bonusEffectDescription;
    }
}
