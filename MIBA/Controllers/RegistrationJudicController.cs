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
            //var reg = new RegistrationJudic();

            //reg.Studies = _db.Studies.ToList();

            //return View(reg);
            return RedirectToAction("Index");
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


            var entity = _db.RegistrationJudic.Include(x=>x.Studies).First(x=>x.Id == id);

            if (entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(RegistrationJudic registration)
        {
            if (!ModelState.IsValid)
                return View(registration);


            var entity = _db.RegistrationJudic.Find(registration.Id);

            if (entity == null)
                return NotFound();

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
