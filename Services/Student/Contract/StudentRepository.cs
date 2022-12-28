using Entities.Student;

namespace Services.Student
{
    public interface StudentRepository
    {
        void Add(StudentModel student);
        bool IsExist(string nationalCode);
        StudentModel Find(int id);
        void Delete(StudentModel studentForDelete);
        List<GetStudentDto> GetAll();
    }
}