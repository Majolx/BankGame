#region Using Statements
using System.Collections.Generic;
using System;					// Added to access the enum class
#endregion

/// <summary>
/// The BaseCharacter class provides fields and methods for
/// every type of character entity in the game, both player
/// and computer controlled.
/// </summary>
/// <remarks>
/// This class should provide a base for each character entity.
/// Because of this, only place fields and methods here which
/// would be applicable for every character.
/// </remarks>
public class BaseCharacter
{

    #region Fields

    private string name;
	private int level;
	private uint freeExp; // We use uint instead of int because we won't
                          // be dealing with negative experience values.
	
	private Attribute[] primaryAttribute;
	private Vital[] vital;
	private Skill[] skill;

    private int expToLevel;
    private float levelModifier;

    //private List<Buff> buffs;
    //private List<Consumable> inventory;
    //private List<WearableItem> equipment;

    #endregion

    #region Properties


    public string Name { get; set; }

    public int Level { get; set; }

    /// <summary>
    /// The amount of free experience 
    /// </summary>
    public uint FreeExp { get; set; }


    #endregion

    public BaseCharacter()
    {

        name    = string.Empty;
        level   = 0;
        freeExp = 0;
        expToLevel = 100;
        levelModifier = 1.1f;

        primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        vital            = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        skill            = new Skill[Enum.GetValues(typeof(SkillName)).Length];
    }

    #region Experience and Leveling


    public void AddExp(uint exp)
    {
        freeExp += exp;
        CalculateLevel();
    }


    /// <summary>
    /// Calculates the amount of experience needed to level

    /// </summary>
    private int calculateExpToLevel()
    {
        return (int)(expToLevel * levelModifier);
    }

	public void CalculateLevel() 
    {
        if (freeExp >= calculateExpToLevel())
            LevelUp();
        
	}

    private void LevelUp()
    {
        expToLevel = calculateExpToLevel();
        level++;
    }
 
    private void SetupPrimaryAttributes() {

	}
	
	private void SetupVitals() {

	}
	
	private void SetupSkills() {

    }

    #endregion
}
