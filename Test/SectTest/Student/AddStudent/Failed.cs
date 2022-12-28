using PersistanceEF;
using Services.Student;
using Services.Student.Contract.Dtos;
using SpecTest;
using SpecTest.Infrastractures;
using TestTools.Student;
using Xunit;

namespace SpectTest.Student.AddStudent
{
    [Story(title: "ثبت یک دانشجو ",
       AsA = "سرپرست دانشگاه",
       InOrderTo = "تا در کلاس های دانشگاه ثبت نام کند",
       IWantTo = "یک دانشجو تعریف کنم"
   )]

    [Scenario(title: "ثبت یک دانشجو با کد ملی تکراری")]
    public class Failed : EFDataContextDatabaseFixture
    {
        private readonly EFDataContext _dbContext;
        private readonly StudentAppService _sut;
        private AddStudentDto _dto;

        public Failed()
        {
            _dbContext = CreateDataContext();
            _sut = StudentFactory.GenerateServices(_dbContext);
        }

        [Given(description: "یک دانشجو به نام حسن با کد ملی " +
            "۲۲۳۳ در فهرست دانشجویان دانشگاه وجود دارد ")]
        public void Given()
        {
            _dto = StudentFactory.GenerateAddStudentDto();
            _sut.Add(_dto);
        }

        [When(description: "یک دانشجو به نام حسن با کد ملی ۲۲۳۳ را ثبت میکنیم")]
        public void When()
        {
            var _duplicateNationalCode = "2233";
            var _dtoWithDuplicateNationalCode = StudentFactory.
                                                    GenerateAddStudentDto(_duplicateNationalCode);

            _sut.Add(_dtoWithDuplicateNationalCode);
        }

        [Then(description: "باید تنها یک دانشجو به نام حسن با کد م" +
            "لی ۲۲۳۳ در فهرست دانشچویان دانشگاه وجود داشته باشد " +
            "و خطای کد ملی تکراری است رخ دهد")]
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

