using Xunit;
using SpecTest;
using System.Linq;
using PersistanceEF;
using Entities.Course;
using Services.Course;
using FluentAssertions;
using TestTools.Course;
using SpecTest.Infrastractures;
using Services.Course.Contract.Dtos;

namespace SpectTest.Course.DeleteCourse
{
    [Story(title: "ثبت یک درس ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "تا این درس در کلاس مشخصی قرار گیرد",
        IWantTo = "یک درس تعریف کنم"
    )]

    [Scenario(title: "حذف یک درس")]
    public class Successful : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly CourseAppService _sut;
        private AddCourseDto _Adddto;

        public Successful()
        {
            _dbContext = CreateDataContext();
            _sut = CourseFactory.GenerateServices(_dbContext);
        }

        [Given(description: "تنها یک درس با عنوان فیزیک در فهرست درس های " +
            "دانشگاه وجود دارد")]
        public void Given()
        {
            _Adddto = CourseFactory.GenerateAddCourseDto();

            _sut.Add(_Adddto);
        }

        [When(description: "یک درس با عنوان فیزیک را حذف میکنیم")]
        public void When()
        {
            var modelForDelete = _dbContext.Set<CourseModel>().SingleOrDefault
                                        (_ => _.Title == _Adddto.Title);
            var idOfDeleteModel = modelForDelete.Id;

            _sut.Delete(idOfDeleteModel);

        }

        [Then(description: "باید هیچ درسی در فهرست درسهای دانشگاه" +
            " وجود نداشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<CourseModel>().First();
            actual.Should().BeNull();
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

