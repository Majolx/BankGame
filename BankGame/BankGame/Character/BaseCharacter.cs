using UnityEngine;
using System.Collections;
using System;					// Added to access the enum class

public class BaseCharacter : MonoBehaviour {
	private string name;
	private int level;
	private uint freeExp;
	
	private Attribute[] primaryAttribute;
	private Vital[] vital;
	private Skill[] skill;
	
	private List<Buff> buffs;
	
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
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public string Name {
		get{ return name; }
		set{ name = value; }
	}
	
	public int Level {
		get{ return level; }
		set{ level = value; }
	}
	
	public uint FreeExp {
		get{ return freeExp; }
		set{ freeExp = value; }
	}
	
	public void addExp(uint exp) {
		freeExp += exp;
		calculateLevel();
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
