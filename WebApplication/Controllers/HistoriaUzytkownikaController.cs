using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HistoriaUzytkownikaController : Controller
    {
        private readonly MyContext _context;

        public HistoriaUzytkownikaController(MyContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        // GET: HistoriaUzytkownika
        public async Task<IActionResult> Index()
        {
            var myContext = _context.historiaUzytkownika.Include(h => h.uzytkownik);
            return View(await myContext.ToListAsync());
        }

        // GET: HistoriaUzytkownika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaUzytkownika = await _context.historiaUzytkownika
                .Include(h => h.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_uzytkownika == id);
            if (historiaUzytkownika == null)
            {
                return NotFound();
            }

            return View(historiaUzytkownika);
        }

        // GET: HistoriaUzytkownika/Create
        public IActionResult Create()
        {
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "id_uzytkownika", "email");
            return View();
        }

        // POST: HistoriaUzytkownika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_uzytkownika,data,waga,wzrost")] HistoriaUzytkownika historiaUzytkownika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historiaUzytkownika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "id_uzytkownika", "email", historiaUzytkownika.id_uzytkownika);
            return View(historiaUzytkownika);
        }

        // GET: HistoriaUzytkownika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaUzytkownika = await _context.historiaUzytkownika.FindAsync(id);
            if (historiaUzytkownika == null)
            {
                return NotFound();
            }
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "id_uzytkownika", "email", historiaUzytkownika.id_uzytkownika);
            return View(historiaUzytkownika);
        }

        // POST: HistoriaUzytkownika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_uzytkownika,data,waga,wzrost")] HistoriaUzytkownika historiaUzytkownika)
        {
            if (id != historiaUzytkownika.id_uzytkownika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historiaUzytkownika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaUzytkownikaExists(historiaUzytkownika.id_uzytkownika))
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
            ViewData["id_uzytkownika"] = new SelectList(_context.uzytkownicy, "id_uzytkownika", "email", historiaUzytkownika.id_uzytkownika);
            return View(historiaUzytkownika);
        }

        // GET: HistoriaUzytkownika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaUzytkownika = await _context.historiaUzytkownika
                .Include(h => h.uzytkownik)
                .FirstOrDefaultAsync(m => m.id_uzytkownika == id);
            if (historiaUzytkownika == null)
            {
                return NotFound();
            }

            return View(historiaUzytkownika);
        }

        // POST: HistoriaUzytkownika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historiaUzytkownika = await _context.historiaUzytkownika.FindAsync(id);
            _context.historiaUzytkownika.Remove(historiaUzytkownika);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaUzytkownikaExists(int id)
        {
            return _context.historiaUzytkownika.Any(e => e.id_uzytkownika == id);
        }
    }
}
