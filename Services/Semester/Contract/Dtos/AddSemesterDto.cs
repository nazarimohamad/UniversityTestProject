using System.ComponentModel.DataAnnotations;

namespace Services.Semester.Contract.Dtos
{
    public class AddSemesterDto
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public int Year { get; set; }
    }
}