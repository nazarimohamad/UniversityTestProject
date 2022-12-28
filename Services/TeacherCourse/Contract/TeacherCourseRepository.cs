using Entities.TeacherCourse;

namespace Services.TeacherCourse.Contract
{
    public interface TeacherCourseRepository
    {
        public void Add(HashSet<TeacherCourseModel> teacherCourse);
    }
}