using ExaminationSystem.Helpers;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using ExaminationSystem.ViewModels.Instructor;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IGenericRepository<Instructor> _repository;

        public InstructorController()
        {
            //_repository = new GenericRepository<Instructor>();
        }

        [HttpGet]
        public IEnumerable<InstructorVM> GetAll()
        {
            var instructors = _repository.GetAll();

            return instructors.ToViewModel();

            #region Old

            //ApplicationDbContext context = new ApplicationDbContext();

            //// deferred execution التنفيذ المؤجل
            //IQueryable<InstructorVM> query = context.Instructors
            //    .Select(i => new InstructorVM { FirstName = i.FirstName, LastName = i.LastName });

            ////immediate execution التنفيذ الفورى
            ////var query = context.Instructors
            ////    .Select(i => new InstructorVM { FirstName = i.FirstName, LastName = i.LastName })
            ////    .ToList();

            ////immendiate execution
            ////var query2 = context.Instructors
            ////     .FirstOrDefault(x => x.Id > 1);

            ////var result = query.ToList(); //immediate execution will fetch all instructors data from DB (10).

            //foreach (var instructor in query) //immediate execution will fetch instructors data from DB one by one from SQL buffer.
            //{
            //    Debug.WriteLine(instructor.FullName);
            //}

            //return query.ToList();

            #endregion
        }

        [HttpGet]
        public IEnumerable<InstructorVM> GetByCondition()
        {
            return _repository.Get(i => i.Id < 100).ToViewModel();
        }

        [HttpGet("{id}")]
        public InstructorVM GetById(int id)
        {
            var instructor = _repository.GetById(id);

            return instructor is not null ? instructor.ToViewModel() : new InstructorVM();

            #region Old
            //ApplicationDbContext context = new ApplicationDbContext();
            //return context.Instructors
            //    .Where(i => i.Id == id)
            //    .Select(i => new InstructorVM { FirstName = i.FirstName, LastName = i.LastName })
            //    .FirstOrDefault();
            #endregion
        }

        [HttpPost]
        public bool Add(CreateInstructorVM viewModel)
        {
            var instructor = viewModel.ToModel();

            _repository.Add(instructor);
            _repository.SaveChanges();

            return true;
        }

        [HttpPut("{id}")]
        public bool Update(int id, CreateInstructorVM viewModel)
        {
            var instructor = _repository.GetByIdWithTracking(id);

            if (instructor is null)
                return false;

            instructor.FirstName = viewModel.FirstName;
            instructor.LastName = viewModel.LastName;
            instructor.Salary = viewModel.Salary;

            _repository.Update(instructor);
            _repository.SaveChanges();

            return true;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var instructor = _repository.GetByIdWithTracking(id);

            if (instructor is null)
                return false;

            _repository.Delete(instructor);
            _repository.SaveChanges();

            return true;
        }

        [HttpGet]
        public int MinSalary()
        {
            return _repository.Min(i => Convert.ToInt32(i.Salary));
        }

        [HttpGet]
        public double MaxSalary()
        {
            return _repository.Max(i => Convert.ToInt32(i.Salary));
        }

        [HttpGet]
        public int Count()
        {
            return _repository.Count();
        }
    }
}
