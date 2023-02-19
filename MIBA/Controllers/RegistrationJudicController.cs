using MIBA.Data;
using MIBA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MIBA.Controllers
{
    public class RegistrationJudicController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RegistrationJudicController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var regs = _db.RegistrationJudic.Include(x=>x.Studies).ToList();

            return View(regs);
        }

        public IActionResult Create()
        {
            var reg = new RegistrationJudicAndStudies();

            reg.Studies = _db.Studies.ToList();

            return View(reg);
        }

        [HttpPost]
        public IActionResult Create(RegistrationJudic registration)
        {
            _db.RegistrationJudic.Add(registration);
            _db.SaveChanges();

            TempData["Success"] = "Заявка была успешно создана";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();


            var regs = _db.RegistrationJudic.First(x=>x.Id == id);
            var studs = _db.Studies.ToList();

            if (regs == null)
                return NotFound();

            var entity = new RegistrationJudicAndStudies();
            entity.RegistrationJudic = regs;
            entity.Studies = studs;

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(RegistrationJudic registration)
        {
            _db.RegistrationJudic.Update(registration);
            _db.SaveChanges();

            TempData["Success"] = "Заявка была успешно изменена";


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var entity = _db.RegistrationJudic.Find(id);

            if (entity == null)
                return NotFound();

            _db.RegistrationJudic.Remove(entity);
            _db.SaveChanges();

            TempData["success"] = "Заявка успешно удалена";

            return RedirectToAction("Index");
        }
    }
}
