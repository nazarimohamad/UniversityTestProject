using Xunit;
using System.Linq;
using PersistanceEF;
using FluentAssertions;
using Entities.Semesters;
using TestTools.Semester;
using SpecTest.Infrastractures;
using Services.Semester.Contract.Dtos;
using Services.Semester;

namespace SpecTest.Semester.AddSemester
{
    [Story(title: "ثبت یکت ترم ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "کلاس های مربوط به آن ترم را مشخص کنم",
        IWantTo = "یک ترم تعریف کنم"
    )]

    [Scenario(title: "ثبت یک ترم")]
    public class Successful : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly SemesterAppService _sut;
        private AddSemesterDto _dto;

        public Successful()
        {
            _dbContext = CreateDataContext();
            _sut = SemesterFactory.GenerateServices(_dbContext);
        }

        [Given(description: "هیج ترمی در فهرست ترم های دانشگاه وجود ندارد")]
        public void Given() { }

        [When(description: "یک ترم به شماره ی ۱ و سال ۱۴۰۰ را اضافه میکنیم")]
        public void When()
        {
            _dto = SemesterFactory.GenerateSemesterDto();

            _sut.Add(_dto);
        }

        [Then(description: "باید یک ترم به شماره ی ۱ و سال ۱۴۰۰ در فهرست" +
                            " ترم های دانشگاه وجود داشته باشد")]    
        public void Then()
        {
            var actual = _dbContext.Set<SemesterModel>().First();
            actual.Year.Should().Be(_dto.Year);
            actual.Number.Should().Be(_dto.Number);
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

