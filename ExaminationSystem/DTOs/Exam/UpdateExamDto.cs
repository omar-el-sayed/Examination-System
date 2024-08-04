namespace ExaminationSystem.DTOs.Exam
{
    public class UpdateExamDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public ICollection<int> QuestionIds { get; set; }
    }
}
