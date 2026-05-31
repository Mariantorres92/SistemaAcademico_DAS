using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Controllers
{
    public class MateriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Materias.Include(m => m.Profesor).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Profesores = _context.Profesores.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Materia materia)
        {
            ModelState.Remove("Profesor");
            ModelState.Remove("Inscripciones");
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Profesores = _context.Profesores.ToList();
            return View(materia);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null) return NotFound();
            ViewBag.Profesores = _context.Profesores.ToList();
            return View(materia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Materia materia)
        {
            if (id != materia.MateriaID) return NotFound();
            ModelState.Remove("Profesor");
            ModelState.Remove("Inscripciones");
            if (ModelState.IsValid)
            {
                _context.Update(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Profesores = _context.Profesores.ToList();
            return View(materia);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var materia = await _context.Materias.Include(m => m.Profesor).FirstOrDefaultAsync(m => m.MateriaID == id);
            if (materia == null) return NotFound();
            return View(materia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var materia = await _context.Materias.Include(m => m.Profesor).FirstOrDefaultAsync(m => m.MateriaID == id);
            if (materia == null) return NotFound();
            return View(materia);
        }
    }
}