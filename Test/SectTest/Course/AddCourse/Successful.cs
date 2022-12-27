using Xunit;
using SpecTest;
using System.Linq;
using PersistanceEF;
using TestTools.Course;
using FluentAssertions;
using SpecTest.Infrastractures;
using Services.Course.Contract.Dtos;
using Services.Course;
using Entities.Course;

namespace SpectTest.Course.AddCourse
{
    [Story(title: "ثبت یک درس ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "تا این درس در کلاس مشخصی قرار گیرد",
        IWantTo = "یک درس تعریف کنم"
    )]

    [Scenario(title: "ثبت یک درس")]
    public class Successful : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly  CourseAppService _sut;
        private AddCourseDto _dto;

        public Successful()
        {
            _dbContext = CreateDataContext();
            _sut = CourseFactory.GenerateServices(_dbContext);
        }

        [Given(description: "هیج درسی در فهرست درس های دانشگاه وجود ندارد")]
        public void Given() { }

        [When(description: "یک درس با عنوان فیزیک را اضافه میکنیم")]
        public void When()
        {
            _dto = CourseFactory.GenerateAddCourseDto();

            _sut.Add(_dto);
        }

        [Then(description: "باید یک درس با عنوان فیزیک" +
            " در فهرست درس های دانشگاه وجود داشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<CourseModel>().First();
            actual.Title.Should().Be(_dto.Title);
        }

        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When(),
                _ => Then()
            );
        }
    }
}

