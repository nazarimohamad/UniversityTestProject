using Entities.Semesters;
using Microsoft.EntityFrameworkCore;
using PersistanceEF;
using Services.Semester.Contract;

namespace PersistanceEF.Semsters
{
    public class EFSemesterRepository : SemesterRepository
    {
        private DbSet<SemesterModel> _semsters;

        public EFSemesterRepository(EFDataContext dbContext)
        {
            _semsters = dbContext.Set<SemesterModel>();
        }

        public void Add(SemesterModel semester)
        {
            _semsters.Add(semester);
        }
    }
}