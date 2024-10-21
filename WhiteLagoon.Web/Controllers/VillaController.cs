using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("Description", "Description cannot be the same as Name");
            }
            if (ModelState.IsValid)
            {
                villa.CreatedDate = DateTime.Now;
                villa.UpdatedDate = DateTime.Now;

                var transaction = _context.Database.BeginTransaction();

                try
                {
                    _context.Villas.Add(villa);
                    _context.SaveChanges();

                    transaction.Commit();

                    TempData["success"] = "Villa created successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = "An error occurred while creating the villa.";
                    transaction.Rollback();
                }
            }
            return View(villa);
        }

        public IActionResult Edit(int id)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);
            if (villa is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Edit(Villa villa)
        {
            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("Description", "Description cannot be the same as Name");
            }
            if (ModelState.IsValid && villa.Id > 0)
            {
                villa.UpdatedDate = DateTime.Now;

                var transaction = _context.Database.BeginTransaction();

                try
                {
                    _context.Villas.Update(villa);
                    _context.SaveChanges();

                    transaction.Commit();

                    TempData["success"] = "Villa updated successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = "An error occurred while updating the villa.";
                    transaction.Rollback();
                }
            }
            return View(villa);
        }

        public IActionResult Delete(int id)
        {
            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);
            if (villa is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villa);
        }

        [HttpPost]
        public IActionResult Delete(Villa villa)
        {
            if (villa.Id > 0)
            {
                var villaFromDb = _context.Villas.FirstOrDefault(v => v.Id == villa.Id);

                if (villaFromDb is null)
                {
                    return RedirectToAction("Error", "Home");
                }

                var transaction = _context.Database.BeginTransaction();

                try
                {
                    _context.Villas.Remove(villaFromDb);
                    _context.SaveChanges();

                    transaction.Commit();

                    TempData["success"] = "Villa deleted successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = "An error occurred while deleting the villa.";
                    transaction.Rollback();
                }
            }
            return View(villa);
        }
    }
}
