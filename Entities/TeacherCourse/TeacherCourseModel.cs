using System;
using Entities.Course;
using Entities.Teacher;

namespace Entities.TeacherCourse
{
    public class TeacherCourseModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public CourseModel Course { get; set; }

        public int TeacherId { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}

