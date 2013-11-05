/// <summary>
/// A stat group which is characterized by basing part of its value on
/// an attribute, but is not an executable skill nor does it have a 
/// temporary value associated with it.
/// </summary>
public class Ability : ModifiedStat
{
    public Ability(int baseValue, int buffValue, string name)
    {
        this.BaseValue = baseValue;
        this.BuffValue = buffValue;
        this.Name      = name;
    }

}

public enum AbilityName
{
    Evasion,
    Luck,
    MovementSpeed,
    Armor
}