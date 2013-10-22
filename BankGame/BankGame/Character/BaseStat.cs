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
	private int expToLevel;			// The total amount of exp needed to raise this skill
	private float levelModifier;	// The modifier aplied to the exp needed to raise this skill

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
    /// The amount of experience needed to level this stat.
    /// </summary>
    protected int ExpToLevel
    {
        get { return expToLevel; }
        set { expToLevel = value; }
    }

    /// <summary>
    /// The ratio adjustment to be applied to the amount of
    /// experience needed to level this stat.
    /// </summary>
    public float LevelModifier
    {
        get { return levelModifier; }
        set { levelModifier = value; }
    }

    /// <summary>
    /// The combined value of this stat's base and buff values.
    /// </summary>
    public int AdjustedBaseValue
    {
        get { return baseValue + buffValue; }
    }


    #endregion

    #region Initialization

    /// <summary>
    /// Constructor for the base stat.
    /// </summary>
    public BaseStat() {
		baseValue = 0;
		buffValue = 0;
		expToLevel = 100;
		levelModifier = 1.1f;
	}

    #endregion

    #region Public Methods


    /// <summary>
    /// Levels up this stat.
    /// </summary>
    public void levelUp()
    {
        expToLevel = calculateExpToLevel();
        baseValue++;
    }


    #endregion

    #region Private Methods


    /// <summary>
    /// Calculates the amount of experience needed to level
    /// this stat up to the next level.
    /// </summary>
    private int calculateExpToLevel()
    {
        return (int)(expToLevel * levelModifier);
    }


    #endregion
}
