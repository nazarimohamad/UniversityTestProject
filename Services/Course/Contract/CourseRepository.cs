using Entities.Course;
using Services.Course.Contract.Dtos;

namespace Services.Course.Contract
{
    public interface CourseRepository
    {
        public void Add(CourseModel course);
        bool IsExist(string title);
    }
}