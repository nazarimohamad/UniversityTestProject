using Entities.Course;
using Services.Course.Contract;
using Services.SharedContracts;
using Services.Course.Contract.Dtos;

namespace Services.Course
{
    public class CourseAppService : CourseService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CourseRepository _repository;
        public CourseAppService(UnitOfWork unitOfWork, CourseRepository repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddCourseDto dto)
        {
            _repository.Add(GenerateCourse(dto));
            _unitOfWork.Compelete();
        }

        private CourseModel GenerateCourse(AddCourseDto dto)
        {
            return new CourseModel
            {
                Title = dto.Title
            };
        }
    }
}