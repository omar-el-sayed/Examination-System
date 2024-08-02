using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Course;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.ExamQuestion;
using ExaminationSystem.ViewModels.Instructor;
using ExaminationSystem.ViewModels.Question;
using ExaminationSystem.ViewModels.Student;

namespace ExaminationSystem.Helpers
{
    public static class Mapper
    {
        #region Instructor
        public static InstructorVM ToViewModel(this Instructor instructor)
        {
            return new InstructorVM
            {
                FirstName = instructor.FirstName,
                LastName = instructor.LastName
            };
        }

        public static IEnumerable<InstructorVM> ToViewModel(this IQueryable<Instructor> instructors)
        {
            return instructors.Select(i => i.ToViewModel());
        }

        public static Instructor ToModel(this CreateInstructorVM viewModel)
        {
            return new Instructor
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Salary = viewModel.Salary
            };
        }
        #endregion

        #region Course
        public static CourseVM ToViewModel(this Course course)
        {
            return new CourseVM
            {
                Name = course.Name,
                CreditHours = course.CreditHours
            };
        }

        public static IEnumerable<CourseVM> ToViewModel(this IQueryable<Course> courses)
        {
            return courses.Select(c => c.ToViewModel());
        }

        public static Course ToModel(this CourseVM viewModel)
        {
            return new Course
            {
                Name = viewModel.Name,
                CreditHours = viewModel.CreditHours
            };
        }

        #endregion

        #region Question
        public static QuestionVM ToViewModel(this Question question)
        {
            return new QuestionVM
            {
                Text = question.Text,
                Grade = question.Grade
            };
        }

        public static IEnumerable<QuestionVM> ToViewModel(this IQueryable<Question> questions)
        {
            return questions.Select(q => q.ToViewModel());
        }

        public static Question ToModel(this QuestionVM viewModel)
        {
            return new Question
            {
                Text = viewModel.Text,
                Grade = viewModel.Grade
            };
        }
        #endregion

        #region Student
        public static StudentVM ToViewModel(this Student student)
        {
            return new StudentVM
            {
                FullName = $"{student.FirstName} {student.LastName}"
            };
        }

        public static IEnumerable<StudentVM> ToViewModel(this IQueryable<Student> students)
        {
            return students.Select(q => q.ToViewModel());
        }

        public static Student ToModel(this CreateStudentVM viewModel)
        {
            return new Student
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };
        }
        #endregion

        #region Exam
        public static ExamVM ToViewModel(this Exam exam)
        {
            return new ExamVM
            {
                StartDate = exam.StartDate,
                TotalGrade = exam.TotalGrade
            };
        }

        public static IEnumerable<ExamVM> ToViewModel(this IQueryable<Exam> exams)
        {
            return exams.Select(q => q.ToViewModel());
        }

        public static Exam ToModel(this CreateExamVM viewModel)
        {
            return new Exam
            {
                StartDate = viewModel.StartDate,
                TotalGrade = viewModel.TotalGrade,
                InstructorId = viewModel.InstructorId,
                CourseId = viewModel.CourseId
            };
        }
        #endregion

        #region ExamQuestion
        public static ExamQuestion ToModel(this CreateExamQuestionVM viewModel)
        {
            return new ExamQuestion
            {
                ExamId = viewModel.ExamId,
                QuestionId = viewModel.QuestionId
            };
        }
        #endregion
    }
}
