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
    public class HoiDongDanhGiasController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public HoiDongDanhGiasController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }

        // GET: HoiDongDanhGias
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.HoiDongDanhGia.ToListAsync());
        }

        // GET: HoiDongDanhGias/Details/5


        // POST: HoiDongDanhGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten")] HoiDongDanhGium hoiDongDanhGium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoiDongDanhGium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoiDongDanhGium);
        }

        // GET: HoiDongDanhGias/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoiDongDanhGium = await _context.HoiDongDanhGia.FindAsync(id);
            if (hoiDongDanhGium == null)
            {
                return NotFound();
            }
            return View(hoiDongDanhGium);
        }

        // POST: HoiDongDanhGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Ten")] HoiDongDanhGium hoiDongDanhGium)
        {
            if (id != hoiDongDanhGium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoiDongDanhGium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoiDongDanhGiumExists(hoiDongDanhGium.Id))
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
            return View(hoiDongDanhGium);
        }

        // GET: HoiDongDanhGias/Delete/5
       
        private bool HoiDongDanhGiumExists(string id)
        {
            return _context.HoiDongDanhGia.Any(e => e.Id == id);
        }
    }
}
