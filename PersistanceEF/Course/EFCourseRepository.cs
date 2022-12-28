using System;
using Entities.Course;
using Services.Course.Contract;
using Microsoft.EntityFrameworkCore;
using Services.Course.Contract.Dtos;

namespace PersistanceEF.Course
{
    public class EFCourseRepository : CourseRepository
    {
        private readonly DbSet<CourseModel> _courses;
        public EFCourseRepository(EFDataContext dbContext)
        {
            _courses = dbContext.Set<CourseModel>();
        }

        public List<GetCourseDto> GetAll()
        {
            return _courses.Select(_ =>
                  new GetCourseDto
                  {
                      Id = _.Id,
                      Title = _.Title
                  }
               ).ToList();
        }

        public void Add(CourseModel course)
        {
            _courses.Add(course);
        }

        public void Edit(EditedCourseModel editedCourseModel)
        {
            var findedCourseForEdit = _courses.SingleOrDefault
                                            (_ => _.Id == editedCourseModel.Id);
            findedCourseForEdit!.Title = editedCourseModel.Title;
        }

        public void Delete(CourseModel course)
        {
            _courses.Remove(course!);
        }

        public bool IsExist(string title)
        {
            return _courses.Any(_ => _.Title == title);
        }

        public CourseModel Find(int id)
        {
            return _courses.SingleOrDefault(_ => _.Id == id)!; 
        }

        public HashSet<CourseModel> FindCoursesById(List<int> courseIds)
        {
            var _findedCourses = new HashSet<CourseModel>();
            foreach (var id in courseIds)
            {
                _findedCourses.Add(_courses.SingleOrDefault(_ => _.Id == id)!);
            }
            return _findedCourses;
        }
    }
}

