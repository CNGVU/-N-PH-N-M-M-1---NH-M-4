using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnPhanMem_Nhom4.Models;
using Microsoft.AspNetCore.Authorization;

namespace DoAnPhanMem_Nhom4.Controllers
{
    public class LopsController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public LopsController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }

        // GET: Lops
        [Authorize]
        public async Task<IActionResult> Index(string? id)
        {
            var dbQuanLyDiemRenLuyenContext = _context.Lops.Where(a=> a.IdKhoa ==id);
            return View(await dbQuanLyDiemRenLuyenContext.ToListAsync());
        }

        // GET: Lops/Details/5
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lop = await _context.Lops
                .Include(l => l.IdKhoaNavigation)
                .FirstOrDefaultAsync(m => m.IdLop == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // GET: Lops/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["IdKhoa"] = new SelectList(_context.Khoas, "IdKhoa", "TenKhoa");
            return View();
        }

        // POST: Lops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLop,TenLop,IdKhoa")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKhoa"] = new SelectList(_context.Khoas, "IdKhoa", "TenKhoa", lop.IdKhoa);
            return View(lop);
        }

        // GET: Lops/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lop = await _context.Lops.FindAsync(id);
            if (lop == null)
            {
                return NotFound();
            }
            ViewData["IdKhoa"] = new SelectList(_context.Khoas, "IdKhoa", "TenKhoa", lop.IdKhoa);
            return View(lop);
        }

        // POST: Lops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdLop,TenLop,IdKhoa")] Lop lop)
        {
            if (id != lop.IdLop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopExists(lop.IdLop))
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
            ViewData["IdKhoa"] = new SelectList(_context.Khoas, "IdKhoa", "TendKhoa", lop.IdKhoa);
            return View(lop);
        }

        [Authorize(Roles = "admin")]
        // GET: Lops/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lop = await _context.Lops
                .Include(l => l.IdKhoaNavigation)
                .FirstOrDefaultAsync(m => m.IdLop == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // POST: Lops/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lop = await _context.Lops.FindAsync(id);
            if (lop != null)
            {
                _context.Lops.Remove(lop);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopExists(string id)
        {
            return _context.Lops.Any(e => e.IdLop == id);
        }
    }
}
