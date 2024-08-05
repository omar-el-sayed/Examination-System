namespace ExaminationSystem.DTOs.Question
{
    public class CreateQuestionDto
    {
        public string Text { get; set; } = string.Empty;
        public int Grade { get; set; }
    }
}
