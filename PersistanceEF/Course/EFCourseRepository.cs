using System;
using Entities.Course;
using Services.Course.Contract;
using Microsoft.EntityFrameworkCore;

namespace PersistanceEF.Course
{
    public class EFCourseRepository : CourseRepository
    {
        private readonly DbSet<CourseModel> _course;
        public EFCourseRepository(EFDataContext dbContext)
        {
            _course = dbContext.Set<CourseModel>();
        }

        public void Add(CourseModel course)
        {
            _course.Add(course);
        }
    }
}

