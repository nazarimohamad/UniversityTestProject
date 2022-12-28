using PersistanceEF;
using Services.Teacher;
using PersistanceEF.Teacher;
using PersistanceEF.TeacherCourse;
using System.Collections.Generic;
using Services.Teacher.Contract.Dtos;

namespace TestTools.Teacher
{
    public class TeacherFactory
    {

        public TeacherFactory()
        {

        }

        public static TeacherAppService GenerateServices(EFDataContext dbContext)
        {
            var _teacherRepository = new EFTeacherRepository(dbContext);
            var _teacherCourseRepository = new EFTeacherCourseRepository(dbContext);
            var _unitOfWork = new EFUnitOfWork(dbContext);
            return new TeacherAppService(_teacherRepository, _teacherCourseRepository, _unitOfWork);
        }

        public static AddTeacherDto GenerateAddTeacherDto()
        {
            return new AddTeacherDto
            {
                FirstName = "علی",
                LastName = "حسن",
                Code = 21,
                CoursesId = new List<int>() {1}
            };
        }
    }
}

