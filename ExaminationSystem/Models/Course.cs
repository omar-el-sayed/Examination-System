namespace ExaminationSystem.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public HashSet<Exam> Exams { get; set; }
    }
}
