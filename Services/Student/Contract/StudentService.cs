﻿using Services.Student.Contract.Dtos;

namespace Services.Student.Contract
{
    public interface StudentService
    {
        void Add(AddStudentDto dto);
    }
}