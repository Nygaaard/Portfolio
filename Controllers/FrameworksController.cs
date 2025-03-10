using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class FrameworksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrameworksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Frameworks
        public async Task<IActionResult> Index()
        {
            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return NotFound();
            }
            return View(await _context.FrameworksModel.ToListAsync());
        }

        // GET: Frameworks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return NotFound();
            }

            var frameworksModel = await _context.FrameworksModel
                .FirstOrDefaultAsync(m => m.FrameworkId == id);
            if (frameworksModel == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return NotFound();
            }

            return View(frameworksModel);
        }

        // GET: Frameworks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frameworks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrameworkId,Name,Description")] FrameworksModel frameworksModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frameworksModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frameworksModel);
        }

        // GET: Frameworks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return NotFound();
            }

            var frameworksModel = await _context.FrameworksModel.FindAsync(id);
            if (frameworksModel == null)
            {
                return NotFound();
            }
            return View(frameworksModel);
        }

        // POST: Frameworks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrameworkId,Name,Description")] FrameworksModel frameworksModel)
        {
            if (id != frameworksModel.FrameworkId)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frameworksModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrameworksModelExists(frameworksModel.FrameworkId))
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
            return View(frameworksModel);
        }

        // GET: Frameworks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return NotFound();
            }

            var frameworksModel = await _context.FrameworksModel
                .FirstOrDefaultAsync(m => m.FrameworkId == id);
            if (frameworksModel == null)
            {
                return NotFound();
            }

            return View(frameworksModel);
        }

        // POST: Frameworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frameworksModel = await _context.FrameworksModel.FindAsync(id);
            if (frameworksModel != null)
            {
                _context.FrameworksModel.Remove(frameworksModel);
            }

            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrameworksModelExists(int id)
        {
            //Check if _context is null
            if (_context.FrameworksModel == null)
            {
                return false;
            }
            return _context.FrameworksModel.Any(e => e.FrameworkId == id);
        }
    }
}
