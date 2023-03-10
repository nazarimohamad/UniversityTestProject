using Entities.Semesters;
using Services.Semester.Contract.Dtos;

namespace Services.Semester.Contract
{
    public interface SemesterService
    {
        public void Add(AddSemesterDto dto);
        void Delete(int idForDelete);
        List<GetSemesterDto> GetAll();
    }
}

