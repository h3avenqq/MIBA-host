using MIBA.Data;
using MIBA.Models;
using MIBA.Services.HashService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MIBA.Controllers
{
    public class UsersTableController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHashService _hash;

        public UsersTableController(ApplicationDbContext db, IHashService hash)
        {
            _db = db;
            _hash = hash;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var Users = _db.Users.ToList();

            return View(Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewUserViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            if (obj.Password != obj.RepeatPassword)
            {
                TempData["error"] = "Пароли не совпадают!";
                return View(obj);
            }

            var newUser = new User();
            newUser.Name = obj.Name;
            newUser.Password = _hash.HashPassword(obj.Password);
            newUser.Role = Enums.Role.Moderator;

            _db.Users.Add(newUser);
            _db.SaveChanges();
            TempData["success"] = "Пользователь успешно добавлен";

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDb = _db.Users.Find(id);

            EditUserViewModel objForEdit = new EditUserViewModel();
            objForEdit.Id = objFromDb.Id;
            objForEdit.Name = objFromDb.Name;
            objForEdit.OldPassword = objFromDb.Password;

            if (objFromDb == null)
            {
                return NotFound();
            }

            return View(objForEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            var objFromDb = _db.Users.Find(obj.Id);
            objFromDb.Password = _hash.HashPassword(obj.NewPassword);


            _db.Update(objFromDb);
            _db.SaveChanges();

            TempData["success"] = "Пользователь успешно изменен";

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Users.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Users.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Пользователь успешно удален";

            return RedirectToAction("Index");
        }
    }
}
