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
    private string className;
	private int level;
    private int strValue;
    private int dexValue;
    private int intValue; 
	private uint freeExp; // We use uint instead of int because we won't
                          // be dealing with negative experience values.
	
	private Attribute[] attributes;
	private Vital[] vitals;
	private Skill[] skills;
    private Ability[] abilities;

    private int expToLevel;
    private float levelModifier;

    protected GameItem head;
    protected GameItem body;
    protected GameItem hands;
    protected GameItem feet;

    //private List<Buff> buffs;
    //private List<Consumable> inventory;
    //private List<WearableItem> equipment;

    #endregion

    #region Properties


    public string Name { get; set; }
    public string ClassName { get; set; }
    public int Level { get; set; }

    /// <summary>
    /// The amount of free experience.
    /// </summary>
    public uint FreeExp { get; set; }

    // Armor properties
    public GameItem Helm
    {
        get { return helm; }
    }
    public GameItem Chest
    {
        get { return chest; }
    }
    public GameItem Gloves
    {
        get { return gloves; }
    }
    public GameItem Feet
    {
        get { return feet; }
    }
    // Weapon/Shield properties
    public GameItem MainHand
    {
        get { return mainHand; }
    }

    #endregion

    public BaseCharacter()
    {
        // Initialize data members to default values
        name          = string.Empty;
        className  = string.Empty;
        level         = 0;
        freeExp       = 0;
        strValue = 0;
        dexValue = 0;
        intValue = 0;
        expToLevel    = 100;
        levelModifier = 1.1f;

        // Initialize the arrays of stats and items
        attributes        = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        vitals            = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        skills            = new Skill[Enum.GetValues(typeof(SkillName)).Length];
        abilities         = new Ability[Enum.GetValues(typeof(AbilityName)).Length];

        SetupAttributes();
        SetupVitals();
        SetupSkills();
        SetupAbilities();


        
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


    /// <summary>
    /// A check to see if the character has earned enough
    /// experience to level up.
    /// </summary>
	public void CalculateLevel() 
    {
        if (freeExp >= calculateExpToLevel())
            LevelUp();
        
	}


    /// <summary>
    /// Levels up the character.
    /// </summary>
    private void LevelUp()
    {
        expToLevel = calculateExpToLevel();
        level++;
    }
 

    /// <summary>
    /// Initializes the attributes for this character.
    /// </summary>
    private void SetupAttributes() 
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i] = new Attribute(1, 0, Enum.GetName(typeof(AttributeName), i));
        }
	}
	

    /// <summary>
    /// Initializes the vitals for this character.
    /// </summary>
	private void SetupVitals() 
    {
        for (int i = 0; i < vitals.Length; i++)
        {
            vitals[i] = new Vital(50, 0, 50, Enum.GetName(typeof(VitalName), i));
        }
	}
	

    /// <summary>
    /// Initializes the skills for this character.
    /// </summary>
	private void SetupSkills()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i] = new Skill(Enum.GetName(typeof(SkillName), i));
        }
    }


    /// <summary>
    /// Initializes the abilities for this character.
    /// </summary>
    private void SetupAbilities()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            abilities[i] = new Ability(1, 0, Enum.GetName(typeof(AbilityName), i));
        }
    }


    #endregion
    #region Equip/Unequip
    public bool Equip(GameItem gameItem)
    {
        bool success = false;
        return success;
    }
    public bool Unequip(GameItem gameItem)
    {
        bool success = false;
        return success;
    }
    #endregion
}
