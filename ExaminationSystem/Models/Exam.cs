namespace ExaminationSystem.Models
{
    public class Exam : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public HashSet<ExamQuestion> ExamQuestions { get; set; }
    }
}
