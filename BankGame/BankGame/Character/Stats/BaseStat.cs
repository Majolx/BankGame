/// <summary>
/// Provides a foundation for all statistics represented
/// in the game.  It includes a base value, a buff or
/// bonus value, the amount of experience needed to level,
/// and a modifier float to alter the amount of experience
/// needed to level.
/// </summary>
public class BaseStat
{

    #region Fields

    private int baseValue;			// The base value of this stat
	private int buffValue;			// The amount of buff to this stat
    private string name;            // The name of the stat

    #endregion

    #region Properties

    /// <summary>
    /// The base, or unmodified, value of this stat.
    /// </summary>
    protected int BaseValue
    {
        get { return baseValue; }
        set { baseValue = value; }
    }

    /// <summary>
    /// The buff value to be added to the base value of this stat.
    /// </summary>
    protected int BuffValue
    {
        get { return buffValue; }
        set { buffValue = value; }
    }

    /// <summary>
    /// The combined value of this stat's base and buff values.
    /// </summary>
    public int AdjustedBaseValue
    {
        get { return baseValue + buffValue; }
    }

    /// <summary>
    /// The name of this stat.
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    #endregion

    #region Initialization

    /// <summary>
    /// Constructor for the base stat.
    /// </summary>
    public BaseStat() 
    {
	}

    #endregion

    #region Public Methods


    /// <summary>
    /// Levels up this stat.
    /// </summary>
    public void levelUp()
    {
        baseValue++;
    }


    #endregion
}