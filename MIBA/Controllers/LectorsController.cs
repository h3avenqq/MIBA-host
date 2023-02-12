using MIBA.Data;
using MIBA.Models;
using MIBA.Services.HashService;
using Microsoft.AspNetCore.Mvc;

namespace MIBA.Controllers
{
    public class LectorsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LectorsController(ApplicationDbContext db)
        {
            _db = db;
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
        public async Task<IActionResult> Create(Lectors obj)
        {
            if (ModelState.IsValid)
            {
                _db.Lectors.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Лектор успешно добавлен";
                return RedirectToAction("Index");
            }
            return View(obj);
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

            return View(objFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Lectors obj)
        {
            if (ModelState.IsValid)
            {
                _db.Lectors.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Лектор успешно изменена";
                return RedirectToAction("Index");
            }
            return View(obj);
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
