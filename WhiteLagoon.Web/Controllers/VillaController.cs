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

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return View(villa);
        }
    }
}
