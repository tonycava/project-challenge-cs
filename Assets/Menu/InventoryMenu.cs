using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using Game.EntityHandler.Items;

namespace Game.EntityHandler.Menu
{
    public class InventoryMenu
    {
        public Equipment[] inventory;
        
        public InventoryMenu()
        {
            inventory = new Equipment[9];
        }

        public void AddItem(Equipment item)
        {
            inventory[9 - InventorySpace()] = item;
            
        }

        public int InventorySpace()
        {
            int total = inventory.Length;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null) total--;
            }
            return total;
        }

        public void RemoveItem(Equipment item)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == item) inventory[i] = null;
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null) continue;
            }
        }
    }

}

