using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.Helpers;
using ExaminationSystem.Services.Instructors;
using ExaminationSystem.ViewModels.Instructor;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController(IInstructorService service) : ControllerBase
    {
        [HttpGet("getall")]
        public IEnumerable<InstructorVM> GetAll()
            => service.GetAll().AsQueryable().Map<InstructorVM>();
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

        [HttpGet("get")]
        public IEnumerable<InstructorVM> GetByCondition()
            => service.Get().AsQueryable().Map<InstructorVM>();

        [HttpGet("getbyid/{id}")]
        public InstructorVM GetById(int id)
            => service.GetById(id).Map<InstructorVM>();
        #region Old
        //ApplicationDbContext context = new ApplicationDbContext();
        //return context.Instructors
        //    .Where(i => i.Id == id)
        //    .Select(i => new InstructorVM { FirstName = i.FirstName, LastName = i.LastName })
        //    .FirstOrDefault();
        #endregion

        [HttpPost("add")]
        public bool Add(CreateInstructorVM viewModel)
            => service.Add(viewModel.Map<CreateInstructorDto>());

        [HttpPut("update")]
        public bool Update(UpdateInstructorVM viewModel)
            => service.Update(viewModel.Map<UpdateInstructorDto>());

        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
            => service.Delete(id);

        [HttpGet("min")]
        public double MinSalary()
            => service.Min();

        [HttpGet("max")]
        public double MaxSalary()
            => service.Max();

        [HttpGet("count")]
        public int Count()
            => service.Count();
    }
}
