﻿using MIBA.Data;
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
    }
}
