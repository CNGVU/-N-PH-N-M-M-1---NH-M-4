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
    public class MucTieuChisController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public MucTieuChisController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }

        // GET: MucTieuChis
        public async Task<IActionResult> Index()
        {
            return View(await _context.MucTieuChis.ToListAsync());
        }

        // GET: MucTieuChis/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucTieuChi = await _context.MucTieuChis
                .FirstOrDefaultAsync(m => m.IdMuc == id);
            if (mucTieuChi == null)
            {
                return NotFound();
            }

            return View(mucTieuChi);
        }

        // GET: MucTieuChis/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MucTieuChis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMuc,TenMuc,DiemToiDa")] MucTieuChi mucTieuChi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mucTieuChi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mucTieuChi);
        }

        // GET: MucTieuChis/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucTieuChi = await _context.MucTieuChis.FindAsync(id);
            if (mucTieuChi == null)
            {
                return NotFound();
            }
            return View(mucTieuChi);
        }

        // POST: MucTieuChis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdMuc,TenMuc,DiemToiDa")] MucTieuChi mucTieuChi)
        {
            if (id != mucTieuChi.IdMuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mucTieuChi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MucTieuChiExists(mucTieuChi.IdMuc))
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
            return View(mucTieuChi);
        }

        // GET: MucTieuChis/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mucTieuChi = await _context.MucTieuChis
                .FirstOrDefaultAsync(m => m.IdMuc == id);
            if (mucTieuChi == null)
            {
                return NotFound();
            }

            return View(mucTieuChi);
        }

        // POST: MucTieuChis/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mucTieuChi = await _context.MucTieuChis.FindAsync(id);
            if (mucTieuChi != null)
            {
                _context.MucTieuChis.Remove(mucTieuChi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MucTieuChiExists(string id)
        {
            return _context.MucTieuChis.Any(e => e.IdMuc == id);
        }
    }
}
