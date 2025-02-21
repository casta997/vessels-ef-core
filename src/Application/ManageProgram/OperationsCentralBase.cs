using Application.DBContext;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ManageProgram
{
    internal class OperationsCentralBase
    {
        private readonly ManageVesselContext db;
        public OperationsCentralBase() 
        {
            db = new ManageVesselContext();
        }

        /**
         * private methods for vessel
         */

        private Vessel createVessel() 
        {
            var imoNumber = insertImoNumber();

            return new Vessel()
            {
                ImoNumber = imoNumber
            }; 
        }

        private string insertImoNumber()
        {
            var imoNumber = "";
            var msgConsole = "";
            var existImoNumber = false;
            while (!existImoNumber)
            {
                Console.Clear();
                Console.WriteLine("Insert IMO Number of the vessel:");
                msgConsole = Console.ReadLine();

                if (msgConsole.Trim().Length != 0)
                {
                    imoNumber = msgConsole;
                    existImoNumber = true;
                } else
                {
                    Console.WriteLine("IMO Number is a required field!");
                    Console.Write("Press any key to continue... ");
                    Console.ReadKey();
                }
            }
            
            return imoNumber;
        }

        private List<Vessel> getVessels()
        {
            var vessels = db.Vessels.ToList();
            return vessels;
        }

        /**
         * private methods for owner
         */
        private Owner createOwner()
        {
            var firstName = insertFirstName();
            var lastName = insertLastName();
            
            return new Owner()
            {
                FirstName = firstName,
                LastName = lastName
            };
        }

        private string insertFirstName()
        {
            Console.WriteLine("Insert first name:");
            var firstName = Console.ReadLine();

            return firstName;
        }

        private string insertLastName()
        {
            var lastName = "";
            var existLastName = false;
            while (!existLastName)
            {
                Console.Clear();
                Console.WriteLine("Insert last name of the owner:");
                var msgConsole = Console.ReadLine();

                if (msgConsole.Trim().Length != 0)
                {
                    lastName = msgConsole;
                    existLastName = true;
                }
                else
                {
                    Console.WriteLine("Last name is a required field!");
                    Console.Write("Press any key to continue... ");
                    Console.ReadKey();
                }
            }

            return lastName;
        }

        private List<Owner> getOwners()
        {
            return db.Owners.ToList();
        }

        /*
         * Functions of the program 
         */

        /*
         * Vessel
         */
        internal string AddVessel()
        {
            var msgAddVessel = "Vessel added correctly!";
            var vessel = createVessel();

            try
            {
                db.Vessels.Add(vessel);
                db.SaveChanges();
            }
            catch
            {
                msgAddVessel = "Error with adding of the vessel";
            }

            return msgAddVessel;
        }

        internal void ShowVessels()
        {
            var vessels = getVessels();

            vessels.ForEach(ve => {
                Console.WriteLine(ve);
            });
        }

        internal string UpdateVessel()
        {
            var msgUpdVessel = "Vessel updated correctly";
            try
            {
                //changeValuesForVessel();
                db.SaveChanges();
            }
            catch
            {
                msgUpdVessel = "Update fail...";
            }
            return msgUpdVessel;
        }

        /**
         * Owner
         */
        internal string AddOwner()
        {
            var msgAddOwner = "Owner added correctly!";
            var owner = createOwner();

            try
            {
                db.Owners.Add(owner);
                db.SaveChanges();
            }
            catch
            {
                msgAddOwner = "Error with adding of the owner";
            }

            return msgAddOwner;
        }

        internal void ShowOwners()
        {
            var owners = getOwners();

            owners.ForEach(ow => {
                Console.WriteLine(ow);
            });
        }
    }
}
