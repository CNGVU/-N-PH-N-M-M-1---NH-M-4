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
    public class NoiDungTieuChisController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public NoiDungTieuChisController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }

        // GET: NoiDungTieuChis
        public async Task<IActionResult> Index()
        {
            var dbQuanLyDiemRenLuyenContext = _context.NoiDungTieuChis.Include(n => n.IdMucNavigation);
            return View(await dbQuanLyDiemRenLuyenContext.ToListAsync());
        }

        // GET: NoiDungTieuChis/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noiDungTieuChi = await _context.NoiDungTieuChis
                .Include(n => n.IdMucNavigation)
                .FirstOrDefaultAsync(m => m.IdNoiDung == id);
            if (noiDungTieuChi == null)
            {
                return NotFound();
            }

            return View(noiDungTieuChi);
        }

        // GET: NoiDungTieuChis/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["IdMuc"] = new SelectList(_context.MucTieuChis, "IdMuc", "IdMuc");
            return View();
        }

        // POST: NoiDungTieuChis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNoiDung,IdMuc,TenNoiDung,DiemToiDa")] NoiDungTieuChi noiDungTieuChi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noiDungTieuChi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMuc"] = new SelectList(_context.MucTieuChis, "IdMuc", "IdMuc", noiDungTieuChi.IdMuc);
            return View(noiDungTieuChi);
        }

        // GET: NoiDungTieuChis/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noiDungTieuChi = await _context.NoiDungTieuChis.FindAsync(id);
            if (noiDungTieuChi == null)
            {
                return NotFound();
            }
            ViewData["IdMuc"] = new SelectList(_context.MucTieuChis, "IdMuc", "IdMuc", noiDungTieuChi.IdMuc);
            return View(noiDungTieuChi);
        }

        // POST: NoiDungTieuChis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdNoiDung,IdMuc,TenNoiDung,DiemToiDa")] NoiDungTieuChi noiDungTieuChi)
        {
            if (id != noiDungTieuChi.IdNoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noiDungTieuChi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoiDungTieuChiExists(noiDungTieuChi.IdNoiDung))
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
            ViewData["IdMuc"] = new SelectList(_context.MucTieuChis, "IdMuc", "IdMuc", noiDungTieuChi.IdMuc);
            return View(noiDungTieuChi);
        }

        // GET: NoiDungTieuChis/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noiDungTieuChi = await _context.NoiDungTieuChis
                .Include(n => n.IdMucNavigation)
                .FirstOrDefaultAsync(m => m.IdNoiDung == id);
            if (noiDungTieuChi == null)
            {
                return NotFound();
            }

            return View(noiDungTieuChi);
        }

        // POST: NoiDungTieuChis/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var noiDungTieuChi = await _context.NoiDungTieuChis.FindAsync(id);
            if (noiDungTieuChi != null)
            {
                _context.NoiDungTieuChis.Remove(noiDungTieuChi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoiDungTieuChiExists(string id)
        {
            return _context.NoiDungTieuChis.Any(e => e.IdNoiDung == id);
        }
    }
}
