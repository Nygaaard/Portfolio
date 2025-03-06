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
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            //Check if _context is null
            if (_context.Courses == null)
            {
                return NotFound();
            }
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Courses == null)
            {
                return NotFound();
            }

            var coursesModel = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (coursesModel == null)
            {
                return NotFound();
            }

            return View(coursesModel);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Name,Description,Syllabus,Points")] CoursesModel coursesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coursesModel);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Courses == null)
            {
                return NotFound();
            }

            var coursesModel = await _context.Courses.FindAsync(id);
            if (coursesModel == null)
            {
                return NotFound();
            }
            return View(coursesModel);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,Name,Description,Syllabus,Points")] CoursesModel coursesModel)
        {
            if (id != coursesModel.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesModelExists(coursesModel.CourseId))
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
            return View(coursesModel);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Check if _context is null
            if (_context.Courses == null)
            {
                return NotFound();
            }

            var coursesModel = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (coursesModel == null)
            {
                return NotFound();
            }

            return View(coursesModel);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Check if _context is null
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var coursesModel = await _context.Courses.FindAsync(id);
            if (coursesModel != null)
            {
                _context.Courses.Remove(coursesModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesModelExists(int id)
        {
            //Check if _context is null
            if (_context.Courses == null)
            {
                return false;
            }
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
