using Xunit;
using System.Linq;
using PersistanceEF;
using Entities.Course;
using Services.Course;
using FluentAssertions;
using TestTools.Course;
using UnitTest.Infrastructure;

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
            var _dto = CourseFactory.GenerateCourseDto();

            _sut.Add(_dto);

            var actual = _dbContext.Set<CourseModel>().First();
            actual.Title.Should().Be(_dto.Title);
        }
    }
}

