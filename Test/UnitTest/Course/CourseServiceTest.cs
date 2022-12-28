using Xunit;
using System.Linq;
using PersistanceEF;
using Entities.Course;
using Services.Course;
using FluentAssertions;
using TestTools.Course;
using UnitTest.Infrastructure;
using System;
using Services.Course.Exceptions;

namespace UnitTest.Course
{
    public class CourseServiceTest 
    {
        private readonly EFDataContext _dbContext;
        private readonly CourseAppService _sut;
        public CourseServiceTest()
        {
            _dbContext = new EFInMemoryDatabase().CreateDataContext<EFDataContext>();
            _sut = CourseFactory.GenerateServices(_dbContext);
        }

        [Fact]
        public void Add_course_properly()
        {
            var _dto = CourseFactory.GenerateAddCourseDto();

            _sut.AddCourse(_dto);

            var actual = _dbContext.Set<CourseModel>().First();
            actual.Title.Should().Be(_dto.Title);
        }


        [Fact]
        public void Failed_to_add_duplicated_course()
        {
            var _course = CourseFactory.GenerateCourse();
            _dbContext.Manipulate(_ => _.Add(_course));

            var _duplicatedCourseDto = CourseFactory.GenerateAddCourseDto();
            Action actual = () => _sut.AddCourse(_duplicatedCourseDto);

            actual.Should().ThrowExactly<DuplicatedCourseException>();
            
        }

        [Fact]
        public void Delete_course_properly()
        {
            var _course = CourseFactory.GenerateCourse();
            _dbContext.Manipulate(_ => _.Add(_course));
            var idForDelete = _dbContext.Set<CourseModel>().
                                            SingleOrDefault(
                                                _ => _.Title == _course.Title)!.Id;
            Action actual = () => _sut.DeleteCourse(idForDelete);

            actual.Should().BeNull();
        }
    }
}

