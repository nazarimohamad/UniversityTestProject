using PersistanceEF;
using Services.Student;
using PersistanceEF.Student;
using Services.Student.Contract.Dtos;

namespace TestTools.Student
{
    public class StudentFactory
    {
        public static StudentAppService GenerateServices(EFDataContext dbContext)
        {
            var _repository = new EFStudentRepository(dbContext);
            var _unitOfWork = new EFUnitOfWork(dbContext);
            return new StudentAppService(_repository, _unitOfWork);
        }

        public static AddStudentDto GenerateAddStudentDto()
        {
            return new AddStudentDto
            {
                FullName = "حسن",
                NationalCode = "2233"
            };
        }
    }
}