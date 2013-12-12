using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BankGame
{
 public class Armor : BaseItem
 {
 #region Field Region
 ArmorLocation location;
 int defenseValue;
 int defenseModifier;
 #endregion
 #region Property Region
 public ArmorLocation Location
 {
 get { return location; }
 protected set { location = value; }
 }
 public int DefenseValue
 {
 get { return defenseValue; }
 protected set { defenseValue = value; }
 }
 public int DefenseModifier
 {
 get { return defenseModifier; }
 protected set { defenseModifier = value; }
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
     protected set { intValue = value; }
 }
 #endregion
 #region Constructor Region 
 public Armor(
 string armorName,
 string armorType,
 int price,
 float weight,
 ArmorLocation location,
 int defenseValue,
 int defenseModifier,
 int strValue,
 int dexValue,
 int intValue,
 params Type[] allowableClasses)
 : base(armorName, armorType, weight, allowableClasses)
 {
 Location = location;
 DefenseValue = defenseValue;
 DefenseModifier = defenseModifier;
 }
 #endregion
 #region Abstract Method Region
 public override object Clone()
 {
 Type[] allowedClasses = new Type[allowableClasses.Count];
 for (int i = 0; i < allowableClasses.Count; i++)
 allowedClasses[i] = allowableClasses[i];
 Armor armor = new Armor(
 Name,
 Type,
 Price,
 Weight,
 Location,
 DefenseValue,
 DefenseModifier,
 StrValue,
 DexValue,
 IntValue,
 allowedClasses);
 return armor;
 }
 public override string ToString()
 {
 string armorString = base.ToString() + ", ";
 armorString += Location.ToString() + ", ";
 armorString += DefenseValue.ToString() + ", ";
 armorString += DefenseModifier.ToString()+", ";
 armorString += StrValue.ToString()+", ";
 armorString += DexValue.ToString()+", ";
 armorString += IntValue.ToString();
 foreach (Type t in allowableClasses)
 armorString += ", " + t.Name;
 return armorString;
 }
 #endregion
 }
}
