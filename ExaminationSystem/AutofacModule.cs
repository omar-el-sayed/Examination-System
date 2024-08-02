using Autofac;
using ExaminationSystem.Data;
using ExaminationSystem.Repositories;
using ExaminationSystem.Services.Courses;
using ExaminationSystem.Services.ExamQuestions;
using ExaminationSystem.Services.Exams;
using ExaminationSystem.Services.Instructors;
using ExaminationSystem.Services.Questions;
using ExaminationSystem.Services.Students;

namespace ExaminationSystem
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamQuestionService>().As<IExamQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<InstructorService>().As<IInstructorService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
        }
    }
}
