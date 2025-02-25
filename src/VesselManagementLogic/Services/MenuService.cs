using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesselManagementLogic.Services
{
    public class MenuService
    {
        public bool SelectAction()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("*** Vessel Management ***");
                Console.WriteLine("\nCreate:"+
                                    "\n\nCV.) Vessel\nCO.) Owner"+
                                    "\n\nRead:"+
                                    "\n\nRV.) Vessel\nRO.) Owner"+
                                    "\n\nUpdate:"+
                                    "\n\nUV.) Vessel\nUO.) Owner"+
                                    "\n\nDelete:"+
                                    "\n\nDV.) Vessel\nDO.) Owner"+
                                    "\n\nAssign:"+
                                    "\n\nA.) Vessel to Owner");

                Console.Write("\nSelect action: ");
                string? actionSelected = Console.ReadLine()?.ToUpper();

                Console.Clear();

                switch (actionSelected)
                {
                    case "CV":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "CO":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "RV":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "RO":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "UV":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "UO":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "DV":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "DO":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    case "A":
                        Console.WriteLine($"Action selected: {actionSelected}");
                        break;
                    default:
                        Console.WriteLine($"Action selected: {actionSelected}");
                        Console.WriteLine("\nInvalid input!");
                        break;
                }
            }
            while (true);
        }
    }
}
