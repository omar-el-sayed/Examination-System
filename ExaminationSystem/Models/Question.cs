namespace ExaminationSystem.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public int Grade { get; set; }
        public HashSet<Choice> Choices { get; set; }
        public HashSet<ExamQuestion> ExamQuestions { get; set; }
    }
}
