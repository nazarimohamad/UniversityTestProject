using System.Linq;
using Entities.Teacher;
using FluentAssertions;
using PersistanceEF;
using Services.Teacher;
using TestTools.Teacher;
using UnitTest.Infrastructure;
using Xunit;

namespace UnitTest.Teacher
{
    public class TeacherAppTest
    {
        private readonly EFDataContext _dbcontect;
        private readonly TeacherAppService _sut;
        public TeacherAppTest()
        {
            _dbcontect = new EFInMemoryDatabase().CreateDataContext<EFDataContext>();
            _sut = TeacherFactory.GenerateServices(_dbcontect);
        }

        [Fact]
        public void Add_teacher_properly()
        {
            var _addDto = TeacherFactory.GenerateAddTeacherDto();
            _sut.AddTeacher(_addDto);

            var actual = _dbcontect.Set<TeacherModel>().First();

            actual.FirstName.Should().Be(_addDto.FirstName);
            actual.LastName.Should().Be(_addDto.LastName);
            actual.Code.Should().Be(_addDto.Code);
        }
    }
}

