using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Game1.Itemclasses
{
 public class Weapon : BaseItem
 {
 #region Field Region
 Hands hands;
 int attackValue;
 int attackModifier;
 int damageValue;
 int damageModifier;
 int strValue;
 int dexValue;
 int intValue;
 int stability;
 #endregion
 #region Property Region
 public Hands NumberHands
 {
     get { return hands; }
     protected set { hands = value; }
 }
 public int AttackValue
 {
     get { return attackValue; }
     protected set { attackValue = value; }
 }
 public int AttackModifier
 {
     get { return attackModifier; }
     protected set { attackModifier = value; }
 }
 public int DamageValue
 {
     get { return damageValue; }
     protected set { damageValue = value; }
 }
 public int DamageModifier
 {
     get { return damageModifier; }
     protected set { damageModifier = value; }
 }
 public int StrValue
 {
     get { return strValue; }
     protected set {strValue = value;}
 }
 public int DexValue
 {
     get { return DexValue; }
     protected set {dexValue = value;}
 }
 public int IntValue
 {
     get { return intValue; }
     protected set {intValue = value;}
 }
 public int Stablility
{
    get { return stablility; }
    protected set { stablility = value; }
}

 #endregion
 #region Constructor Region
 public Weapon(
 string weaponName,
 string weaponType,
 float weight,
 Hands hands,
 int attackValue,
 int attackModifier,
 int damageValue,
 int damageModifier,
 int strValue,
 int dexValue,
 int intValue,
 int stability,
 params Type[] allowableClasses) : base(weaponName, weaponType, weight, allowableClasses)
 {
 NumberHands = hands;
 AttackValue = attackValue;
 AttackModifier = attackModifier;
 DamageValue = damageValue;
 DamageModifier = damageModifier;
 StrValue =  strValue;
 DexValue =  dexValue;
 IntValue =  intValue;
 Stablility = stability;
 }
 #endregion
 #region Abstract Method Region
 public override object Clone()
 {
 Type[] allowedClasses = new Type[allowableClasses.Count];
 for (int i = 0; i < allowableClasses.Count; i++)
 allowedClasses[i] = allowableClasses[i];
 Weapon weapon = new Weapon(
 Name,
 Type,
 Weight,
 NumberHands,
 AttackValue,
 AttackModifier,
 DamageValue,
 DamageModifier,
 StrValue,
 DexValue,
 IntValue,
 Stability,
 allowedClasses);
 return weapon;
 }
 public override string ToString()
 {
 string weaponString = base.ToString() + ", ";
 weaponString += NumberHands.ToString() + ", ";
 weaponString += AttackValue.ToString() + ", ";
 weaponString += AttackModifier.ToString() + ", ";
 weaponString += DamageValue.ToString() + ", ";
 weaponString += DamageModifier.ToString()+ ",";
 weaponString += StrValue.ToString()+ ",";
 weaponString += DexValue.ToString()+ ",";
 weaponString += IntValue.ToString()+ ",";
 weaponString += Stability.ToString();

 foreach (Type t in allowableClasses)
 weaponString += ", " + t.Name;
 return base.ToString();
 }
 #endregion
 }
}
