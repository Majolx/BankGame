using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BankGame
{
 public enum Hands { One, Two }
 public enum ArmorLocation { Chest, Helm, Gloves, Feet }
 public abstract class BaseItem
 {
 #region Field Region
 protected List<Type> allowableClasses = new List<Type>();
 string name;
 string type;
 float weight;
 bool isEquipped;
 #endregion
 #region Property Region
 public List<Type> AllowableClasses
 {
 get { return allowableClasses; }
 protected set { allowableClasses = value; }
 }
 public string Type
 {
 get { return type; }
 protected set { type = value; }
 }
 public string Name
 {
 get { return name; }
 protected set { name = value; }
 }
 public float Weight
 {
 get { return weight; }
 protected set { weight = value; }
 }
 public bool IsEquipped
 {
 get { return isEquipped; }
 protected set { isEquipped = value; }
 }
 #endregion
 #region Constructor Region
 public BaseItem(string name, string type, float weight, params Type[] allowableClasses)
 {
 foreach (Type t in allowableClasses)
 AllowableClasses.Add(t);
 Name = name;
 Type = type;
 Weight = weight;
 IsEquipped = false;
 }
 #endregion
 #region Abstract Method Region
 public abstract object Clone();
 public virtual bool CanEquip(Type characterType)
 {
 return allowableClasses.Contains(characterType);
 }
 public override string ToString()
 {
 string itemString = "";
 itemString += Name + ", ";
 itemString += Type + ", ";
 itemString += Weight.ToString();
 return itemString;
 }
 #endregion
 }
}