using Microsoft.AspNetCore.Mvc;
using Services.Course.Contract;
using Services.Course.Contract.Dtos;

namespace University.Controllers
{
    [Route("/api/course")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _service;
        public CourseController(CourseService service)
        {
            _service = service;
        }

         [HttpPost()]
         public void AddCourse(AddCourseDto dto)
         {
             _service.Add(dto);
         }
    }
}

