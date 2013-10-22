#region Using Statements
using System.Collections.Generic;
#endregion

/// <summary>
/// A modified stat is a statistic which has its values
/// modified by an Attribute.  Methods are added to
/// alter the value of the modified stat using an
/// Attribute.
/// </summary>
public class ModifiedStat : BaseStat
{

    #region Properties

    private List<ModifyingAttribute> mods;	// A list of attributes that modify this stat
	private int modValue;					// The amount added to the baseValue from the modifiers

    #endregion

    #region Initialization


    public ModifiedStat() {
		mods = new List<ModifyingAttribute>();
		modValue = 0;
	}


    #endregion

    #region Public Methods

    /// <summary>
    /// Adds an attribute which modifies this statistic.
    /// </summary>
    public void addModifier( ModifyingAttribute mod ) {
		mods.Add(mod);
	}
	
    /// <summary>
    /// Returns the value of this statistic after all
    /// values are taken together.
    /// </summary>
	public new int AdjustedBaseValue {
		get{ return BaseValue + BuffValue + modValue; }
	}
	
    /// <summary>
    /// Updates the value of this statistic.
    /// </summary>
	public void update() {
		calculateModValue();
	}


    #endregion

    #region Private Methods

    /// <summary>
    /// Calculates the modifier value by adding together all the bonus
    /// values given by its attributes.
    /// </summary>
    private void calculateModValue()
    {
        modValue = 0;

        if (mods.Count > 0)
            foreach (ModifyingAttribute att in mods)
                modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
    }

    #endregion
}


/// <summary>
/// Combines an attribute with a ratio used to find how much
/// of the attribute will be given to this modified stat value.
/// </summary>
public struct ModifyingAttribute {
	public Attribute attribute;
	public float ratio;
}
