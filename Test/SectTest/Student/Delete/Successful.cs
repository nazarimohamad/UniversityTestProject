using Xunit;
using SpecTest;
using System.Linq;
using PersistanceEF;
using Entities.Student;
using Services.Student;
using FluentAssertions;
using TestTools.Student;
using SpecTest.Infrastractures;
using Services.Student.Contract.Dtos;

namespace SpectTest.Student.Delete
{
    [Story(title: "ثبت یک دانشجو ",
       AsA = "سرپرست دانشگاه",
       InOrderTo = "تا در کلاس های دانشگاه ثبت نام کند",
       IWantTo = "یک دانشجو تعریف کنم"
   )]

    [Scenario(title: "حذف یک دانشجو")]
    public class Successful : EFDataContextDatabaseFixture

    {
        private readonly EFDataContext _dbContext;
        private readonly StudentAppService _sut;
        private AddStudentDto _dto;
        private readonly string _nationalCodeForDelete = "2233";
        public Successful()
        {
            _dbContext = CreateDataContext();
            _sut = StudentFactory.GenerateServices(_dbContext);
        }

        [Given(description: "تنها یک دانشجو به نام حسن با کد ملی " +
            "۲۲۳۳ در فهرست دانشجویان دانشگاه وجود دارد ")]
        public void Given()
        {
            _dto = StudentFactory.GenerateAddStudentDto(_nationalCodeForDelete);
            _sut.Add(_dto);
        }

        [When(description: "یک دانشجو به نام حسن با کد ملی ۲۲۳۳ را حذف میکنیم")]
        public void When()
        {
            var _idForDelete = _dbContext.Set<StudentModel>()
                                                .SingleOrDefault(_ =>
                                                            _.NationalCode ==
                                                            _nationalCodeForDelete)!
                                                            .Id;
            _sut.Delete(_idForDelete);
        }

        [Then(description: "نباید هیچ دانشحویی در فهرست دانشحویان وجود داشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<StudentModel>()
                                                .SingleOrDefault(_ =>
                                                            _.NationalCode ==
                                                            _nationalCodeForDelete);
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

