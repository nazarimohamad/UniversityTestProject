using System.ComponentModel.DataAnnotations;

namespace Services.Course.Contract.Dtos
{
    public class AddCourseDto
    {
        public AddCourseDto()
        {
            
        }

        [Required]
        public string Title { get; set; }
    }
}