public class BaseStat {
	private int baseValue;			// The base value of this stat
	private int buffValue;			// The amount of buff to this stat
	private int expToLevel;			// The total amount of exp needed to raise this skill
	private float levelModifier;	// The modifier aplied to the exp needed to raise this skill
	
	public BaseStat() {
		baseValue = 0;
		buffValue = 0;
		expToLevel = 100;
		levelModifier = 1.1f;
	}
	
	#region Getters and Setters
	public int BaseValue         { get{ return baseValue;     } set{ baseValue = value; } }
	public int BuffValue         { get{ return buffValue;     } set{ buffValue = value; } }
	public int ExpToLevel        { get{ return expToLevel;    } set{ expToLevel = value; } }
	public float LevelModifier   { get{ return levelModifier; } set{ levelModifier = value; } }
	public int AdjustedBaseValue { get{ return baseValue + buffValue;} }
	#endregion
	
	private int calculateExpToLevel() { return (int)(expToLevel * levelModifier); }
	
	public void levelUp() { 
		expToLevel = calculateExpToLevel();
		baseValue++;
	}
	

}
