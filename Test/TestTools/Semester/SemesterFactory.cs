using System;
using PersistanceEF;
using Services.Semester;
using PersistanceEF.Semsters;
using Services.Semester.Contract.Dtos;

namespace TestTools.Semester
{
    public class SemesterFactory
    {
        public SemesterFactory()
        {
        }

        public static AddSemesterDto GenerateSemesterDto()
        {
            return new AddSemesterDto
            {
                Number = 1,
                Year = 1400
            };
        }

        public static SemesterAppService GenerateServices(EFDataContext dbContext)
        {
            var unitOfWork = new EFUnitOfWork(dbContext);
            var semsterRepository = new EFSemesterRepository(dbContext);
            return new SemesterAppService(semsters: semsterRepository, unitOfWork: unitOfWork);
        }
    }
}

