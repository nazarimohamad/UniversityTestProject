using Services.Course.Contract.Dtos;

namespace Services.Course.Contract
{
    public interface CourseService
    {
        public void Add(AddCourseDto dto);
        void Edit(EditCourseDto dto);
    }
}