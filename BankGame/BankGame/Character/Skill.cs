public class Skill : ModifiedStat {
	private bool known;
	
	public Skill() {
		known = false;
		ExpToLevel = 25;
		LevelModifier = 1.1f;
		
	}
	
	public bool Known {
		get { return known; }
		set { known = value; }
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
	Stealth,
	TechArmor,
	LightArmor,
	MediumArmor,
	HeavyArmor,
	Cloaking
}
	
	
