using Entities.Course;
using Entities.Teacher;
using Entities.TeacherCourse;
using Services.Course;
using Services.Course.Contract;
using Services.SharedContracts;
using Services.Teacher.Contract.Dtos;
using Services.Teacher.Exceptions;
using Services.TeacherCourse;
using Services.TeacherCourse.Contract;

namespace Services.Teacher
{
    public class TeacherAppService : TeacherService
    {
        private readonly TeacherRepository _teacherRepository;
        private readonly TeacherCourseRepository _teacherCourseRepository;
        private readonly TeacherCourseAppService _teacherCourseAppService;
        private readonly UnitOfWork _unitOfWork;
        public TeacherAppService(
                    TeacherRepository teacherRepository,
                    TeacherCourseRepository teacherCourseRepository,
                    UnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _teacherCourseRepository = teacherCourseRepository;
            _unitOfWork = unitOfWork;
            _teacherCourseAppService = new TeacherCourseAppService(_unitOfWork, _teacherCourseRepository);
        }

        public int AddTeacher(AddTeacherDto dto)
        {
            StopIfDuplicateTeacherCode(dto.Code);
            var teacherModel = GenerateTeacherModel(dto);
             _teacherRepository.Add(teacherModel);
            _unitOfWork.Compelete();
            var _teacherCourses = GenerateTeacherCourseModel(teacherModel.Id, dto.CoursesId);
            AddTeacherCourses(_teacherCourses);
            return teacherModel.Id;
        }

        public void Delete(int id)
        {

            _teacherRepository.Delete(FindTeacherById(id));
            _unitOfWork.Compelete();
        }

        private TeacherModel FindTeacherById(int id)
        {
            return _teacherRepository.FindById(id);
        }

        private void AddTeacherCourses(HashSet<TeacherCourseModel> teacherCourses)
        {
              _teacherCourseAppService.AddTeacherCourse(teacherCourses);
        }

        private void StopIfDuplicateTeacherCode(int code)
        {
            if (_teacherRepository.IsExcist(code))
            {
                throw new DuplicatedTeacherCodeException();
            }
        }

        private HashSet<TeacherCourseModel> GenerateTeacherCourseModel(int teacherId, List<int> coursesId)
        {
            HashSet<TeacherCourseModel> teacherCourses = new HashSet<TeacherCourseModel>();
            foreach (var coursId in coursesId)
            {
                teacherCourses.Add(new TeacherCourseModel
                                                { CourseId = coursId,
                                                TeacherId = teacherId });
            }
            return teacherCourses;
        }

        private TeacherModel GenerateTeacherModel(AddTeacherDto dto)
        {
            return new TeacherModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Code = dto.Code,
            };
        }
    }
}