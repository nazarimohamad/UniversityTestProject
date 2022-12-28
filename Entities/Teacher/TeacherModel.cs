using Entities.Course;
using Entities.TeacherCourse;

namespace Entities.Teacher
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public HashSet<TeacherCourseModel>? TeacherCourses { get; set; }
    }
}