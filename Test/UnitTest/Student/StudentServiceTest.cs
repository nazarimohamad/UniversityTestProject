using Xunit;
using System.Linq;
using PersistanceEF;
using Entities.Student;
using FluentAssertions;
using Services.Student;
using TestTools.Student;
using UnitTest.Infrastructure;

namespace UnitTest.Student
{
    public class StudentServiceTest
    {
        private readonly EFDataContext _dbContext;
        private readonly StudentAppService _sut;
        public StudentServiceTest()
        {
            _dbContext = new EFInMemoryDatabase().CreateDataContext<EFDataContext>();
            _sut = StudentFactory.GenerateServices(_dbContext);
        }

        [Fact]
        public void Add_student_properly()
        {
            var _dto = StudentFactory.GenerateAddStudentDto();
            _sut.Add(_dto);

            var actual = _dbContext.Set<StudentModel>().First();

            actual.FullName.Should().Be(_dto.FullName);
            actual.NationalCode.Should().Be(_dto.NationalCode);
        }
    }
}

