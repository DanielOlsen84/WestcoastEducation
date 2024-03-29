﻿using Microsoft.AspNetCore.Mvc;
using WestcoastEducationStudentPortal.Models;
using WestcoastEducationStudentPortal.Services;

namespace WestcoastEducationAdministration.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsService _service;

        public StudentsController(StudentsService service)
        {
            _service = service;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.Get == null)
            {
                return NotFound();
            }

            return View(await _service.Get(id ?? 0));
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,Email,PhoneNumber,Address")] Student student)
        {
            if (ModelState.IsValid)
            {
                var ok = await _service.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.Get == null)
            {
                return NotFound();
            }

            return View(await _service.Get(id ?? 0));
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,Email,PhoneNumber,Address")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Edit(id, student);
                }
                catch (Exception e)
                {
                    throw new Exception("Something went wrong");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        //// GET: Students/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var Student = await _context.Students
        //        .FirstOrDefaultAsync(m => m.StudentId == id);
        //    if (Student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(Student);
        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Students == null)
        //    {
        //        return Problem("Entity set 'Context.Students'  is null.");
        //    }
        //    var Student = await _context.Students.FindAsync(id);
        //    if (Student != null)
        //    {
        //        _context.Students.Remove(Student);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StudentExists(int id)
        //{
        //  return _context.Students.Any(e => e.StudentId == id);
        //}
    }
}
