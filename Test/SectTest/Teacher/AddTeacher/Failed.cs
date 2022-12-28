using System;
using System.Linq;
using Entities.Teacher;
using FluentAssertions;
using PersistanceEF;
using Services.Course;
using Services.Teacher;
using Services.Teacher.Contract.Dtos;
using SpecTest;
using SpecTest.Infrastractures;
using TestTools.Course;
using TestTools.Teacher;
using Xunit;

namespace SpectTest.Teacher.AddTeacher
{
    [Story(title: "ثبت یک استاد ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "تااستاد در کلاس و با تخصص مشخصی قرار گیرد",
        IWantTo = "یک استاد تعریف کنم"
    )]

    [Scenario(title: "ثبت یک استاد")]
    public class Failed : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly TeacherAppService _sut;
        private readonly CourseAppService _csut;
        private AddTeacherDto _dto;

        public Failed()
        {
            _dbContext = CreateDataContext();
            _sut = TeacherFactory.GenerateServices(_dbContext);
            _csut = CourseFactory.GenerateServices(_dbContext);
        }

        [Given(description: "یک استاد به نام علی حسن با کد ۲۱" +
            " با تخصص در درس فیزیک در فهرست استاد های دانشگاه وجود دارد و یک درس به " +
            "نام فیزیک در فهرست درس های دانشگاه نیز وجود دارد")]
        public void Given()
        {
            _dto = TeacherFactory.GenerateAddTeacherDto();
            _sut.AddTeacher(_dto);

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

        [Then(description: "تنها یک استاد با نام علی حسن و کد ۲۱ باید" +
            " وجود داشته باشد و خطای کد استاد تکراری است رخ دهد")]
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

