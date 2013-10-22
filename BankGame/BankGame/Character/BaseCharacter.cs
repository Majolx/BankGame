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

    
    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public uint FreeExp
    {
        get { return freeExp; }
        set { freeExp = value; }
    }

    public void addExp(uint exp)
    {
        freeExp += exp;
        calculateLevel();
    }


    #endregion
    public void Awake() {
		name = string.Empty;
		level = 0;
		freeExp = 0;
		
		primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
		skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	/// <summary>
	/// 
	/// </summary>
	void Update () {
	
	}
	
	// Take the average of all of the player's skills and assign it as the player level.
	public void calculateLevel() {
		
	}
	
	private void setupPrimaryAttributes() {
	}
	
	private void setupVitals() {
	}
	
	private void setupSkills() {
	}
	
}
