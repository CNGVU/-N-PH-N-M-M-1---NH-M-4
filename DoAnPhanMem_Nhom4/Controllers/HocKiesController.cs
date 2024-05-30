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
    public class HocKiesController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public HocKiesController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }

        // GET: HocKies
        public async Task<IActionResult> Index()
        {
            return View(await _context.HocKies.ToListAsync());
        }

        // GET: HocKies/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocKy = await _context.HocKies
                .FirstOrDefaultAsync(m => m.IdHocKy == id);
            if (hocKy == null)
            {
                return NotFound();
            }

            return View(hocKy);
        }
        
        [Authorize(Roles = "admin")]
        // GET: HocKies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HocKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHocKy,TenHocKy")] HocKy hocKy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocKy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocKy);
        }

        // GET: HocKies/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocKy = await _context.HocKies.FindAsync(id);
            if (hocKy == null)
            {
                return NotFound();
            }
            return View(hocKy);
        }

        // POST: HocKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdHocKy,TenHocKy")] HocKy hocKy)
        {
            if (id != hocKy.IdHocKy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocKy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocKyExists(hocKy.IdHocKy))
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
            return View(hocKy);
        }

        // GET: HocKies/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocKy = await _context.HocKies
                .FirstOrDefaultAsync(m => m.IdHocKy == id);
            if (hocKy == null)
            {
                return NotFound();
            }

            return View(hocKy);
        }

        // POST: HocKies/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hocKy = await _context.HocKies.FindAsync(id);
            if (hocKy != null)
            {
                _context.HocKies.Remove(hocKy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocKyExists(string id)
        {
            return _context.HocKies.Any(e => e.IdHocKy == id);
        }
    }
}
