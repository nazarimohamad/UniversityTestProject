using Microsoft.AspNetCore.Mvc;
using Services.Student;
using Services.Student.Contract;
using Services.Student.Contract.Dtos;

namespace University.Controllers
{
    [Route("/api/student")]
    public class StudentController
    {
        private readonly StudentService _service;
        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet()]
        public List<GetStudentDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost()]
        public void Add([FromBody] AddStudentDto dto)
        {
            _service.Add(dto);
        }

        [HttpDelete()]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}

