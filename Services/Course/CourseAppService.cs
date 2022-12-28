using Entities.Course;
using Services.Course.Contract;
using Services.SharedContracts;
using Services.Course.Exceptions;
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

        public List<GetCourseDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void AddCourse(AddCourseDto dto)
        {
            StopIfCourseIsDuplicated(dto.Title);
            _repository.Add(GenerateCourse(dto));
            _unitOfWork.Compelete();
        }

        public void EditCourse(EditCourseDto editedDto)
        {
            StopIfCourseIsDuplicated(editedDto.Title);
            _repository.Edit(GenerateEditedModel(editedDto));
            _unitOfWork.Compelete();
        }

        public void DeleteCourse(int idForDelete)
        {
            StopIfThereIsNoCourse(idForDelete);
            _repository.Delete(FindCourseById(idForDelete));
            _unitOfWork.Compelete();
        }

        public HashSet<CourseModel> FindCoursesByIds(List<int> coursesId)
        {
            return _repository.FindCoursesById(coursesId);
        }

        private void StopIfThereIsNoCourse(int idForDelete)
        {
            if (FindCourseById(idForDelete) == null)
            {
                throw new ThereIsNoCourseForDeleteException();
            }
        }

        private CourseModel FindCourseById(int id)
        {
            return _repository.Find(id);
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