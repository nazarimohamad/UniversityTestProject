using System;
using Entities.Teacher;
using Entities.TeacherCourse;
using Microsoft.EntityFrameworkCore;
using Services.TeacherCourse.Contract;

namespace PersistanceEF.TeacherCourse
{
    public class EFTeacherCourseRepository : TeacherCourseRepository
    {
        private DbSet<TeacherCourseModel> _teacherCourses;
        public EFTeacherCourseRepository(EFDataContext dbContext)
        {
            _teacherCourses = dbContext.Set<TeacherCourseModel>();
        }

        public void Add(HashSet<TeacherCourseModel> teacherCourse)
        {
            _teacherCourses.AddRange(teacherCourse);
        }
    }
}

