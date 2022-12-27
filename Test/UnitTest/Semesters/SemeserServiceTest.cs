using Xunit;
using System.Linq;
using PersistanceEF;
using FluentAssertions;
using Services.Semester;
using Entities.Semesters;
using TestTools.Semester;
using UnitTest.Infrastructure;
using Services.Semester.Exceptions;
using System;

namespace UnitTest.Semesters

{
    public class SemeserServiceTest
    {
        private readonly EFDataContext _dbContext;
        private readonly SemesterAppService _sut;

        public SemeserServiceTest()
        {
            //DbConnection connection = Effort.DbConnectionFactory.CreateTransient();

            _dbContext = new EFInMemoryDatabase().CreateDataContext<EFDataContext>();
            _sut = SemesterFactory.GenerateServices(_dbContext);
            
        }

        [Fact]
        public void Add_semester_properly()
        {
            var dto = SemesterFactory.GenerateSemesterDto();

            _sut.Add(dto);

            var actual = _dbContext.Set<SemesterModel>().First();
            actual.Number.Should().Be(dto.Number);
            actual.Year.Should().Be(dto.Year);
        }

        [Fact]
        public void Failed_to_add_duplicated_semester_properly()
        {
            var semester = SemesterFactory.GenerateSemester();
            _dbContext.Manipulate(_ => _.Add(semester));

            var duplicateSemesterDto = SemesterFactory.GenerateSemesterDto();

            Action actual = () => _sut.Add(duplicateSemesterDto);

            actual.Should().ThrowExactly<DuplicateSemesterException>();

        }


        [Fact]
        public void Delete_semester_properly()
        {
            var semester = SemesterFactory.GenerateSemester();
            _dbContext.Manipulate(_ => _.Add(semester));
            var findedSemster = _dbContext.Set<SemesterModel>().First();
            var idForDelete = findedSemster.Id;

            _sut.Delete(idForDelete);

            var _findedSemsterAfterDelete = _dbContext.Set<SemesterModel>()
                                    .SingleOrDefault(_ => _.Id == idForDelete);

            _findedSemsterAfterDelete.Should().BeNull();
        }
    }
}

