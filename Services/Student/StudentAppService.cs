using Entities.Student;
using UnitTest.Student;
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

        public List<GetStudentDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Add(AddStudentDto dto)
        {
            StopIfNationalCodeIsDuplicated(dto.NationalCode);
            _repository.Add(GenerateStudentModel(dto));
            _unitOfWork.Compelete();
        }

        public void Edit(int id, EditStudentDto dto)
        {
            StopIfNationalCodeIsDuplicated(dto.NationalCode);
            var _findedModel = FindStudentById(id);
            StopIfThereIsNoStudent(_findedModel);
            var _editedModel = GenerateEditedModel(_findedModel, dto);
            _repository.Delete(_findedModel);
            _repository.Add(_editedModel);
            _unitOfWork.Compelete();
        }

        public void Delete(int idForDelete)
        {
            var studentForDelete = FindStudentById(idForDelete);
            StopIfThereIsNoStudent(studentForDelete);
            _repository.Delete(studentForDelete);
            _unitOfWork.Compelete();
        }

        private StudentModel GenerateEditedModel(
                                    StudentModel findedModel,
                                    EditStudentDto dto)
        {
            return new StudentModel
            {
                Id = findedModel.Id,
                FullName = dto.FullName,
                NationalCode = dto.NationalCode
            };
        }

        private void StopIfThereIsNoStudent(StudentModel student)
        {
            if(student == null)
            {
                throw new ThereIsNoStudentException();
            }
        }

        private StudentModel FindStudentById(int id)
        {
            return _repository.Find(id);
        }

        private void StopIfNationalCodeIsDuplicated(string nationalCode)
        {
            if (_repository.IsExist(nationalCode))
            {
                throw new DuplicateNationalCodeException();
            }
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