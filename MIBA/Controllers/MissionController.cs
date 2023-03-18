using ClosedXML.Excel;
using MIBA.Data;
using MIBA.Models;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MIBA.Controllers
{
    [Authorize]
    public class MissionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ISaveFileService _saveFile;
        private readonly IWebHostEnvironment _appEnvironment;

        public MissionController(ApplicationDbContext db, IWebHostEnvironment appEnvironment, ISaveFileService saveFile)
        {
            _db = db;
            _saveFile = saveFile;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Mission> dbList = _db.Missions;
            return View(dbList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MissionRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Ошибка при заполнении формы";
                return View(request);
            }

            if (request.PhotoUrl == null && request.Photo == null)
            {
                TempData["error"] = "Добавьте фото для миссии";
                return View(request);
            }

            var entity = new Mission(request);
            if (request.Photo != null)
            {
                entity.PhotoUrl = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/MissionMedia/", request.Photo);
            }
            else
            {
                entity.PhotoUrl = request.PhotoUrl;
            }

            _db.Missions.Add(entity);
            _db.SaveChanges();

            TempData["success"] = "Миссия успешно добавлена";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDb = _db.Missions.Find(id);
            if (objFromDb == null)
            {
                return NotFound();
            }

            var entity = new MissionRequest(objFromDb);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MissionRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Ошибка при заполнении формы";
                return View(request);
            }

            if (request.PhotoUrl == null && request.Photo == null)
            {
                TempData["error"] = "Добавьте фото для миссии";
                return View(request);
            }

            var entity = _db.Missions.Find(request.Id);

            if (entity == null)
                return View(request);

            entity.Title = request.Title;
            entity.SubTitle = request.SubTitle;
            if (request.Photo != null)
            {
                entity.PhotoUrl = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/MissionMedia/", request.Photo);
            }
            else
            {
                entity.PhotoUrl = request.PhotoUrl;
            }

            _db.SaveChanges();
            TempData["success"] = "Миссия успешно изменена";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.Missions.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Missions.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Миссия успешно удалена";

            return RedirectToAction("Index");
        }
    }
}
