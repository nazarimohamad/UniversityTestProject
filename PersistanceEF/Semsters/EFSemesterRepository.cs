using Entities.Semesters;
using Services.Semester.Contract;
using Microsoft.EntityFrameworkCore;
using Services.Semester.Contract.Dtos;

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

        public void Delete(SemesterModel model)
        {
            _semsters.Remove(model);
        }

        public SemesterModel? Find(int id)
        {
            return _semsters.SingleOrDefault(_ => _.Id == id);
        }

        public List<GetSemesterDto> GetAll()
        {
            return _semsters.Select(_ =>
                new GetSemesterDto
                {
                    Number = _.Number,
                    year = _.Year
                }
            ).ToList();
        }

        public bool isExist(int number, int year)
        {
            return _semsters.Any(_ => _.Number == number &&
                                      _.Year == year);
        }
    }
}