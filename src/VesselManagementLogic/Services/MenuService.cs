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

        //Method used to "pause" the program and make the user read the datas
        public void WaitUserInput()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        //Method used to check if a specific input is valid or not
        public bool CheckInput(string userInput)
        {
            //Regex that exclude certains characters (numbers and special char)
            string pattern = @"[0-9!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]+";
            bool checkRegex = Regex.IsMatch(userInput, pattern);

            //Check to see if the input is long at least 1 char and respect the regex rule
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

        //Method used to check if a specific input is valid or not
        public bool CheckImoNumber(string userInput)
        {
            //Regex that exclude certains characters (special char)
            string pattern = @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]+";
            bool checkRegex = Regex.IsMatch(userInput, pattern);

            //Check to see if the input is long at least 1 char and respect the regex rule
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

        //Method used to check the input for idOwner from the vessels table 
        public bool CheckIdOwner(string userInput)
        {
            if (userInput.Contains("NO"))
            {
                return false;
            }
            else
            {
                bool idToConvert = int.TryParse(userInput, out int idParsed);

                //Check to see if it's a valid id
                if (idToConvert)
                {
                    var ownerFound = context.Owners.FirstOrDefault(owner => owner.Id == idParsed);

                    //Check to see if exist in the db
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

        //Method used to check the input for id from the vessels table 
        public bool CheckIdVessel(string userInput)
        {
            if (userInput.Contains("NO"))
            {
                return false;
            }
            else
            {
                bool idToConvert = int.TryParse(userInput, out int idParsed);

                //Check to see if it's a valid id
                if (idToConvert)
                {
                    var vesselFound = context.Vessels.FirstOrDefault(vessel => vessel.Id == idParsed);

                    //Check to see if exist in the db
                    if (vesselFound != null)
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nVessel not found!");
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

        //Method used to print the status of the db
        public void ShowDbState()
        {
            Console.Clear();

            Console.WriteLine("Status database");
            vesselService.PrintTable();
            ownerService.PrintTable();

            WaitUserInput();   
        }

        //Method used to handle the menu logic
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
                string actionSelected = Console.ReadLine().ToUpper().Replace(" ", "");

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
                        vesselService.PrintTable();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "RO":
                        ownerService.PrintTable();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "UV":
                        vesselService.Update();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "UO":
                        ownerService.Update();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "DV":
                        vesselService.Delete();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "DO":
                        ownerService.Delete();
                        WaitUserInput();
                        ShowDbState();
                        break;
                    case "A":
                        ownerService.AssignVessel();
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
