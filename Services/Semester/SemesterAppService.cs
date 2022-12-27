using Entities.Semesters;
using Services.SharedContracts;
using Services.Semester.Contract;
using Services.Semester.Exceptions;
using Services.Semester.Contract.Dtos;

namespace Services.Semester
{
    public class SemesterAppService : SemesterService
    {
        private SemesterRepository _semsters;
        private UnitOfWork _unitOfWork;

        public SemesterAppService(SemesterRepository semsters, UnitOfWork unitOfWork)
        {
            _semsters = semsters;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddSemesterDto dto)
        {
            StopIfSemesterExist(dto);
            _semsters.Add(GenerateSemesterModel(dto));
            _unitOfWork.Compelete();
        }

        private void StopIfSemesterExist(AddSemesterDto dto)
        {
            if(_semsters.isExist(dto.Number, dto.Year))
            {
                throw new DuplicateSemesterException();
            }
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