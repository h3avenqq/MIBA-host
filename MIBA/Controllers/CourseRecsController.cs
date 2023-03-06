using MIBA.Data;
using MIBA.Models;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MIBA.Controllers
{
    public class CourseRecsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ISaveFileService _saveFile;
        private readonly IWebHostEnvironment _appEnvironment;
        public CourseRecsController(ApplicationDbContext db, IWebHostEnvironment appEnvironment, ISaveFileService saveFile)
        {
            _db = db;
            _appEnvironment = appEnvironment;
            _saveFile = saveFile;
        }
        public IActionResult Index()
        {
            return View(_db.CourseRecomendations.Include(x => x.Course).Include(x => x.Course.Categories).ToList());
        }

        public IActionResult Create()
        {
            return View(new CourseRecsAllCourses { Rec = new CourseRecomendationRequest(), AllCourses = _db.Studies.ToList()}) ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseRecomendationRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity = new CourseRecomendation();
                entity.Course = _db.Studies.Find(request.CourseId);
                entity.Photo = null;
                if (request.Photo != null)
                {
                    entity.Photo = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Recomend/", request.Photo);
                }
                else if (request.PhotoUrl != null)
                {
                    entity.Photo = request.PhotoUrl;
                }

                _db.CourseRecomendations.Add(entity);
                _db.SaveChanges();
                TempData["success"] = "Рекомендация успешно создана";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Ошибка при создании";
            return View(new CourseRecsAllCourses { Rec = request, AllCourses = _db.Studies.ToList() });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDb = _db.CourseRecomendations.Include(x => x.Course).First(x => x.Id == id);
            if (objFromDb == null)
            {
                return NotFound();
            }

            var entity = new CourseRecomendationRequest(objFromDb);

            return View(new CourseRecsAllCourses { Rec = entity, AllCourses = _db.Studies.ToList() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourseRecomendationRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity = _db.CourseRecomendations.Find(request.Id);

                if (entity == null)
                {
                    TempData["error"] = "Ошибка при изменении";
                    return View(new CourseRecsAllCourses { Rec = request, AllCourses = _db.Studies.ToList() });
                }

                entity.Course = _db.Studies.Find(request.CourseId);

                if (request.Photo != null)
                {
                    entity.Photo = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Recomend/", request.Photo);
                }
                else if (request.PhotoUrl != null)
                {
                    entity.Photo = request.PhotoUrl;
                }

                _db.SaveChanges();
                TempData["success"] = "Рекомендация успешно изменена";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.CourseRecomendations.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.CourseRecomendations.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Рекомендация успешно удалена";

            return RedirectToAction("Index");
        }
    }
}
