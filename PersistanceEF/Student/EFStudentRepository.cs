using Entities.Student;
using Services.Student;
using Microsoft.EntityFrameworkCore;

namespace PersistanceEF.Student
{
    public class EFStudentRepository : StudentRepository
    {
        private DbSet<StudentModel> _students;

        public EFStudentRepository(EFDataContext dbContext)
        {
            _students = dbContext.Set<StudentModel>();
        }

        public List<GetStudentDto> GetAll()
        {
           return _students.Select(_ =>
               new GetStudentDto
               {
                   Id = _.Id,
                   FullName = _.FullName,
                   NationalCode = _.NationalCode
               }
            ).ToList();
        }

        public void Add(StudentModel student)
        {
            _students.Add(student);
        }

        public void Delete(StudentModel studentForDelete)
        {
            _students.Remove(studentForDelete);
        }

        public StudentModel? Find(int id)
        {
            return _students.SingleOrDefault(_ => _.Id == id);
        }

        public bool IsExist(string nationalCode)
        {
            return _students.Any(_ => _.NationalCode == nationalCode);
        }
    }
}