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
