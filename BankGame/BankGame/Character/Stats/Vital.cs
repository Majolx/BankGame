/// <summary>
/// A stat group which is characterized by basing part of its value on 
/// an attribute.  These are not executable skills, but they do have 
/// temporary values.
/// </summary>
public class Vital : ModifiedStat {
	private int curValue;
	
	public Vital(int baseValue, int buffValue, int curValue, string name) {
        this.BaseValue = baseValue;
        this.BuffValue = buffValue;
        this.curValue  = curValue;
        this.Name      = name;
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
	CarryCapacity
}