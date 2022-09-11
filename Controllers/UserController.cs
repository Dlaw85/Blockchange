using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellaMvc.DatabaseContext;
using WellaMvc.Models;

namespace WellaMvc.Controllers
{
 

    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
             _context = context;
        }
    
        public IActionResult Index()
        {
            var user = _context.UserDataTable.ToList();
            return View(user);
        }

         public IActionResult AddUser()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public  async Task<IActionResult> AddUser(UserData user)
        {
            if (ModelState.IsValid)
            {
                await _context.UserDataTable.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DetailsAsync(int ID) 
        {
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x => x.ID == ID);
            return View(user);
        }

        public  async Task<IActionResult> EditAsync(int ID)
        {
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x => x.ID == ID);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditAsync(UserData model) 
        {
            var user = await _context.UserDataTable.FirstOrDefaultAsync(x => x.ID == model.ID);

            if (!string.IsNullOrEmpty(model.FirstName)) user.FirstName = model.FirstName;
            if (!string.IsNullOrEmpty(model.LastName)) user.LastName = model.LastName;
            if (!string.IsNullOrEmpty(model.Location)) user.Location = model.Location;
            if (!string.IsNullOrEmpty(model.PhoneNumber)) user.PhoneNumber = model.PhoneNumber;
            if (!string.IsNullOrEmpty(model.Email)) user.Email = model.Email;

            _context.UserDataTable.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? ID)
        {
            var user = _context.UserDataTable.Find(ID);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserDataTable.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int ID)
        {   
            var user =  _context.UserDataTable.Find(ID);

            return View(user);
        }
       
 
    }
}