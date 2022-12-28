using Xunit;
using SpecTest;
using System.Linq;
using PersistanceEF;
using Services.Course;
using Entities.Teacher;
using FluentAssertions;
using TestTools.Course;
using Services.Teacher;
using TestTools.Teacher;
using SpecTest.Infrastractures;
using Services.Teacher.Contract.Dtos;

namespace SpectTest.Teacher.AddTeacher
{

    [Story(title: "ثبت یک استاد ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "تااستاد در کلاس و با تخصص مشخصی قرار گیرد",
        IWantTo = "یک استاد تعریف کنم"
    )]

    [Scenario(title: "ثبت یک استاد")]
    public class Successful : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly TeacherAppService _sut;
        private readonly CourseAppService _csut;
        private AddTeacherDto _dto;

        public Successful()
        {
            _dbContext = CreateDataContext();
            _sut = TeacherFactory.GenerateServices(_dbContext);
            _csut = CourseFactory.GenerateServices(_dbContext);
        }

        [Given(description: "هیج استادی در فهرست استاد های دانشگاه وجود ندارد و " +
            "یک درس به نام قیزیک ر فهرست درس های دانشگاه وجود دارد")]
        public void Given()
        {
            var _courseDto = CourseFactory.GenerateAddCourseDto();
            _csut.AddCourse(_courseDto);
        }

        [When(description: "یک استاد به نام علی حسن با کد ۲۱ و تخصص" +
            " در درس فیزیک را اضافه میکینیم")]
        public void When()
        {
            _dto = TeacherFactory.GenerateAddTeacherDto();

            _sut.AddTeacher(_dto);
        }

        [Then(description: "باید یک استاد به نام علی حسن با کد ۲۱ " +
            "و تخصص در درس ریاضی وجود داشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<TeacherModel>().First();
            actual.FirstName.Should().Be(_dto.FirstName);
            actual.LastName.Should().Be(_dto.LastName);
            actual.Code.Should().Be(_dto.Code);
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

