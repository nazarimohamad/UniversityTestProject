using System;
using System.Linq;
using Entities.Semesters;
using FluentAssertions;
using PersistanceEF;
using Services.Semester.Contract.Dtos;
using SpecTest;
using SpecTest.Infrastractures;
using TestTools.Semester;
using Xunit;

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
        private AddSemesterDto _dto;

        public Failed()
        {
            _dbContext = CreateDataContext();
        }

        [Given(description: "یک ترم با شماره ی ۱ و سال ۱۴۰۰ در فهرست ترم های دانشگاه وجود دارد")]
        public void Given()
        {
            _dto = SemesterFactory.GenerateSemesterDto();
            var sut = SemesterFactory.GenerateServices(_dbContext);

            sut.Add(_dto);
        }

        [When(description: "یک ترم به شماره ی ۱ و سال ۱۴۰۰ را اضافه میکنیم")]
        public void When()
        {
            _dto = SemesterFactory.GenerateSemesterDto();
            var sut = SemesterFactory.GenerateServices(_dbContext);

            sut.Add(_dto);
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

