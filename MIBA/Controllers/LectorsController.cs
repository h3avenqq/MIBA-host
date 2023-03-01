using MIBA.Data;
using MIBA.Models;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;

namespace MIBA.Controllers
{
    public class LectorsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ISaveFileService _saveFile;
        private readonly IWebHostEnvironment _appEnvironment;

        public LectorsController(ApplicationDbContext db, IWebHostEnvironment appEnvironment, ISaveFileService saveFile)
        {
            _db = db;
            _saveFile = saveFile;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Lectors> dbList = _db.Lectors;
            return View(dbList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LectorsRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity = new Lectors(request);

                entity.PhotoUrl = null;
                if (request.Photo != null)
                {
                    entity.PhotoUrl = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/NewsMedia/", request.Photo);
                }
                else if (request.PhotoUrl != null)
                {
                    entity.PhotoUrl = request.PhotoUrl;
                }

                _db.Lectors.Add(entity);
                _db.SaveChanges();
                TempData["success"] = "Лектор успешно добавлен";
                return RedirectToAction("Index");
            }

            return View(request);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDb = _db.Lectors.Find(id);
            if (objFromDb == null)
            {
                return NotFound();
            }

            var entity = new LectorsRequest(objFromDb);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LectorsRequest request)
        {
            if (ModelState.IsValid)
            {
                var entity = _db.Lectors.Find(request.Id);

                if (entity == null)
                    return View(request);

                entity.FullName = request.FullName;
                entity.About = request.About;
                entity.Studies = request.Studies;

                if (request.Photo != null)
                {
                    entity.PhotoUrl = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/NewsMedia/", request.Photo);
                }
                else if (request.PhotoUrl != null)
                {
                    entity.PhotoUrl = request.PhotoUrl;
                }

                _db.SaveChanges();
                TempData["success"] = "Лектор успешно изменена";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.Lectors.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Lectors.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Лектор успешно удалена";

            return RedirectToAction("Index");
        }
    }
}
