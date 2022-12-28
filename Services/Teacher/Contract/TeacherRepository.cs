using Entities.Teacher;
using Services.Teacher.Contract.Dtos;

namespace Services.Teacher
{
    public interface TeacherRepository
    {
        void Add(TeacherModel teacherModel);
        bool IsExcist(int code);
        void Delete(TeacherModel teacher);
        TeacherModel FindById(int id);
        List<GetTeacherDto> GetAll();
    }
}