using Application.DBContext;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.ManageProgram
{
    internal class OperationsCentralBase
    {
        private readonly ManageVesselContext db;

        public OperationsCentralBase(ManageVesselContext mngVessel ) 
        {
            db = mngVessel;
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
            var existImoNumber = false;
            while (!existImoNumber)
            {
                Console.Clear();
                Console.WriteLine("Insert IMO Number of the vessel:");
                string msgConsole = Console.ReadLine();

                if (msgConsole.Trim().Length != 0)
                {
                    imoNumber = msgConsole;
                    existImoNumber = true;
                } else
                {
                    BreakConcludeOperation("IMO Number is a required field!");
                }
            }
            
            return imoNumber;
        }

        private List<Vessel> getVessels()
        {
            var vessels = db.Vessels.ToList();
            return vessels;
        }

        private int changeValuesForVessel()
        {
            ShowVessels();
            var idVessel = -1;
            Console.WriteLine("\nInsert id of vessel to update:");
            string inputIdVessel = Console.ReadLine();

            bool success = int.TryParse(inputIdVessel, out idVessel);

            if (success) 
            {
                var vessel = db.Vessels
                        .Find(idVessel);

                try
                {
                    if (!vessel.Equals(null))
                    {
                        Console.Clear();
                        Console.WriteLine("\nInsert imo number to change:");
                        var imoNumber = Console.ReadLine();
                        vessel.ImoNumber = imoNumber;
                    }
                }
                catch (Exception)
                {
                    idVessel = -1;
                    Console.Clear();
                    Console.WriteLine("Vessel not found!");
                    throw;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id has to be a number of type int!");
            }

            return idVessel;
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
                        Console.WriteLine("Are you sure to delete this vessel? Y / n");
                        var answerDeleteVessel = Console.ReadKey();

                        if (answerDeleteVessel.KeyChar == 'Y')
                        {
                            idVesselFound = idVessel;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Vessel not found!");
                    throw;
                }

                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id has to be a number of type int!");
            }

            return idVesselFound;
        }

        private int checkVesselById()
        {
            var inputIdVessel = Console.ReadLine();

            if (int.TryParse(inputIdVessel, out int idVessel))
            {
                var vessel = db.Vessels
                    .Find(idVessel);

                if (vessel.Equals(null))
                    idVessel = -1;
            }
            return idVessel;
        }

        private int checkOwnerById() 
        {
            var inputIdOwner = Console.ReadLine();

            if(int.TryParse(inputIdOwner, out int idOwner))
            {
                var owner = db.Owners
                    .Find(idOwner);

                if (owner.Equals(null))
                    idOwner = -1;
            }
            return idOwner; 
        }

        /**
         * private methods for owner
         */
        private Owner createOwner()
        {
            var firstName = insertFirstName();
            var lastName = insertLastName();
            var vessels = insertVessels();

            var owner = new Owner()
            {
                FirstName = firstName,
                LastName = lastName
            };

            foreach (var item in vessels)
            {
                owner.Vessels.Add(item);
            }
            return owner;
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

        private List<Vessel> insertVessels() 
        {
            var newInsert = true;
            var list = new List<Vessel>();

            while (newInsert) 
            {
                Console.Clear();
                Console.WriteLine("Do you want insert a vessel? Y / n");
                var inputInsertVessel = Console.ReadKey();

                if (inputInsertVessel.KeyChar == 'Y')
                {
                    var vessel = createVessel();
                    list.Add(vessel);
                } else 
                {
                    newInsert = false;
                }
            }
            
            return list;
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
                        Console.WriteLine("\nDo you want to modify first name? Y / n");
                        var answerFirstName = Console.ReadKey();

                        if (answerFirstName.KeyChar == 'Y')
                        {
                            changeFirstNameOwner(owner);
                        }

                        Console.WriteLine("\nDo you want to modify last name? Y / n");
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
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id has to be a number of type int!");
            }
        }

        private int checkIfOwnerCanBeDeleted()
        {
            var idOwnerFound = -1;
            ShowOwners();
            Console.WriteLine("\nInsert id of owner to delete:");
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
                        Console.WriteLine("Are you sure to delete this owner? Y / n");
                        var answerDeleteOwner = Console.ReadKey();

                        if (answerDeleteOwner.KeyChar == 'Y')
                        {
                            idOwnerFound = idOwner;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Owner not found!");
                    throw;
                }

                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Id has to be a number of type int!");
            }

            return idOwnerFound;
        }

        /*
         * Functions of the program 
         */

        /*
         * Vessel
         */
        internal string AddVessel()
        {
            var msgAddVessel = "\nVessel added correctly!";
            var vessel = createVessel();

            try
            {
                db.Vessels.Add(vessel);
                db.SaveChanges();
            }
            catch
            {
                msgAddVessel = "\nError with adding of the vessel";
            }
            return msgAddVessel;
        }

        internal string ShowVessels()
        {
            var msgFoundVessels = "";
            var vessels = getVessels();

            if (vessels.Count != 0)
            {
                Console.WriteLine("-Vessel Information-");
                Console.WriteLine($"\n- Id \t|- IMO Number \t|- Owner id");
                vessels.ForEach(ve => {
                    Console.WriteLine(ve);
                });
            }
            else
                msgFoundVessels = "There are not Vessels!";
            
            return msgFoundVessels;
        }

        internal string UpdateVessel()
        {
            var msgUpdVessel = "";
            try
            {
                var idVessel = changeValuesForVessel();
                if (idVessel != -1)
                {
                    db.SaveChanges();
                    msgUpdVessel = "Vessel updated correctly";
                }
                
            }
            catch
            {
                msgUpdVessel = "Update fail...";
            }
            return msgUpdVessel;
        }

        internal string DeleteVessel()
        {
            var msgDelVessel = "";
            try
            {
                var idVesselToDelete = checkIfVesselCanBeDeleted();

                if (idVesselToDelete != -1)
                {
                    var vessel = db.Vessels.Find(idVesselToDelete);
                    db.Vessels.Remove(vessel);
                    db.SaveChanges();
                    msgDelVessel = "Vessel deleted correctly";
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
            var msgAddOwner = "\nOwner added correctly!";
            var owner = createOwner();

            try
            {
                db.Owners.Add(owner);
                db.SaveChanges();
            }
            catch
            {
                msgAddOwner = "\nError with adding of the owner";
            }

            return msgAddOwner;
        }

        internal string ShowOwners()
        {
            var msgFoundOwners = "";
            var owners = getOwners();

            if (owners.Count != 0)
            {
                Console.WriteLine("-Owner Information-");
                Console.WriteLine($"\n- Id \t|- First name \t\t|- Last name");
                owners.ForEach(ow =>
                {
                    Console.WriteLine(ow);
                });
            }
            else
                msgFoundOwners = "There are not Owners!";

            return msgFoundOwners;
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

        internal string DeleteOwner()
        {
            var msgDelOwner = "";
            try
            {
                var idOwnerToDelete = checkIfOwnerCanBeDeleted();

                if (idOwnerToDelete != -1)
                {
                    var owner = db.Owners.Find(idOwnerToDelete);
                    db.Owners.Remove(owner);
                    db.SaveChanges();
                    msgDelOwner = "Owner deleted correctly";
                }
            }
            catch
            {
                msgDelOwner = "Delete fail...";
            }
            return msgDelOwner;
        }

        internal string AssignVesselToOwner()
        {
            var msgSuccessAssign = "Vessel assigned correctly!";

            try
            {
                ShowVessels();
                Console.WriteLine("Insert id of the Vessel to assign:");
                var idVessel = checkVesselById();
                if (idVessel != -1)
                {
                    ShowOwners();
                    Console.WriteLine("Insert id of the owner:");
                    var idOwner = checkOwnerById();
                    if (idOwner != -1)
                    {
                        var vessel = db.Vessels.Find(idVessel);
                        var owner = db.Owners.Find(idOwner);
                        owner.Vessels.Add(vessel);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Owner not found!");
                    }
                } else
                {
                    Console.WriteLine("Vessel not found!");
                }
            }
            catch
            {
                msgSuccessAssign = "Assign fail...";
            }
            return msgSuccessAssign;
        }

        /**
         * Common functions globally
         */
        internal void BreakConcludeOperation(string errorMessage)
        {
            Console.WriteLine($"{errorMessage}\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
