﻿using System.ComponentModel.DataAnnotations;

namespace Services.Course.Contract.Dtos
{
    public class EditCourseDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}