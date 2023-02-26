using MIBA.Data;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Mvc;

namespace MIBA.Controllers
{
    public class NewCourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        public NewCourseController(ApplicationDbContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View(_db.NewCourse.ToList());
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.NewCourse.Find(id);

            if (obj == null)
                return NotFound();

            _db.NewCourse.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Заявка успешно удалена";

            return RedirectToAction("Index");
        }
    }
}
