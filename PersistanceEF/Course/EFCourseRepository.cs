using System;
using Entities.Course;
using Services.Course.Contract;
using Microsoft.EntityFrameworkCore;
using Services.Course.Contract.Dtos;

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

        public bool IsExist(string title)
        {
            return _course.Any(_ => _.Title == title);
        }
    }
}

