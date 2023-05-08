using CarManager.Models.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManager.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: CompaniesController
        private readonly CarDbContext _context;

        public CompaniesController(CarDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Companies.ToList());
        }
        public ActionResult CompaniesAndTheirModels()
        {
            var carDBContext = _context.Models.ToList();
            return View(_context.Companies.ToList());
        }

        // GET: CompaniesController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Companies.Find(id));
        }

        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company comp)
        {
            try
            {
                _context.Companies.Add(comp);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            Company comp = _context.Companies.Find(id);
            return View(comp);
        }

        // POST: CompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company comp)
        {
            try
            {
                _context.Companies.Update(comp);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult SearchBy2()
        {
            var companies = _context.Companies.ToList();
            ViewBag.Segment = companies.Select(m => m.Segment).Distinct().OrderBy(g => g).ToList();
            return View(companies);

        }
        [HttpPost]
        public IActionResult SearchBy2(string segment, string name)
        {

            var companies = _context.Companies.ToList();
            ViewBag.Segment = companies.Select(m => m.Segment).ToList();
            ViewBag.Name = name;

            if (!string.IsNullOrEmpty(segment) && segment != "All")
            {
                companies = companies.Where(m => m.Segment == segment).ToList();
            }

            if (!string.IsNullOrEmpty(name))
            {
                companies = companies.Where(m => m.Name.Contains(name)).ToList();
            }
            if (segment == "ALL")
            {
                companies = _context.Companies.ToList();
            }
            if (segment == "ALL" && !string.IsNullOrEmpty(name))
            {
                companies = companies.Where(m => m.Name.Contains(name)).ToList();
            }
            return View("SearchBy2", companies);
        }

        // GET: CompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Companies.Find(id));
        }

        // POST: CompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, Company comp)
        {
            try
            {
                _context.Companies.Remove(comp);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
