using Entities.Course;

namespace Services.Course.Contract
{
    public interface CourseRepository
    {
        public void Add(CourseModel course);
        bool IsExist(string title);
        void Edit(EditedCourseModel editedCourseModel);
        void Delete(CourseModel course);
        CourseModel Find(int id);
        HashSet<CourseModel> FindCoursesById(List<int> courseIds);
    }
}