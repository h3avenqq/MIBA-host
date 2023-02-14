using MIBA.Data;
using MIBA.Models;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Mvc;

namespace MIBA.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ISaveFileService _saveFile;
        private readonly IWebHostEnvironment _appEnvironment;

        public NewsController(ApplicationDbContext db, IWebHostEnvironment appEnvironment, ISaveFileService saveFile)
        {
            _db = db;
            _saveFile = saveFile;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<News> dbList = _db.News;
            return View(dbList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewsRequest request)
        {
            if(!ModelState.IsValid)
                return View(request);

            var entity = new News(request);

            entity.Photo = String.Empty;
            if (request.Photo != null)
            {
                entity.Photo = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/NewsMedia/", request.Photo);
            }
            else if (request.PhotoUrl != null)
            {
                entity.Photo = request.PhotoUrl;
            }

            _db.News.Add(entity);
            _db.SaveChanges();
            TempData["success"] = "Новость успешно создана";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();

            var obj = _db.News.First(x => x.Id == id);

            if (obj == null)
                return NotFound();

            var entity = new NewsRequest(obj);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewsRequest request)
        {
            var entity = _db.News.Find(request.Id);

            if (entity == null)
                return View(request);

            entity.Title = request.Title;
            entity.BriefDescription = request.BriefDescription;
            entity.Description = request.Description;


            if (request.Photo != null)
            {
                entity.Photo = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/NewsMedia/", request.Photo);
            }
            else if (request.PhotoUrl != null)
            {
                entity.Photo = request.PhotoUrl;
            }

            _db.SaveChanges();
            TempData["success"] = "Новость успешно изменена";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.News.Find(id);

            if (obj == null)
                return NotFound();

            _db.News.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Новость успешно удалена";

            return RedirectToAction("Index");
        }
    }
}
