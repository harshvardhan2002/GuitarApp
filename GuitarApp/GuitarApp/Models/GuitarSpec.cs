using GuitarApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Models
{
    internal class GuitarSpec
    {
        public Builder Builder { get; set; }
        public string Model { get; set; }
        public Enums.Type GuitarType { get; set; }
        public Wood BackWood { get; set; }
        public Wood TopWood { get; set; }
        public int NumStrings { get; set; }
        public GuitarSpec(Builder builder, string model, Enums.Type guitarType, Wood backWood, Wood topWood, int numStrings)
        {
            Builder = builder;
            Model = model;
            GuitarType = guitarType;
            BackWood = backWood;
            TopWood = topWood;
            NumStrings = numStrings;
        }
    }
}
