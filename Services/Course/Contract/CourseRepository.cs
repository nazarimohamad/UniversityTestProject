using Entities.Course;

namespace Services.Course.Contract
{
    public interface CourseRepository
    {
        public void Add(CourseModel course);
    }
}