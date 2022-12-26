
using Services.SharedContracts;

namespace PersistanceEF
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly EFDataContext _dbContext;
        public EFUnitOfWork(EFDataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public void Compelete()
        {
            _dbContext.SaveChanges();
        }
    }
}