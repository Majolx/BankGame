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

	public void CalculateLevel() {
        // Ping logic for calculating levels goes here :O
	}

    private void LevelUp()
    {

    }


    
    private void SetupPrimaryAttributes() {

	}
	
	private void SetupVitals() {

	}
	
	private void SetupSkills() {

    }

    #endregion
}
