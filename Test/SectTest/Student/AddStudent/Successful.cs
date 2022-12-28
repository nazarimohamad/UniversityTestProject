using Xunit;
using SpecTest;
using System.Linq;
using PersistanceEF;
using FluentAssertions;
using Entities.Student;
using Services.Student;
using TestTools.Student;
using SpecTest.Infrastractures;
using Services.Student.Contract.Dtos;

namespace SpectTest.Student.AddStudent
{
    [Story(title: "ثبت یک دانشجو ",
        AsA = "سرپرست دانشگاه",
        InOrderTo = "تا در کلاس های دانشگاه ثبت نام کند",
        IWantTo = "یک دانشجو تعریف کنم"
    )]

    [Scenario(title: "ثبت یک دانشجو")]
    public class Successful : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly StudentAppService _sut;
        private AddStudentDto _dto;

        public Successful()
        {
            _dbContext = CreateDataContext();
            _sut = StudentFactory.GenerateServices(_dbContext);
        }

        [Given(description: "هیج دانشجویی در فهرست دانشجویان وجود ندارد ")]
        public void Given(){}

        [When(description: "یک دانشجو به نام حسن با کد ملی ۲۲۳۳ را ثبت میکنیم")]
        public void When()
        {
            _dto = StudentFactory.GenerateAddStudentDto();

            _sut.Add(_dto);
        }

        [Then(description: "باید تنها یک دانشجو به نام حسن با کد م" +
            "لی ۲۲۳۳ در فهرست دانشچویان دانشگاه وجود داشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<StudentModel>().First();
            actual.FullName.Should().Be(_dto.FullName);
            actual.NationalCode.Should().Be(_dto.NationalCode);
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

