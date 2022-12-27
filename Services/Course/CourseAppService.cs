using Entities.Course;
using Services.Course.Contract;
using Services.SharedContracts;
using Services.Course.Contract.Dtos;
using Services.Course.Exceptions;

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
            StopIfCourseIsDuplicated(dto.Title);
            _repository.Add(GenerateCourse(dto));
            _unitOfWork.Compelete();
        }

        public void Edit(EditCourseDto editedDto)
        {
            StopIfCourseIsDuplicated(editedDto.Title);
            _repository.Edit(GenerateEditedModel(editedDto));
            _unitOfWork.Compelete();
        }

        private EditedCourseModel GenerateEditedModel(EditCourseDto editedDto)
        {
            return new EditedCourseModel
            {
                Id = editedDto.Id,
                Title = editedDto.Title
            };
        }

        private void StopIfCourseIsDuplicated(string title)
        {
            if (_repository.IsExist(title))
            {
                throw new DuplicatedCourseException();
            }
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