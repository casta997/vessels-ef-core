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

        private void changeValuesForVessel()
        {
            ShowVessels();
            Console.WriteLine("\nInsert id of vessel to update:");
            string inputIdVessel = Console.ReadLine();

            bool success = int.TryParse(inputIdVessel, out int idVessel);

            if (success) 
            {
                var vessel = db.Vessels
                .Find(idVessel);

                Console.Clear();
                Console.WriteLine("Insert imo number to change:");
                var imoNumber = Console.ReadLine();
                vessel.ImoNumber = imoNumber;

                Console.Clear();
                Console.WriteLine("check database for vessel!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id has to be a number of type int!");
            }
        }

        private int checkIfVesselCanBeDeleted()
        {
            var idVesselFound = -1;
            ShowVessels();
            Console.WriteLine("\nInsert id of vessel to delete:");
            string inputIdVessel = Console.ReadLine();

            bool success = int.TryParse(inputIdVessel, out int idVessel);

            if (success)
            {
                var vessel = db.Vessels
                .Find(idVessel);

                try
                {
                    if (!vessel.Equals(null))
                    {
                        Console.WriteLine("Are you sure to delete this vessel? Y / N");
                        var answerDeleteVessel = Console.ReadKey();

                        if (answerDeleteVessel.KeyChar == 'Y')
                        {
                            idVesselFound = 1;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Vessel not found!");
                    throw;
                }

                Console.Clear();
                Console.WriteLine("check database if vessel is deleted!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id has to be a number of type int!");
            }

            return idVesselFound;
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

        private void changeFirstNameOwner(Owner owner)
        {
            Console.Clear();
            Console.WriteLine("Insert new first name:");
            var firstName = Console.ReadLine();
            owner.FirstName = firstName;
        }

        private void changeLastNameOwner(Owner owner) 
        {
            Console.Clear();
            Console.WriteLine("Insert new last name:");
            var lastName = Console.ReadLine();
            owner.LastName = lastName;
        }

        private void changeValuesForOwner()
        {
            ShowOwners();
            Console.WriteLine("\nInsert id of owner to update:");
            string inputIdOwner = Console.ReadLine();

            bool success = int.TryParse(inputIdOwner, out int idOwner);

            if (success)
            {
                var owner = db.Owners
                .Find(idOwner);

                try
                {
                    if (!owner.Equals(null))
                    {
                        Console.WriteLine("Do you want to modify first name? Y / N");
                        var answerFirstName = Console.ReadKey();

                        if (answerFirstName.KeyChar == 'Y')
                        {
                            changeFirstNameOwner(owner);
                        }

                        Console.WriteLine("Do you want to modify last name? Y / N");
                        var answerLastName = Console.ReadKey();

                        if (answerLastName.KeyChar == 'Y')
                        {
                            changeLastNameOwner(owner);
                        }

                        // add Vessel
                        // delete Vessel
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Owner not found!");
                    throw;
                }
                Console.Clear();
                Console.WriteLine("check database for vessel!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id has to be a number of type int!");
            }
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
                changeValuesForVessel();
                db.SaveChanges();
            }
            catch
            {
                msgUpdVessel = "Update fail...";
            }
            return msgUpdVessel;
        }

        internal string DeleteVessel()
        {
            var msgDelVessel = "Vessel deleted correctly";
            try
            {
                var idVesselToDelete = checkIfVesselCanBeDeleted();

                if (idVesselToDelete != -1)
                {
                    var vessel = db.Vessels.Find(idVesselToDelete);
                    db.Vessels.Remove(vessel);
                    db.SaveChanges();
                }
            }
            catch
            {
                msgDelVessel = "Delete fail...";
            }
            return msgDelVessel;
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

            if (owners.Count != 0)
            {
                owners.ForEach(ow =>
                {
                    Console.WriteLine(ow);
                });
            }
            else
                Console.WriteLine("There are not Owners!");
            
        }

        internal string UpdateOwner()
        {
            var msgUpdOwner = "Owner updated correctly!";
            try
            {
                changeValuesForOwner();
                db.SaveChanges();
            }
            catch
            {
                msgUpdOwner = "Update fail...";
            }
            return msgUpdOwner;
        }
    }
}
