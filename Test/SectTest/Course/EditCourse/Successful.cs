using System;
using System.Linq;
using Entities.Course;
using FluentAssertions;
using PersistanceEF;
using Services.Course;
using Services.Course.Contract.Dtos;
using SpecTest;
using SpecTest.Infrastractures;
using TestTools.Course;
using Xunit;

namespace SpectTest.Course.EditCourse
{

    [Story(title: "ثبت یک درس ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "تا این درس در کلاس مشخصی قرار گیرد",
        IWantTo = "یک درس تعریف کنم"
    )]

    [Scenario(title: "ویرایش یک درس")]
    public class Successful : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly CourseAppService _sut;
        private EditCourseDto _Editdto;
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

        [When(description: "یک درس با عنوان فیزیک را به ریاضی تفییر میدهیم")]
        public void When()
        {
            var modelForEditing = _dbContext.Set<CourseModel>().SingleOrDefault
                                        (_ => _.Title == _Adddto.Title);
            var idOfEditingModel = modelForEditing.Id;

            var editedDto = CourseFactory.GenerateEditCourseDto(idOfEditingModel);

            _sut.Edit(editedDto);
        }

        [Then(description: "باید تنها یک درس با عنوان ریاضی" +
            " در فهرست درس های دانشگاه وجود داشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<CourseModel>().First();
            actual.Title.Should().Be(_Editdto.Title);
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

