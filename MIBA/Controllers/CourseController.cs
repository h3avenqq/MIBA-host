using MIBA.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MIBA.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            var obj = _db.Studies.Include(x => x.Lectors).FirstOrDefault(x => x.Id == id);
            return View(obj);
        }
    }
}
