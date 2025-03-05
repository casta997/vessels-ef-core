using Data.Entities;

namespace Application.ManageProgram
{
    internal class OperationsCentralBase
    {
        private readonly MaritimeContext _dbMaritimeContext;

        public OperationsCentralBase(MaritimeContext maritimeContext)
        {
            _dbMaritimeContext = maritimeContext;
        }


        

        /**
         * private methods for owner
         */
        /*

        private List<Owner> getOwners()
        {
            return _dbMaritimeContext.Owners.ToList();
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
                var owner = _dbMaritimeContext.Owners
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
                var owner = _dbMaritimeContext.Owners
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
        */

        /*
         * Functions of the program 
         */

        

        /**
         * Owner
         */
        /*

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
                _dbMaritimeContext.SaveChanges();
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
                    var owner = _dbMaritimeContext.Owners.Find(idOwnerToDelete);
                    _dbMaritimeContext.Owners.Remove(owner);
                    _dbMaritimeContext.SaveChanges();
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
                        var vessel = _dbMaritimeContext.Vessels.Find(idVessel);
                        var owner = _dbMaritimeContext.Owners.Find(idOwner);
                        owner.Vessels.Add(vessel);
                        _dbMaritimeContext.SaveChanges();
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
        */

        /**
         * Common functions globally
         */
        /*
        internal void BreakConcludeOperation(string errorMessage)
        {
            Console.WriteLine($"{errorMessage}\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        */
    }
}
