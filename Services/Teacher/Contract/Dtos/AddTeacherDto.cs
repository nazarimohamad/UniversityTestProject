using System.ComponentModel.DataAnnotations;

namespace Services.Teacher.Contract.Dtos
{
    public class AddTeacherDto
    {
        [Required]
        public int Code { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public List<int> CoursesId { get; set; }
    }
}