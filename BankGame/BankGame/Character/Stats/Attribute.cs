/// <summary>
/// An attribute is a stat type that is influenced
/// purely by its own modifiers and is therefore
/// not dependent on other statistics.
/// </summary>
public class Attribute : BaseStat {
	public Attribute(int baseValue, int buffValue, string name) 
    {
        this.BaseValue = baseValue;
        this.BuffValue = buffValue;
        this.Name = name;
	}
}

public enum AttributeName {
	Strength,
	Dexterity,
	Intelligence
}

