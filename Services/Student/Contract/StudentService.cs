using Services.Student.Contract.Dtos;

namespace Services.Student.Contract
{
    public interface StudentService
    {
        void Add(AddStudentDto dto);
        List<GetStudentDto> GetAll();
        void Delete(int id);
        void Edit(int id, EditStudentDto dto);
    }
}