using Services.Teacher.Contract.Dtos;

namespace Services.Teacher
{
    public interface TeacherService
    {
        int AddTeacher(AddTeacherDto dto);
        void Delete(int id);
    }
}