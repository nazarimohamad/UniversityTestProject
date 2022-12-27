using Xunit;
using SpecTest;
using System.Linq;
using PersistanceEF;
using Entities.Course;
using Services.Course;
using TestTools.Course;
using FluentAssertions;
using SpecTest.Infrastractures;
using Services.Course.Contract.Dtos;

namespace SpectTest.Course.AddCourse
{
    [Story(title: "ثبت یک درس ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "تا این درس در کلاس مشخصی قرار گیرد",
        IWantTo = "یک درس تعریف کنم"
    )]

    [Scenario(title: "ثبت یک درس با عنوان تکراری")]
    public class Failed : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly CourseAppService _sut;
        private AddCourseDto _dto;

        public Failed()
        {
            _dbContext = CreateDataContext();
            _sut = CourseFactory.GenerateServices(_dbContext);
        }

        [Given(description: "یک درس با عنوان فیزیک در فهرست درس های " +
            "دانشگاه وجود دارد")]
        public void Given()
        {
            _dto = CourseFactory.GenerateAddCourseDto();

            _sut.Add(_dto);
        }

        [When(description: "یک درس با عنوان فیزیک را اضافه میکنیم")]
        public void When()
        {
            _dto = CourseFactory.GenerateAddCourseDto();

            _sut.Add(_dto);
        }

        [Then(description: "تنها یک درس با عنوان فیزیک در فهرست درس های دانشگاه" +
            " وحود دارد و خطای درس تکراری است رخ میدهد")]
        public void Then()
        {
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

