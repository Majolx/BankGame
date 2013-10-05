public class Vital : ModifiedStat {
	private int curValue;
	
	public Vital() {
		curValue = 0;
		ExpToLevel = 50;
		LevelModifier = 1.1f;
	}
	
	public int CurValue { 
		get{
			if (curValue > AdjustedBaseValue)
				curValue = AdjustedBaseValue;
			return curValue; 
		} 
		set{ 
			curValue = value; 
		} 
	}
	
}

public enum VitalName {
	Health,
	Energy,
	Constitution,
	Evasion,
	CarryCapacity,
	Luck,
	MovementSpeed
}