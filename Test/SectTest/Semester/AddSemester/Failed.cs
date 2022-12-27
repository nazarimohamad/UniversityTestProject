using Xunit;
using SpecTest;
using PersistanceEF;
using TestTools.Semester;
using SpecTest.Infrastractures;
using Services.Semester.Contract.Dtos;
using Services.Semester;

namespace SpectTest.Semester.AddSemester
{
    [Story(title: "ثبت یکت ترم ",
    AsA = "سرپرست دانشگاه",
    InOrderTo = "کلاس های مربوط به آن ترم را مشخص کنم",
    IWantTo = "یک ترم تعریف کنم"
    )]

    [Scenario(title: "ثبت یک ترم تکراری")]
    public class Failed : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly SemesterAppService _sut;
        private AddSemesterDto _dto;

        public Failed()
        {
            _dbContext = CreateDataContext();
            _sut = SemesterFactory.GenerateServices(_dbContext);
        }

        [Given(description: "یک ترم با شماره ی ۱ و سال ۱۴۰۰ در فهرست ترم های دانشگاه وجود دارد")]
        public void Given()
        {
            _dto = SemesterFactory.GenerateSemesterDto();

            _sut.Add(_dto);
        }

        [When(description: "یک ترم به شماره ی ۱ و سال ۱۴۰۰ را اضافه میکنیم")]
        public void When()
        {
            _dto = SemesterFactory.GenerateSemesterDto();

            _sut.Add(_dto);
        }

        [Then(description: "باید تنها یک ترم در فهرست ترم های دانشگاه" +
            "وحود داشته باشد و خطای ترم تکراری است رخ دهد")]
            
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

