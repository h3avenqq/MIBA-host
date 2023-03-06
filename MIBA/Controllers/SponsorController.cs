using MIBA.Data;
using MIBA.Models;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Mvc;

namespace MIBA.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISaveFileService _saveFile;
        private readonly IWebHostEnvironment _appEnvironment;

        public SponsorController(ApplicationDbContext dbContext, ISaveFileService saveFile, IWebHostEnvironment appEnvironment)
        {
            _dbContext = dbContext;
            _saveFile = saveFile;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var entity = _dbContext.Sponsors.ToList();

            return View(entity);
        }

        public IActionResult Create()
        {
            var entity = new SponsorRequest();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SponsorRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var entity = new Sponsor(request);

            entity.Url = String.Empty;
            if (request.Photo != null)
            {
                entity.Url = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Investors/", request.Photo);
            }
            else if (request.Url != null)
            {
                entity.Url = request.Url;
            }

            _dbContext.Sponsors.Add(entity);
            _dbContext.SaveChanges();
            TempData["success"] = "Спонсор успешно добавлен";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();

            var entity = _dbContext.Sponsors.Find(id);

            if (entity == null)
                return NotFound();

            return View(new SponsorRequest(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SponsorRequest request)
        {
            var entity = _dbContext.Sponsors.Find(request.Id);

            if (entity == null)
                return View(request);

            entity.Name = request.Name;

            if (request.Photo != null)
            {
                entity.Url = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Investors/", request.Photo);
            }
            else if (request.Url != null)
            {
                entity.Url = request.Url;
            }

            _dbContext.SaveChanges();
            TempData["success"] = "Спонсор успешно изменен";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = _dbContext.Sponsors.Find(id);

            if (obj == null)
                return NotFound();

            _dbContext.Sponsors.Remove(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Спонсор успешно удален";

            return RedirectToAction("Index");
        }
    }
}
