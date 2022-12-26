using Entities.Semesters;
using Services.SharedContracts;
using Services.Semester.Contract;
using Services.Semester.Contract.Dtos;

namespace Services.Semester
{
    public class SemesterAppService : SemesterService
    {
        private SemsterRepository _semsters;
        private UnitOfWork _unitOfWork;

        public SemesterAppService(SemsterRepository semsters, UnitOfWork unitOfWork)
        {
            _semsters = semsters;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddSemesterDto dto)
        {
            var model = GenerateSemesterModel(dto);
            _semsters.Add(model);
            _unitOfWork.Compelete();
        }

        private SemesterModel GenerateSemesterModel(AddSemesterDto dto)
        {
            return new SemesterModel
            {
                Number = dto.Number,
                Year = dto.Year
            };
        }
    }
}