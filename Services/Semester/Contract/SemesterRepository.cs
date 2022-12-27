using Entities.Semesters;

namespace Services.Semester.Contract
{
    public interface SemesterRepository
    {
        public void Add(SemesterModel model);
        bool isExist(int number, int year);
        SemesterModel? Find(int id);
        void Delete(SemesterModel model);
    }
}

