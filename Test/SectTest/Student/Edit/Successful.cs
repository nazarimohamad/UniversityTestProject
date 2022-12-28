using Xunit;
using SpecTest;
using System.Linq;
using PersistanceEF;
using Entities.Student;
using FluentAssertions;
using Services.Student;
using TestTools.Student;
using SpecTest.Infrastractures;
using Services.Student.Contract.Dtos;

namespace SpectTest.Student.Edit
{
    [Story(title: "ثبت یک دانشجو ",
       AsA = "سرپرست دانشگاه",
       InOrderTo = "تا در کلاس های دانشگاه ثبت نام کند",
       IWantTo = "یک دانشجو تعریف کنم"
   )]

    [Scenario(title: "ویرایش یک دانشجو")]
    public class Successful : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly StudentAppService _sut;
        private AddStudentDto _dto;
        private readonly string _nationalCode = "2233";
        private readonly string _editedName = "علی";
        public Successful()
        {
            _dbContext = CreateDataContext();
            _sut = StudentFactory.GenerateServices(_dbContext);
        }

        [Given(description: " یک دانشجو به نام حسن با کد ملی " +
            "۲۲۳۳ در فهرست دانشجویان دانشگاه وجود دارد ")]
        public void Given()
        {
            _dto = StudentFactory.GenerateAddStudentDto(_nationalCode);
            _sut.Add(_dto);
        }

        [When(description: "یک دانشجو به نام حسن را به علی تغییر نام میدهیم")]
        public void When()
        {
            var _studentForEdit = _dbContext.Set<StudentModel>()
                                                .SingleOrDefault(_ =>
                                                            _.NationalCode ==
                                                            _nationalCode);
           var _editedDto = StudentFactory.GenerateEditStudentDto(_editedName);
            _sut.Edit(_studentForEdit.Id, _editedDto);
        }

        [Then(description: "باید تنها یک دانشجو به نام علی و کد ملی ۲۲۳۳" +
            " در فهرست دانشجویان وجود داشته باشد")]
        public void Then()
        {
            var actual = _dbContext.Set<StudentModel>()
                                                .SingleOrDefault(_ =>
                                                            _.NationalCode ==
                                                            _nationalCode);
            actual.FullName.Should().Be(_editedName);
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

