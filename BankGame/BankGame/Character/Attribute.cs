/// <summary>
/// An attribute is a stat type that is influenced
/// purely by its own modifiers and is therefore
/// not dependent on other statistics.
/// </summary>
public class Attribute : BaseStat {
	
	public Attribute() {

	}
}

public enum AttributeName {
	Strength,
	Dexterity,
	Intelligence
}

