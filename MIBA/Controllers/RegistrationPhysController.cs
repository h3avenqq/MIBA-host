using MIBA.Data;
using MIBA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MIBA.Controllers
{
    public class RegistrationPhysController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RegistrationPhysController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var regs = _db.RegistrationPhys.Include(x => x.Studies).ToList();

            return View(regs);
        }

        public IActionResult Create()
        {
            var reg = new RegistrationPhysAndStudies();
            reg.Studies = _db.Studies.ToList();

            return View(reg);
        }

        [HttpPost]
        public IActionResult Create(RegistrationPhys registration)
        {
            _db.RegistrationPhys.Add(registration);
            _db.SaveChanges();

            TempData["Success"] = "Заявка успешно создана";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var reg = _db.RegistrationPhys.Find(id);

            if(reg == null)
                return NotFound();

            var entity = new RegistrationPhysAndStudies();
            entity.RegistrationPhys = reg;
            entity.Studies = _db.Studies.ToList();

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(RegistrationPhys registration)
        {
            _db.RegistrationPhys.Update(registration);
            _db.SaveChanges();

            TempData["Success"] = "Заявка успешно изменена";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var entity = _db.RegistrationPhys.Find(id);

            if (entity == null)
                return NotFound();

            _db.RegistrationPhys.Remove(entity);
            _db.SaveChanges();

            TempData["Success"] = "Заявка успешно удалена";

            return RedirectToAction("Index");
        }
    }
}
