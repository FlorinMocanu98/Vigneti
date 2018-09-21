using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigneti.Data;
using Vigneti.Models;
using Vigneti.Models.VineyardViewModel;

namespace Vigneti.Controllers
{
    public class VineyardsController : Controller
    {
        private readonly VineyardContext _context;

        public VineyardsController(VineyardContext context)
        {
            _context = context;
        }

        // GET: Vineyards
        public async Task<IActionResult> Index(int? ID, int? VineGrowerID, int? WineID)
        {
            
            var viewModel = new VineyardsIndexData();
            viewModel.Vineyards = await _context.Vineyards.Include(v => v.VineGrower).Include(v => v.Wine).ToListAsync();
            if (ID != null)
            {
                viewModel.Vineyards = viewModel.Vineyards.Where(v => v.VineyardID == ID);
            }
            if (VineGrowerID != null)
            {
                ViewData["Fullname"] = _context.VineGrowers.Where(v => v.ID == VineGrowerID).Single().FullName;
                viewModel.Vineyards2 = _context.Vineyards.Where(v => v.VineGrowerID == VineGrowerID);
            }
            if (WineID != null)
            {
                viewModel.Vineyards3 = await _context.Vineyards.Include(v => v.VineGrower).Include(v => v.Wine).ToListAsync();
                ViewData["Type"] = _context.Wines.Where(v => v.WineID == WineID).Single().Type;
                viewModel.Vineyards3 = _context.Vineyards.Where(v => v.WineID == WineID);
            }

            return View(viewModel);
        }

        // GET: Vineyards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vineyard = await _context.Vineyards
                .Include(v => v.VineGrower)
                .Include(v => v.Wine)
                .SingleOrDefaultAsync(m => m.VineyardID == id);
            if (vineyard == null)
            {
                return NotFound();
            }

            return View(vineyard);
        }

        // GET: Vineyards/Create
        public IActionResult Create()
        {
            ViewData["VineGrowerID"] = new SelectList(_context.VineGrowers, "ID", "ID");
            ViewData["WineID"] = new SelectList(_context.Wines, "WineID", "WineID");
            return View();
        }

        // POST: Vineyards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VineyardID,Dimension,Humidity,VineGrowerID,WineID")] Vineyard vineyard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vineyard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VineGrowerID"] = new SelectList(_context.VineGrowers, "ID", "ID", vineyard.VineGrowerID);
            ViewData["WineID"] = new SelectList(_context.Wines, "WineID", "WineID", vineyard.WineID);
            return View(vineyard);
        }

        // GET: Vineyards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vineyard = await _context.Vineyards.SingleOrDefaultAsync(m => m.VineyardID == id);
            if (vineyard == null)
            {
                return NotFound();
            }
            ViewData["VineGrowerID"] = new SelectList(_context.VineGrowers, "ID", "ID", vineyard.VineGrowerID);
            ViewData["WineID"] = new SelectList(_context.Wines, "WineID", "WineID", vineyard.WineID);
            return View(vineyard);
        }

        // POST: Vineyards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VineyardID,Dimension,Humidity,VineGrowerID,WineID")] Vineyard vineyard)
        {
            if (id != vineyard.VineyardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vineyard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VineyardExists(vineyard.VineyardID))
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
            ViewData["VineGrowerID"] = new SelectList(_context.VineGrowers, "ID", "ID", vineyard.VineGrowerID);
            ViewData["WineID"] = new SelectList(_context.Wines, "WineID", "WineID", vineyard.WineID);
            return View(vineyard);
        }

        // GET: Vineyards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vineyard = await _context.Vineyards
                .Include(v => v.VineGrower)
                .Include(v => v.Wine)
                .SingleOrDefaultAsync(m => m.VineyardID == id);
            if (vineyard == null)
            {
                return NotFound();
            }

            return View(vineyard);
        }

        // POST: Vineyards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vineyard = await _context.Vineyards.SingleOrDefaultAsync(m => m.VineyardID == id);
            _context.Vineyards.Remove(vineyard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VineyardExists(int id)
        {
            return _context.Vineyards.Any(e => e.VineyardID == id);
        }
    }
}
