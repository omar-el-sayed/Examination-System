namespace ExaminationSystem.Models
{
    public class Instructor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public HashSet<Exam> Exams { get; set; }
    }
}
