using GuitarApp.Controller;
using GuitarApp.Enums;
using GuitarApp.Models;

namespace GuitarApp.Presentation
{
    internal class GuitarMenu
    {
        private static InventoryManager inventoryManager = new InventoryManager();

        

        public static void DisplayMenu()
        {
            bool continueMenu = true;

            while (continueMenu)
            {
                Console.WriteLine("Guitar Menu:");
                Console.WriteLine("1. Add Guitar\n"+
                    $"2. Search Guitar\n"+
                    $"3. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                MakeChoice(choice);
            }
        }
        public static void MakeChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    AddGuitar();
                    break;
                case "2":
                    SearchGuitar();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private static void AddGuitar()
        {
            Console.Write("Enter serial number: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Enter price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter builder: ");
            string builderInput = Console.ReadLine().ToUpper();
            Builder builder = GetBuilder(builderInput);

            Console.Write("Enter model: ");
            string model = Console.ReadLine();

            Console.Write("Enter type: ");
            string typeInput = Console.ReadLine().ToUpper();
            Enums.Type guitarType = GetType(typeInput);

            Console.Write("Enter back wood: ");
            string backWoodInput = Console.ReadLine().ToUpper();
            Wood backWood = GetWood(backWoodInput);

            Console.Write("Enter top wood: ");
            string topWoodInput = Console.ReadLine().ToUpper();
            Wood topWood = GetWood(topWoodInput);

            Console.Write("Enter number of strings: ");
            int numStrings = Convert.ToInt32(Console.ReadLine());

            inventoryManager.AddGuitar(serialNumber, price, builder, model, guitarType, backWood, topWood, numStrings);
            Console.WriteLine("Guitar added successfully!");
        }
        private static Builder GetBuilder(string input)
        {
            switch (input)
            {
                case "FENDER":
                    return Builder.FENDER;
                case "GIBSON":
                    return Builder.GIBSON;
                case "MARTIN":
                    return Builder.MARTIN;
                case "COLLINGS":
                    return Builder.COLLINGS;
                case "OLSON":
                    return Builder.OLSON;
                case "RYAN":
                    return Builder.RYAN;
                case "PRS":
                    return Builder.PRS;
                default:
                    return Builder.ANY;
            }
        }

        private static Enums.Type GetType(string input)
        {
            case "ELECTRIC":
                return Enums.Type.ELECTRIC;
            case "ACOUSTIC":
                return Enums.Type.ACOUSTIC;
            default:
                Console.WriteLine("Invalid guitar type, hence defaulting to acoustic");
                return Enums.Type.ACOUSTIC;
        }
        private static Wood GetWood(string input)
        {
            switch (input)
            {
                case "INDIAN_ROSEWOOD":
                    return Wood.INDIAN_ROSEWOOD;
                case "BRAZILIAN_ROSEWOOD":
                    return Wood.BRAZILIAN_ROSEWOOD;
                case "MAHOGANY":
                    return Wood.MAHOGANY;
                case "MAPLE":
                    return Wood.MAPLE;
                case "COCOBOLO":
                    return Wood.COCOBOLO;
                case "CEDAR":
                    return Wood.CEDAR;
                case "ADIRONDACK":
                    return Wood.ADIRONDACK;
                case "ALDER":
                    return Wood.ALDER;
                case "SITKA":
                    return Wood.SITKA;
                default:
                    return Wood.INDIAN_ROSEWOOD;
            }
        }
        private static void SearchGuitar()
        {
            Console.WriteLine("\nWrite builder, type, back wood, top wood values\n");

            Console.Write("Enter builder: ");
            string builderInput = Console.ReadLine().ToUpper();
            Builder builder = GetBuilder(builderInput);

            Console.Write("Enter model: ");
            string modelInput = Console.ReadLine();

            Console.Write("Enter type: ");
            string typeInput = Console.ReadLine().ToUpper();
            Enums.Type guitarType = GetType(typeInput);

            Console.Write("Enter back wood: ");
            string backWoodInput = Console.ReadLine().ToUpper();
            Wood backWood = GetWood(backWoodInput);

            Console.Write("Enter top wood: ");
            string topWoodInput = Console.ReadLine().ToUpper();
            Wood topWood = GetWood(topWoodInput);

            Console.Write("Enter number of strings: ");
            int numStrings = Convert.ToInt32(Console.ReadLine());

            GuitarSpec searchSpec = new GuitarSpec(builder, modelInput, guitarType, backWood, topWood, numStrings);
            var results = inventoryManager.Search(searchSpec);

            if (results.Count > 0)
            {
                Console.WriteLine("Guitars found:");
                foreach (var guitar in results)
                {
                    Console.WriteLine(guitar);
                }
            }
            Console.WriteLine("No guitars found matching the criteria.");
            
        }
    }
}
