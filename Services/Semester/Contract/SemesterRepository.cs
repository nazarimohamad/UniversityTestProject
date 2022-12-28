using Entities.Semesters;
using Services.Semester.Contract.Dtos;

namespace Services.Semester.Contract
{
    public interface SemesterRepository
    {
        public void Add(SemesterModel model);
        bool isExist(int number, int year);
        SemesterModel? Find(int id);
        void Delete(SemesterModel model);
        List<GetSemesterDto> GetAll();
    }
}

