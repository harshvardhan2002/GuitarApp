using GuitarApp.Data;
using GuitarApp.Enums;
using GuitarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Controller
{
    internal class InventoryManager
    {
        private Inventory inventory;

        public InventoryManager()
        {
            inventory = new Inventory();
        }
        public void AddGuitar(string serialNumber, double price, Builder builder, string model, Enums.Type guitarType, Wood backWood, Wood topWood, int numStrings)
        {
            inventory.AddGuitar(serialNumber, price, builder, model, guitarType, backWood, topWood, numStrings);
        }
        public Guitar GetGuitar(string serialNumber)
        {
            return inventory.GetGuitar(serialNumber);
        }
        public List<Guitar> Search(GuitarSpec searchSpec)
        {
            return inventory.Search(searchSpec);
        }
    }
}
