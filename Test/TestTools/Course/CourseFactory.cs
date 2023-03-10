using System;
using Entities.Course;
using PersistanceEF;
using PersistanceEF.Course;
using Services.Course;
using Services.Course.Contract.Dtos;

namespace TestTools.Course
{
    public class CourseFactory
    {
        public static CourseAppService GenerateServices(EFDataContext dbContext)
        {
            var _unitOfWork = new EFUnitOfWork(dbContext);
            var _repository = new EFCourseRepository(dbContext);
            return new CourseAppService(unitOfWork: _unitOfWork, repository: _repository);
        }

        public static AddCourseDto GenerateAddCourseDto()
        {
            return new AddCourseDto
            {
                Title = "فیزیک"
            };
        }

        public static Entities.Course.CourseModel GenerateCourse()
        {
            return new Entities.Course.CourseModel
            {
                Title = "فیزیک"
            };
        }

        public static EditCourseDto GenerateEditCourseDto(int idOfEditingModel)
        {
            return new EditCourseDto
            {
                Id = idOfEditingModel,
                Title = "ریاضی"
            };
        }
    }
}