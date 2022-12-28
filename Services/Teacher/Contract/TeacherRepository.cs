using Entities.Teacher;

namespace Services.Teacher
{
    public interface TeacherRepository
    {
        void Add(TeacherModel teacherModel);
        bool IsExcist(int code);
    }
}