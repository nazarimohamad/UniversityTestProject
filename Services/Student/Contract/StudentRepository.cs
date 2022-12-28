using Entities.Student;

namespace Services.Student
{
    public interface StudentRepository
    {
        void Add(StudentModel student);
    }
}