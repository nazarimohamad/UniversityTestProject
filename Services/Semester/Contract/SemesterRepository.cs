using Entities.Semesters;

namespace Services.Semester.Contract
{
    public interface SemesterRepository
    {
        public void Add(SemesterModel model);
    }
}

