using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankGame
{
    public class Inventory
    {
        #region Field Region
        readonly List<GameItem> items;
        #endregion

        #region Property Region
        public List<GameItem> Items
        {
            get { return items; }
        }
        public int Capacity
        {
            get { return items.Count; }
        }
        #endregion
        #region Constructor Region
        public Inventory()
        {
            items = new List<GameItem>();
        }
        #endregion
        #region Method Region
        public void AddItem(GameItem gameItem)
        {
            items.Add(gameItem);
        }
        public void RemoveItem(GameItem gameItem)
        {
            items.Remove(gameItem);
        }
        #endregion
    }
}