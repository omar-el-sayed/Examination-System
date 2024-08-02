namespace ExaminationSystem.Models
{
    public class Choice : BaseEntity
    {
        public string Text { get; set; }
        public bool IsRightAnswer { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
