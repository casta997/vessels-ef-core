using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VesselManagementLogic.Services
{
    public class MenuService
    {
        private static OwnerService ownerService = new OwnerService();

        public void WaitUserInput()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        public bool CheckInput(string userInput)
        {
            string pattern = @"[0-9!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]+";
            bool checkRegex = Regex.IsMatch(userInput, pattern);

            if (userInput.Length >= 1 && checkRegex == false && userInput != null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid input! At least one charachter, no numbers and no special characters!");
                WaitUserInput();
                return true;
            }
        }

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
                                    "\n\nA.) Vessel to Owner\n");

                ownerService.Read();

                Console.Write("\nSelect action: ");
                string actionSelected = Console.ReadLine().ToUpper().Trim().Replace(" ", "");

                Console.Clear();

                switch (actionSelected)
                {
                    case "CV":
                        break;
                    case "CO":
                        ownerService.Create();
                        WaitUserInput();
                        break;
                    case "RV":
                        break;
                    case "RO":
                        ownerService.Read();
                        WaitUserInput();
                        break;
                    case "UV":
                        break;
                    case "UO":
                        ownerService.Update();
                        WaitUserInput();
                        break;
                    case "DV":
                        break;
                    case "DO":
                        ownerService.Delete();
                        WaitUserInput();
                        break;
                    case "A":
                        break;
                    default:
                        Console.WriteLine("\nInvalid input!");
                        WaitUserInput();
                        break;
                }
            }
            while (true);
        }
    }
}
