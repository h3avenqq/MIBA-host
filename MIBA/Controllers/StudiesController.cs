using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using MIBA.Data;
using MIBA.Enums;
using MIBA.Models;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MIBA.Controllers
{
    public class StudiesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ISaveFileService _saveFile;
        private readonly IWebHostEnvironment _appEnvironment;
        public StudiesController(ApplicationDbContext db, IWebHostEnvironment appEnvironment, ISaveFileService saveFile)
        {
            _db = db;
            _saveFile = saveFile;
            _appEnvironment = appEnvironment;
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
            if (ModelState.IsValid)
            {
                Studies elem = new Studies(obj, _db);
                _db.Studies.Add(new Studies(obj, _db));
                _db.SaveChanges();
                TempData["success"] = "Курс успешно добавлен";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            StudyCategoriesRequest model = new StudyCategoriesRequest();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(StudyCategoriesRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var model = new StudyCategories(request);

            model.Photo = String.Empty;
            if (request.Photo != null)
            {
                model.Photo = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Studies/", request.Photo);
            }
            else if (request.PhotoUrl != null)
            {
                model.Photo = request.PhotoUrl;
            }

            _db.StudyCategories.Add(model);
            _db.SaveChanges();
            TempData["success"] = "Категория успешно создана";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCourse(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            Studies obj = _db.Studies.Include(x => x.Lectors).Include(x => x.Categories).First(x => x.Id == id);
            if (obj == null)
                return NotFound();

            CourseAndLectors model = new CourseAndLectors { Studies = new CourseRequest(obj), Lectors = _db.Lectors.ToList() };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCourse(CourseRequest request)
        {
            if (ModelState.IsValid)
            {
                Studies model = new Studies(request, _db);
                model.Id = request.Id;
                var obj = _db.Studies.Include(x => x.Lectors).Include(x => x.Categories).First(x => x.Id == request.Id);
                obj.Title = model.Title;
                obj.Description = model.Description;
                obj.StudyFormat = model.StudyFormat;
                obj.StartTime = model.StartTime;
                obj.EndTime = model.EndTime;
                obj.Cost = model.Cost;
                obj.DocumentAfter = model.DocumentAfter;
                obj.InfoToKnow = model.InfoToKnow;
                obj.InfoToCan = model.InfoToCan;
                obj.InfoToUse = model.InfoToUse;
                obj.CourseProgramm = model.CourseProgramm;
                obj.Lectors = model.Lectors;
                _db.SaveChanges();
                TempData["success"] = "Курс успешно изменен";
                return RedirectToAction("Index");
            }
            return View(request.Id);
        }

        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();

            var obj = _db.StudyCategories.First(x => x.Id == id);

            if (obj == null)
                return NotFound();

            var model = new StudyCategoriesRequest(obj);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(StudyCategoriesRequest request)
        {
            var model = _db.StudyCategories.Find(request.Id);

            if (model == null)
                return View(request);

            model.Name = request.Name;

            if (request.Photo != null)
            {
                model.Photo = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Categories/", request.Photo);
            }
            else if (request.PhotoUrl != null)
            {
                model.Photo = request.PhotoUrl;
            }

            _db.SaveChanges();
            TempData["success"] = "Категория успешно изменена";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int? id)
        {
            var obj = _db.StudyCategories.Find(id);

            if (obj == null)
                return NotFound();

            _db.StudyCategories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Категория успешно удалена";

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCourse(int? id)
        {
            var obj = _db.Studies.Find(id);

            if (obj == null)
                return NotFound();

            _db.Studies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Курс успешно удален";

            return RedirectToAction("Index");
        }
    }
}
