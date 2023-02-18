using MIBA.Data;
using Microsoft.AspNetCore.Mvc;

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
            var feedbacks = _db.Feedbacks.ToList();

            return View(feedbacks);
        }
    }
}
