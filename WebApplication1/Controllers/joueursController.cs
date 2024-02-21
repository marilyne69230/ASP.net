using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontalMVC.Models.EF;

namespace FrontalMVC.Controllers
{
    public class joueursController : Controller
    {
        private readonly TeamContext _context;

        public joueursController(TeamContext context)
        {
            _context = context;
        }

        // GET: joueurs
        public async Task<IActionResult> Index()
        {
            var teamContext = _context.Joueurs.Include(j => j.Equipe);
            return View(await teamContext.ToListAsync());
        }

        // GET: joueurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs
                .Include(j => j.Equipe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // GET: joueurs/Create
        public IActionResult Create()
        {
            ViewData["IDEquipe"] = new SelectList(_context.Equipes, "ID", "ID");
            return View();
        }

        // POST: joueurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom,Prenom,IDEquipe")] joueur joueur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joueur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDEquipe"] = new SelectList(_context.Equipes, "ID", "ID", joueur.IDEquipe);
            return View(joueur);
        }

        // GET: joueurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }
            ViewData["IDEquipe"] = new SelectList(_context.Equipes, "ID", "ID", joueur.IDEquipe);
            return View(joueur);
        }

        // POST: joueurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom,Prenom,IDEquipe")] joueur joueur)
        {
            if (id != joueur.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joueur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!joueurExists(joueur.ID))
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
            ViewData["IDEquipe"] = new SelectList(_context.Equipes, "ID", "ID", joueur.IDEquipe);
            return View(joueur);
        }

        // GET: joueurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joueur = await _context.Joueurs
                .Include(j => j.Equipe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (joueur == null)
            {
                return NotFound();
            }

            return View(joueur);
        }

        // POST: joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joueur = await _context.Joueurs.FindAsync(id);
            if (joueur != null)
            {
                _context.Joueurs.Remove(joueur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool joueurExists(int id)
        {
            return _context.Joueurs.Any(e => e.ID == id);
        }
    }
}
