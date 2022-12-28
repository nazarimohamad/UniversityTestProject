using Xunit;
using System;
using System.Linq;
using PersistanceEF;
using Services.Teacher;
using FluentAssertions;
using TestTools.Teacher;
using Entities.Teacher;
using UnitTest.Infrastructure;
using Services.Teacher.Exceptions;

namespace UnitTest.Teacher
{
    public class TeacherAppTest
    {
        private readonly EFDataContext _dbContext;
        private readonly TeacherAppService _sut;
        public TeacherAppTest()
        {
            _dbContext = new EFInMemoryDatabase().CreateDataContext<EFDataContext>();
            _sut = TeacherFactory.GenerateServices(_dbContext);
        }

        [Fact]
        public void Add_teacher_properly()
        {
            var _addDto = TeacherFactory.GenerateAddTeacherDto();
            _sut.AddTeacher(_addDto);

            var actual = _dbContext.Set<TeacherModel>().First();

            actual.FirstName.Should().Be(_addDto.FirstName);
            actual.LastName.Should().Be(_addDto.LastName);
            actual.Code.Should().Be(_addDto.Code);
        }

        [Fact]
        public void Failed_to_add_teacher_with_duplicated_teacherCode()
        {
            var _addDto = TeacherFactory.GenerateAddTeacherDto();
            _sut.AddTeacher(_addDto);

            var _duplicatedTeacherCode = 21;
            var _duplicatedTeacherCodeDto = TeacherFactory.
                                    GenerateAddTeacherDto(_duplicatedTeacherCode);

            Action actual = () => _sut.AddTeacher(_duplicatedTeacherCodeDto);
            actual.Should().ThrowExactly<DuplicatedTeacherCodeException>();
        }

        [Fact]
        public void Delete_teacher_with_no_course_properly()
        {
            var _addDto = TeacherFactory.GenerateAddTeacherDto();
            _dbContext.Manipulate(_ => _.Add(_addDto));

            var _idForDelete = _dbContext.Set<TeacherModel>().
                                            SingleOrDefault(
                                                _ => _.Code == _addDto.Code)!.Id;

            Action actual = () => _sut.Delete(_idForDelete);
            actual.Should().BeNull();
        }
    }
}

