using System.Collections.Generic;

public class ModifiedStat : BaseStat {
	private List<ModifyingAttribute> mods;	// A list of attributes that modify this stat
	private int modValue;					// The amount added to the baseValue from the modifiers
	
	public ModifiedStat() {
		mods = new List<ModifyingAttribute>();
		modValue = 0;
	}
	
	public void addModifier( ModifyingAttribute mod ) {
		mods.Add(mod);
	}
	
	private void calculateModValue() {
		modValue = 0;
		
		if (mods.Count > 0)
			foreach(ModifyingAttribute att in mods)
				modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
	}
	
	public new int AdjustedBaseValue {
		get{ return BaseValue + BuffValue + modValue; }
	}
	 
	public void update() {
		calculateModValue();
	}
}

public struct ModifyingAttribute {
	public Attribute attribute;
	public float ratio;
}
