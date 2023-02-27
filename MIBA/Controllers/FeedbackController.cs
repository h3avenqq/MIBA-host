using MIBA.Data;
using MIBA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MIBA.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FeedbackController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var feedbacks = _db.Feedbacks.Include(x=>x.Studies).ToList();

            return View(feedbacks);
        }

        public IActionResult Create()
        {
            var feedback = new FeedbackAndStudies();
            feedback.Studies = _db.Studies.ToList();
            return View(feedback);
        }

        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            _db.Feedbacks.Add(feedback);
            _db.SaveChanges();

            TempData["success"] = "Отзыв успешно создан";


            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var vm = new FeedbackAndStudies();
            vm.Feedback = _db.Feedbacks.Include(x=>x.Studies).FirstOrDefault(x => x.Id == id);

            if (vm.Feedback == null)
                return NotFound();

            vm.Studies = _db.Studies.ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(Feedback feedback)
        {
            _db.Feedbacks.Update(feedback);
            _db.SaveChanges();

            TempData["success"] = "Отзыв успешно изменен";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.Feedbacks.Find(id);

            if (obj == null)
                return NotFound();

            _db.Feedbacks.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Отзыв успешно удален";

            return RedirectToAction("Index");
        }
    }
}
