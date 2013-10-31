public class Skill : ModifiedStat {
	private bool known;
    private int currentExp;
    private int totalExp;
    private int expToLevel;
    private float levelModifier;

	public Skill() {
		known         = false;
        currentExp    = 0;
        totalExp      = 0;
		expToLevel    = 100;
		levelModifier = 1.1f;	
	}

	public bool Known {
		get { return known; }
		set { known = value; }
	}

    public int ExpToLevel
    {
        get { return expToLevel; }
        set { expToLevel = value; }
    }

    public float LevelModifier
    {
        get { return levelModifier; }
        set { levelModifier = value; }
    }

    public void increaseExperience(int exp)
    {
        this.totalExp += exp;
        this.currentExp += exp;
        checkIfLevelUp();
    }

    private void checkIfLevelUp()
    {
        if (this.totalExp >= expToLevel)
            levelUp();
    }

    private void levelUp()
    {
        expToLevel  = (int)(expToLevel * levelModifier);
        currentExp = expToLevel - totalExp;
        BaseValue++;
    }
}


public enum SkillName {
	Hacking,
	Charisma,
	ReloadSpeed,
	FireRate,
	Pistol,
	SMG,
	Rifle,
	Explosives,
	Stealth
}
	
	
