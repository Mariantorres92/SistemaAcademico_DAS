using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico.Controllers
{
    public class NotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Notas
                .Include(n => n.Inscripcion)
                .ThenInclude(i => i.Estudiante)
                .Include(n => n.Inscripcion)
                .ThenInclude(i => i.Materia)
                .ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Inscripciones = _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Materia)
                .ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nota nota)
        {
            ModelState.Remove("Inscripcion");
            if (ModelState.IsValid)
            {
                nota.NotaFinal = (nota.Nota1 + nota.Nota2) / 2;
                _context.Add(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Inscripciones = _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Materia)
                .ToList();
            return View(nota);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var nota = await _context.Notas.FindAsync(id);
            if (nota == null) return NotFound();
            ViewBag.Inscripciones = _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Materia)
                .ToList();
            return View(nota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Nota nota)
        {
            if (id != nota.NotaID) return NotFound();
            ModelState.Remove("Inscripcion");
            if (ModelState.IsValid)
            {
                nota.NotaFinal = (nota.Nota1 + nota.Nota2) / 2;
                _context.Update(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Inscripciones = _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Materia)
                .ToList();
            return View(nota);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var nota = await _context.Notas
                .Include(n => n.Inscripcion)
                .ThenInclude(i => i.Estudiante)
                .Include(n => n.Inscripcion)
                .ThenInclude(i => i.Materia)
                .FirstOrDefaultAsync(n => n.NotaID == id);
            if (nota == null) return NotFound();
            return View(nota);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var nota = await _context.Notas
                .Include(n => n.Inscripcion)
                .ThenInclude(i => i.Estudiante)
                .Include(n => n.Inscripcion)
                .ThenInclude(i => i.Materia)
                .FirstOrDefaultAsync(n => n.NotaID == id);
            if (nota == null) return NotFound();
            return View(nota);
        }
    }
}