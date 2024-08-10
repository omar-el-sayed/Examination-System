using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.Services.ExamQuestions;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Instructors;

namespace ExaminationSystem.Mediators.Exam
{
    public class ExamMediator(IExamService examService, IInstructorService instructorService, IExamQuestionService examQuestionService) : IExamMediator
    {
        public void Add(CreateExamDto examDto)
        {
            // Add exam

            // Add exam question

            // Increase instructor points
        }
    }
}
