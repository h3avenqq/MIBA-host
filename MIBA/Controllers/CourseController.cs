﻿using MIBA.Data;
using MIBA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MIBA.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            var studAndRegs = new StudiesAndRegs();
            var studs = _db.Studies.Include(x => x.Lectors).FirstOrDefault(x => x.Id == id);
            if (studs == null)
                return NotFound();

            studAndRegs.Studies = studs;
            studAndRegs.RegistrationPhys = new RegistrationPhys();
            studAndRegs.RegistrationJudic = new RegistrationJudic();
            studAndRegs.Feedback = new Feedback();


            return View(studAndRegs);
        }

        [HttpPost]
        public IActionResult RegistrationJudic(RegistrationJudic registration)
        {
            _db.RegistrationJudic.Add(registration);
            _db.SaveChanges();

            TempData["success"] = "Заявка успешно подана";
            return RedirectToAction("Index");
        }
    }
}
