using Xunit;
using System.Linq;
using PersistanceEF;
using Entities.Student;
using FluentAssertions;
using Services.Student;
using TestTools.Student;
using UnitTest.Infrastructure;
using System;

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

        [Fact]
        public void Fail_to_eddd_student_with_duplicate_nationalcode()
        {
            var _dto = StudentFactory.GenerateAddStudentDto();
            _dbContext.Manipulate(_ => _.Add(_dto));

            string _duplicateNationalCode = "2233";
            var _dtoWithDuplicateNationalCode =
                                StudentFactory.
                                        GenerateAddStudentDto(_duplicateNationalCode);

            Action action = () => _sut.Add(_dtoWithDuplicateNationalCode);

            action.Should().ThrowExactly<DuplicateNationalCodeException>();
        }

        [Fact]
        public void Edit_student_Properly()
        {
            string _nationalCode = "2233";
            string _editedName = "علی";
            var _dto = StudentFactory.GenerateAddStudentDto(_nationalCode);
            _dbContext.Manipulate(_ => _.Add(_dto));
            var _modelForEdit = _dbContext.Set<StudentModel>()
                                            .SingleOrDefault(_ =>
                                            _.NationalCode == _nationalCode);
            var _idForDelete = _modelForEdit.Id;
            var _editedDto = StudentFactory.GenerateEditStudentDto(_editedName);

            _sut.Edit(_idForDelete, _editedDto);

            var actual = _dbContext.Set<StudentModel>()
                                            .SingleOrDefault(_ =>
                                            _.NationalCode == _nationalCode);

            actual.FullName.Should().Be(_editedDto.FullName);
            actual.NationalCode.Should().Be(_editedDto.NationalCode);
        }

        [Fact]
        public void Delete_student_by_id()
        {
            string _nationalCode = "2233";
            var _dto = StudentFactory.GenerateAddStudentDto(_nationalCode);
            _dbContext.Manipulate(_ => _.Add(_dto));
            var _idForDelete = _dbContext.Set<StudentModel>()
                                            .SingleOrDefault(_ =>
                                            _.NationalCode == _nationalCode)!.Id;

            Action action = () => _sut.Delete(_idForDelete);

            action.Should().BeNull();
        }
    }
}

