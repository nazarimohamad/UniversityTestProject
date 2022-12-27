using System;
using Microsoft.AspNetCore.Mvc;
using Services.Semester.Contract;
using Services.Semester.Contract.Dtos;

namespace University.Controllers
{
    [Route("/api/semester")]
    public class SemesterController : ControllerBase
    {
        private readonly SemesterService _service;
        public SemesterController(SemesterService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add([FromBody] AddSemesterDto dto)
        {
            _service.Add(dto);
        }
    }
}





