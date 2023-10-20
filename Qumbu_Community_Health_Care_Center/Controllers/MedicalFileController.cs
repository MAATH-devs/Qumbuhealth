using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using Qumbu_Community_Health_Care_Center.Models;

namespace Qumbu_Community_Health_Care_Center.Controllers
{
    public class MedicalFileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalFileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalFile
        public async Task<IActionResult> Index()
        {
              return _context.MedicalFile != null ? 
                          View(await _context.MedicalFile.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MedicalFile'  is null.");
        }

        // GET: MedicalFile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalFile == null)
            {
                return NotFound();
            }

            var medicalFile = await _context.MedicalFile
                .FirstOrDefaultAsync(m => m.MedicalID == id);
            if (medicalFile == null)
            {
                return NotFound();
            }

            return View(medicalFile);
        }

        // GET: MedicalFile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalFile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalID,Id,IDno,DateOfBirth,Gender,Address,Province,MaritalStatus,Nationality,Laguage,NextOfKinFirstName,NextOfKinLastName,NextOfKinCellNumber")] MedicalFile medicalFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalFile);
        }

        // GET: MedicalFile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalFile == null)
            {
                return NotFound();
            }

            var medicalFile = await _context.MedicalFile.FindAsync(id);
            if (medicalFile == null)
            {
                return NotFound();
            }
            return View(medicalFile);
        }

        // POST: MedicalFile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalID,Id,IDno,DateOfBirth,Gender,Address,Province,MaritalStatus,Nationality,Laguage,NextOfKinFirstName,NextOfKinLastName,NextOfKinCellNumber")] MedicalFile medicalFile)
        {
            if (id != medicalFile.MedicalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalFileExists(medicalFile.MedicalID))
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
            return View(medicalFile);
        }

        // GET: MedicalFile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalFile == null)
            {
                return NotFound();
            }

            var medicalFile = await _context.MedicalFile
                .FirstOrDefaultAsync(m => m.MedicalID == id);
            if (medicalFile == null)
            {
                return NotFound();
            }

            return View(medicalFile);
        }

        // POST: MedicalFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalFile == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MedicalFile'  is null.");
            }
            var medicalFile = await _context.MedicalFile.FindAsync(id);
            if (medicalFile != null)
            {
                _context.MedicalFile.Remove(medicalFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalFileExists(int id)
        {
          return (_context.MedicalFile?.Any(e => e.MedicalID == id)).GetValueOrDefault();
        }
    }
}
