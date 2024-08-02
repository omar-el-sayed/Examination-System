namespace ExaminationSystem.ViewModels.Exam
{
    public class CreateExamVM
    {
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public ICollection<int> QuestionIds { get; set; }
    }
}
