using MIBA.Data;
using MIBA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace MIBA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(new CategoriesNewCourseNewsRecs
            {
                Categories = _db.StudyCategories.Include(x => x.Studies).ToList(),
                News = _db.News.ToList(),
                NewCourse = new NewCourse(),
                Documents = _db.Documents.ToList(),
                Recs = _db.CourseRecomendations.Include(x => x.Course).ToList(),
                Sponsors = _db.Sponsors.ToList()
            });
        }

        public async Task<IActionResult> NewCourseRequest(NewCourse obj)
        {
            obj.IsChecked = false;
            if (ModelState.IsValid)
            {
                await _db.NewCourse.AddAsync(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Заявка отправлена";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Заявка была заполнена некорректно";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}