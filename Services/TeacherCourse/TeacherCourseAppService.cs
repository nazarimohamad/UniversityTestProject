using System;
using Entities.TeacherCourse;
using Services.SharedContracts;
using Services.TeacherCourse.Contract;

namespace Services.TeacherCourse
{
    public class TeacherCourseAppService : TeacherCourseService
    {
        private readonly TeacherCourseRepository _repository;
        private readonly UnitOfWork _unitOfWork;
        public TeacherCourseAppService(UnitOfWork unitOfWork, TeacherCourseRepository repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddTeacherCourse(HashSet<TeacherCourseModel> teacherCourse)
        {
            _repository.Add(teacherCourse);
            _unitOfWork.Compelete();
        }
    }
}

