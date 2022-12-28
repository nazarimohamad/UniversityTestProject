using Entities.Teacher;
using Entities.TeacherCourse;

namespace Entities.Course
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public HashSet<TeacherCourseModel>? TeacherCourses { get; set; }
    }
}

