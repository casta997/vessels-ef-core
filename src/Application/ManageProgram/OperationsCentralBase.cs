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
         * Owner
         */
        /*

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
