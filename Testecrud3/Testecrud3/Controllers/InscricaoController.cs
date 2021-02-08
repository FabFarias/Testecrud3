using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testecrud3.Data;
using Testecrud3.Models;

namespace Testecrud3.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly Contexto _context;

        public InscricaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Inscricao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Inscrições.Include(i => i.Curso).Include(i => i.Socio);
            return View(await contexto.ToListAsync());
        }

        // GET: Inscricao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscrições
                .Include(i => i.Curso)
                .Include(i => i.Socio)
                .FirstOrDefaultAsync(m => m.InscricaoID == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricao/Create
        public IActionResult Create()
        {
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID");
            ViewData["SocioID"] = new SelectList(_context.Socios, "SocioID", "SocioID");
            return View();
        }

        // POST: Inscricao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscricaoID,CursoID,SocioID,Grade")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID", inscricao.CursoID);
            ViewData["SocioID"] = new SelectList(_context.Socios, "SocioID", "SocioID", inscricao.SocioID);
            return View(inscricao);
        }

        // GET: Inscricao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscrições.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID", inscricao.CursoID);
            ViewData["SocioID"] = new SelectList(_context.Socios, "SocioID", "SocioID", inscricao.SocioID);
            return View(inscricao);
        }

        // POST: Inscricao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscricaoID,CursoID,SocioID,Grade")] Inscricao inscricao)
        {
            if (id != inscricao.InscricaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricaoExists(inscricao.InscricaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoID"] = new SelectList(_context.Cursos, "CursoID", "CursoID", inscricao.CursoID);
            ViewData["SocioID"] = new SelectList(_context.Socios, "SocioID", "SocioID", inscricao.SocioID);
            return View(inscricao);
        }

        // GET: Inscricao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscrições
                .Include(i => i.Curso)
                .Include(i => i.Socio)
                .FirstOrDefaultAsync(m => m.InscricaoID == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricao = await _context.Inscrições.FindAsync(id);
            _context.Inscrições.Remove(inscricao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscrições.Any(e => e.InscricaoID == id);
        }
    }
}
