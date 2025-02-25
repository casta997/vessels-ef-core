using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VesselManagementData;
using VesselManagementData.Models;

namespace VesselManagementLogic.Services
{
    public class MenuService
    {
        private static VesselService vesselService = new VesselService();
        private static OwnerService ownerService = new OwnerService();
        private static VesselManagemetContext context = new VesselManagemetContext();

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

        public bool CheckImoNumber(string userInput)
        {
            string pattern = @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]+";
            bool checkRegex = Regex.IsMatch(userInput, pattern);

            if (userInput.Length >= 1 && checkRegex == false && userInput != null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid input! At least one charachter and no special characters!");
                WaitUserInput();
                return true;
            }
        }

        public bool CheckIdOwner(string userInput)
        {
            if (userInput.Contains("NO"))
            {
                return false;
            }
            else
            {
                bool idToConvert = int.TryParse(userInput, out int idParsed);

                if (idToConvert)
                {
                    var ownerFound = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                    if (ownerFound != null)
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nOwner not found!");
                        WaitUserInput();
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input!");
                    WaitUserInput();
                    return true;
                };
            }
        }

        public void ShowDbState()
        {
            Console.Clear();

            Console.WriteLine("Db state\n\nList of owners:\n");
            context.Owners.ToList().ForEach(owner => Console.WriteLine($"ID: {owner.Id}\tFIRST NAME: {owner.FirstName}\tLAST NAME: {owner.LastName}"));
            
            Console.WriteLine("\n\nList of vessels:\n");
            context.Vessels.ToList().ForEach(vessel => Console.WriteLine($"ID: {vessel.Id}\tIMO NUMBER: {vessel.ImoNumber}\tOWNER: {vessel.OwnerId}"));

            WaitUserInput();   
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

                Console.Write("\nSelect action: ");
                string actionSelected = Console.ReadLine().ToUpper().Trim().Replace(" ", "");

                Console.Clear();

                switch (actionSelected)
                {
                    case "CV":
                        vesselService.Create();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "CO":
                        ownerService.Create();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "RV":
                        vesselService.Read();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "RO":
                        ownerService.Read();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "UV":
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "UO":
                        ownerService.Update();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "DV":
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "DO":
                        ownerService.Delete();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "A":
                        WaitUserInput();
                        ShowDbState();
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
