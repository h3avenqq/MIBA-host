using MIBA.Data;
using MIBA.Models;
using MIBA.Services.SaveFileService;
using Microsoft.AspNetCore.Mvc;

namespace MIBA.Controllers
{
    public class DocumentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISaveFileService _saveFile;
        private readonly IWebHostEnvironment _appEnvironment;

        public DocumentController(ApplicationDbContext dbContext, ISaveFileService saveFile, IWebHostEnvironment appEnvironment)
        {
            _dbContext = dbContext;
            _saveFile = saveFile;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index(int id)
        {
            var entity = _dbContext.Documents.ToList();

            return View(entity);
        }

        public IActionResult Create()
        {
            var entity = new DocumentsRequest();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentsRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var entity = new Documents(request);

            entity.Url = String.Empty;
            if (request.File != null)
            {
                entity.Url = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Documents/", request.File);
            }
            else if (request.Url != null)
            {
                entity.Url = request.Url;
            }

            _dbContext.Documents.Add(entity);
            _dbContext.SaveChanges();
            TempData["success"] = "Документ успешно добавлен";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();

            var entity = _dbContext.Documents.Find(id);

            if (entity == null)
                return NotFound();

            return View(new DocumentsRequest(entity));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DocumentsRequest request)
        {
            var entity = _dbContext.Documents.Find(request.Id);

            if (entity == null)
                return View(request);

            entity.Name = request.Name;

            if (request.File != null)
            {
                entity.Url = await _saveFile.SaveFile(_appEnvironment.WebRootPath, "/media/Documents/", request.File);
            }
            else if (request.Url != null)
            {
                entity.Url = request.Url;
            }

            _dbContext.SaveChanges();
            TempData["success"] = "Документ успешно изменен";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = _dbContext.Documents.Find(id);

            if (obj == null)
                return NotFound();

            _dbContext.Documents.Remove(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Документ успешно удален";

            return RedirectToAction("Index");
        }
    }
}
