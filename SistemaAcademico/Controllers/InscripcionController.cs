using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Controllers
{
    public class InscripcionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscripcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Materia)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Materias = _context.Materias.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inscripcion inscripcion)
        {
            ModelState.Remove("Estudiante");
            ModelState.Remove("Materia");
            ModelState.Remove("Notas");
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Materias = _context.Materias.ToList();
            return View(inscripcion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion == null) return NotFound();
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Materias = _context.Materias.ToList();
            return View(inscripcion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inscripcion inscripcion)
        {
            if (id != inscripcion.InscripcionID) return NotFound();
            ModelState.Remove("Estudiante");
            ModelState.Remove("Materia");
            ModelState.Remove("Notas");
            if (ModelState.IsValid)
            {
                _context.Update(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estudiantes = _context.Estudiantes.ToList();
            ViewBag.Materias = _context.Materias.ToList();
            return View(inscripcion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var inscripcion = await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Materia)
                .FirstOrDefaultAsync(i => i.InscripcionID == id);
            if (inscripcion == null) return NotFound();
            return View(inscripcion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var inscripcion = await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Materia)
                .FirstOrDefaultAsync(i => i.InscripcionID == id);
            if (inscripcion == null) return NotFound();
            return View(inscripcion);
        }
    }
}