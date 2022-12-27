using Entities.Semesters;
using Services.Semester.Contract;
using Microsoft.EntityFrameworkCore;

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

        public bool isExist(int number, int year)
        {
            return _semsters.Any(_ => _.Number == number &&
                                      _.Year == year);
        }
    }
}