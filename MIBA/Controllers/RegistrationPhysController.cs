using MIBA.Data;
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
    }
}
