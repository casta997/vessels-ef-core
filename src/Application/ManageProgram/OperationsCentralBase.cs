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
    }
}
