using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using Game.EntityHandler.Items;

namespace Game.EntityHandler.Menu
{
    public class InventoryMenu
    {
        private const int _inventorySpace = 9;
        public Equipment[] Inventory;
        
        public InventoryMenu()
        {
            Inventory = new Equipment[_inventorySpace];
        }

        public void AddItem(Equipment item)
        {
            Inventory[_inventorySpace - InventorySpace()] = item;
            
        }

        public int InventorySpace()
        {
            int totalSpace = Inventory.Length;
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] != null) totalSpace--;
            }
            return totalSpace;
        }

        public void RemoveItem(Equipment item)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == item) Inventory[i] = null;
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] == null) continue;
            }
        }
    }

}

