using MIBA.Data;
using MIBA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MIBA.Controllers
{
    public class StudiesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudiesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.StudyCategories.Include(x => x.Studies).ToList());
        }
        [HttpGet]
        public IActionResult CreateCourse(int id)
        {
            if (_db.StudyCategories.Find(id) == null || id == 0)
            {
                return NotFound();
            }

            CourseRequest course = new CourseRequest { CategoryId = id };
            CourseAndLectors model = new CourseAndLectors { Studies = course, Lectors = _db.Lectors.ToList() };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseRequest obj)
        {
            if(ModelState.IsValid)
            {
                Studies elem = new Studies(obj, _db);
                _db.Studies.Add(new Studies(obj, _db));
                _db.SaveChanges();
                TempData["success"] = "Курс успешно добавлен";
                RedirectToAction("Index");
            }
            return View();
        }
    }
}
