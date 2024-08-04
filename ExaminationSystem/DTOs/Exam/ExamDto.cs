﻿namespace ExaminationSystem.DTOs.Exam
{
    public class ExamDto
    {
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
    }
}
