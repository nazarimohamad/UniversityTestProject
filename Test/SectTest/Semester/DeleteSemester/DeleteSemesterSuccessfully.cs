using System;
using System.Linq;
using Entities.Semesters;
using FluentAssertions;
using PersistanceEF;
using Services.Semester;
using Services.Semester.Contract.Dtos;
using SpecTest;
using SpecTest.Infrastractures;
using TestTools.Semester;
using Xunit;

namespace SpectTest.Semester.DeleteSemester
{
    [Story(title: "ثبت یکت ترم ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "کلاس های مربوط به آن ترم را مشخص کنم",
        IWantTo = "یک ترم تعریف کنم"
    )]

    [Scenario(title: "حذف یک ترم")]
    public class DeleteSemesterSuccessfully : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly SemesterAppService _sut;
        private AddSemesterDto _dto;

        public DeleteSemesterSuccessfully()
        {
            _dbContext = CreateDataContext();
            _sut = SemesterFactory.GenerateServices(_dbContext);
        }

        [Given(description: "تنها یک ترم با شماره " +
            "ی ۱ و سال ۱۴۰۰ در فهرست ترم های دانشگاه وجود دارد")]
        public void Given()
        {
            _dto = SemesterFactory.GenerateSemesterDto();

            _sut.Add(_dto);
        }

        [When(description: "یک ترم با شماره ی ۱ و سال ۱۴۰۰ را حذف میکنیم")]
        public void When()
        {
            var findedSemester = _dbContext.Set<SemesterModel>().SingleOrDefault(
                                    _ => _.Number == _dto.Number &&
                                    _.Year == _dto.Year);
            var idForDelete = findedSemester.Id;
            _sut.Delete(idForDelete);
        }

        [Then(description: "هیچ ترمی در فهرست ترم های دانشگاه نباید وجود داشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<SemesterModel>().SingleOrDefault(
                                    _ => _.Number == _dto.Number &&
                                    _.Year == _dto.Year);
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

