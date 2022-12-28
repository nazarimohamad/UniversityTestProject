using PersistanceEF;
using Services.Student;
using PersistanceEF.Student;
using Services.Student.Contract.Dtos;
using System;

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

        public static AddStudentDto GenerateAddStudentDto(string nationalCode = "2233")
        {
            return new AddStudentDto
            {
                FullName = "حسن",
                NationalCode = nationalCode
            };
        }

        public static EditStudentDto GenerateEditStudentDto(string editedName = "علی")
        {
            return new EditStudentDto
            {
                FullName = editedName,
                NationalCode = "2233"
            };
        }
    }
}