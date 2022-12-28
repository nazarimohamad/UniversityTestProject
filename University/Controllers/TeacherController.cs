﻿using Microsoft.AspNetCore.Mvc;
using Services.Teacher;
using Services.Teacher.Contract.Dtos;

namespace University.Controllers
{
    [Route("/api/teacher")]
    public class TeacherController
    {
        private readonly TeacherService _service;
        public TeacherController(TeacherService service)
        {
            _service = service;
        }

        [HttpPost()]
        public int Add([FromBody] AddTeacherDto dto)
        {
            return _service.AddTeacher(dto);
        }
    }
}

