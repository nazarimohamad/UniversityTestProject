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

        public void Add(StudentModel student)
        {
            _students.Add(student);
        }
    }
}