using GuitarApp.Enums;
using GuitarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Data
{
    internal class Inventory
    {
        const int DEFAULT_STRINGS = 6;
        private List<Guitar> guitars;

        public Inventory()
        {
            guitars = new List<Guitar>();
        }

        public void AddGuitar(string serialNumber, double price, Builder builder, string model, Enums.Type guitarType, Wood backWood, Wood topWood, int numStrings)
        {
            GuitarSpec spec = new GuitarSpec(builder, model, guitarType, backWood, topWood, numStrings);
            Guitar guitar = new Guitar(serialNumber, price, spec);
            guitars.Add(guitar);
        }

        public Guitar GetGuitar(string serialNumber)
        {
            foreach (Guitar guitar in guitars)
            {
                if (guitar.GetSerialNumber() == serialNumber)
                {
                    return guitar;
                }
            }
            return null; 
        }

        public List<Guitar> Search(GuitarSpec searchSpec)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();
            foreach (Guitar guitar in guitars)
            {
                if (Matches(guitar.GetSpec(), searchSpec))
                {
                    matchingGuitars.Add(guitar);
                }
            }
            return matchingGuitars;
        }

        private bool Matches(GuitarSpec guitarSpec, GuitarSpec searchSpec)
        {
            if (searchSpec.Builder != Builder.ANY && searchSpec.Builder != guitarSpec.Builder)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(searchSpec.Model) && searchSpec.Model != guitarSpec.Model)
            {
                return false;
            }
            if (searchSpec.GuitarType != Enums.Type.ACOUSTIC && searchSpec.GuitarType != guitarSpec.GuitarType)
            {
                return false;
            }
            if (searchSpec.BackWood != Wood.INDIAN_ROSEWOOD && searchSpec.BackWood != guitarSpec.BackWood)
            {
                return false;
            }
            if (searchSpec.TopWood != Wood.INDIAN_ROSEWOOD && searchSpec.TopWood != guitarSpec.TopWood)
            {
                return false;
            }
            if (searchSpec.NumStrings > 0 && searchSpec.NumStrings != guitarSpec.NumStrings)
            {
                return false;
            }

            return true;
        }
    }
}
