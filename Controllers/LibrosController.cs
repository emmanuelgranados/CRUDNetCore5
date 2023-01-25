using CRUDNetCore5.Data;
using CRUDNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUDNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = _context.Libro;
            return View(listLibros);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid) { 
            
                _context.Libro.Add(libro);
                _context.SaveChanges();
                TempData["mesaje"] = "El libro se ha creado correctamente...";
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            { 
            return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {

                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mesaje"] = "El libro se ha actualizado correctamente...";
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      public ActionResult DeleteLibro(int? id) {

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {

                return NotFound();
            }

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            TempData["mesaje"] = "El libro se ha eliminado correctamente...";
            return RedirectToAction("Index");
        }

    }
}
