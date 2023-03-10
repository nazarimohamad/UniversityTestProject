using System;
using Entities.Teacher;
using Services.Teacher;
using Microsoft.EntityFrameworkCore;
using Services.Teacher.Contract.Dtos;

namespace PersistanceEF.Teacher
{
    public class EFTeacherRepository : TeacherRepository
    {
        private DbSet<TeacherModel>  _teachers;
        public EFTeacherRepository(EFDataContext dbContext)
        {
            _teachers = dbContext.Set<TeacherModel>();
        }

        public void Add(TeacherModel teacherModel)
        {
             _teachers.Add(teacherModel);
        }

        public void Delete(TeacherModel teacher)
        {
            _teachers.Remove(teacher);
        }

        public TeacherModel FindById(int id)
        {
            return _teachers.SingleOrDefault(_ => _.Id == id)!;
        }

        public List<GetTeacherDto> GetAll()
        {
            return _teachers.Select(_ =>
                new GetTeacherDto
                {
                    FirstName = _.FirstName,
                    LastName = _.LastName,
                    Code = _.Code
                }
            ).ToList();
        }

        public bool IsExcist(int code)
        {
            return _teachers.Any(_ => _.Code == code);
        }
    }
}

