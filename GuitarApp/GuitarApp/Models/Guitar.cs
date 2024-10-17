using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Models
{
    internal class Guitar
    {
        public string SerialNumber { get; }
        public double Price { get; set; }
        public GuitarSpec Spec { get; }
        public Guitar(string serialNumber, double price, GuitarSpec spec)
        {
            SerialNumber = serialNumber;
            Price = price;
            Spec = spec;
        }
        public string GetSerialNumber()
        {
            return SerialNumber;
        }
        public double GetPrice()
        {
            return Price;
        }
        public void SetPrice(double price)
        {
            Price = price;
        }
        public GuitarSpec GetSpec()
        {
            return Spec;
        }
    }
}
