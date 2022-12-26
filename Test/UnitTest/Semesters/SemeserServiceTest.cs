﻿using Xunit;
using System.Linq;
using PersistanceEF;
using FluentAssertions;
using Services.Semester;
using Entities.Semesters;
using TestTools.Semester;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using UnitTest.Infrastructure;

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
            
        }

        [Fact]
        public void Add_semester_properly()
        {
            var dto = SemesterFactory.GenerateSemesterDto();

            _sut.Add(dto);

            var actualPerson = _dbContext.Set<SemesterModel>().First();
            actualPerson.Number.Should().Be(dto.Number);
            actualPerson.Year.Should().Be(dto.Year);
        }
    }
}

