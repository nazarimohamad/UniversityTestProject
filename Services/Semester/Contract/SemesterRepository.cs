using Entities.Semesters;

namespace Services.Semester.Contract
{
    public interface SemsterRepository
    {
        void Add(SemesterModel model);
    }
}

