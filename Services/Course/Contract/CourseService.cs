using Services.Course.Contract.Dtos;

namespace Services.Course.Contract
{
    public interface CourseService
    {
        public void AddCourse(AddCourseDto dto);
        void EditCourse(EditCourseDto dto);
        void DeleteCourse(int id);
    }
}