using Entities.Student;
using Services.SharedContracts;
using Services.Student.Contract;
using Services.Student.Contract.Dtos;

namespace Services.Student
{
    public class StudentAppService : StudentService
    {
        private StudentRepository _repository;
        private UnitOfWork _unitOfWork;

        public StudentAppService(StudentRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddStudentDto dto)
        {
            _repository.Add(GenerateStudentModel(dto));
            _unitOfWork.Compelete();
        }

        private StudentModel GenerateStudentModel(AddStudentDto dto)
        {
            return new StudentModel
            {
                FullName = dto.FullName,
                NationalCode = dto.NationalCode
            };
        }
    }
}