namespace ExaminationSystem.ViewModels.Instructor
{
    public class InstructorVM
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
    }
}
