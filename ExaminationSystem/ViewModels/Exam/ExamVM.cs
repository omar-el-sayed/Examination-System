namespace ExaminationSystem.ViewModels.Exam
{
    public class ExamVM
    {
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }
        public string Instructor { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public int NumOfQuestions { get; set; }
    }
}
