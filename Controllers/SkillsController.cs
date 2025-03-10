using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    [Authorize]
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }
            return View(await _context.Skills.ToListAsync());
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.SkillsId == id);
            if (skillsModel == null)
            {
                return NotFound();
            }

            return View(skillsModel);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillsId,Name,Description")] SkillsModel skillsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillsModel);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.Skills.FindAsync(id);
            if (skillsModel == null)
            {
                return NotFound();
            }
            return View(skillsModel);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillsId,Name,Description")] SkillsModel skillsModel)
        {
            if (id != skillsModel.SkillsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillsModelExists(skillsModel.SkillsId))
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
            return View(skillsModel);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.Skills
                .FirstOrDefaultAsync(m => m.SkillsId == id);
            if (skillsModel == null)
            {
                return NotFound();
            }

            return View(skillsModel);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Check if _context is null
            if (_context.Skills == null)
            {
                return NotFound();
            }
            var skillsModel = await _context.Skills.FindAsync(id);
            if (skillsModel != null)
            {
                _context.Skills.Remove(skillsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillsModelExists(int id)
        {
            //Check if _context is null
            if (_context.Skills == null)
            {
                return false;
            }
            return _context.Skills.Any(e => e.SkillsId == id);
        }
    }
}
