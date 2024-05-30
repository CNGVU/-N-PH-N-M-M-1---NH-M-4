using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnPhanMem_Nhom4.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.Design;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace DoAnPhanMem_Nhom4.Controllers
{
    public class GvcnsController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public GvcnsController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string values, string typeSearch)
        {
            return RedirectToAction(nameof(Index), new { values, typeSearch });

        }

        // GET: Gvcns
        public async Task<IActionResult> Index(string? values, string? typeSearch)
        {
            string? IdKhoa = User.FindFirst(ClaimTypes.UserData)?.Value;

            List<string> type = new List<string>
            {
                new string("Lớp"),
                new string("Tên") 
            };
            ViewData["TypeSearch"] = new SelectList(type);
            var list = _context.Gvcns.Where(a=> a.IdLopNavigation.IdKhoa == IdKhoa).Include(a=>a.IdLopNavigation);

            if (values != null)
            {
                values = values.Trim();

                 
                if (typeSearch == "Lớp")
                {
                    var listResult = list.Where(a => a.IdLopNavigation.TenLop.ToLower().Contains(values.ToLower()));
                    return View(listResult);
                } 
                if (typeSearch == "Tên")
                {
                    var listResult = list.Where(a => a.TenGv.ToLower().Contains(values.ToLower()));
                    return View(listResult);
                }
            }


            return View(await list.ToListAsync());
 
        }

        // GET: Gvcns/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gvcn = await _context.Gvcns
                .Include(g => g.IdLopNavigation)
                .FirstOrDefaultAsync(m => m.IdGv == id);
            if (gvcn == null)
            {
                return NotFound();
            }

            return View(gvcn);
        }
        [Authorize(Roles = "admin")]
        // GET: Gvcns/Create
        public IActionResult Create()
        {
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "TenLop");
            return View();
        }

        // POST: Gvcns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGv,IdLop,TenGv,TenDangNhap,MatKhau")] Gvcn gvcn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gvcn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "TenLop", gvcn.IdLop);
            return View(gvcn);
        }

        // GET: Gvcns/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gvcn = await _context.Gvcns.FindAsync(id);
            if (gvcn == null)
            {
                return NotFound();
            }
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "TenLop", gvcn.IdLop);
            return View(gvcn);
        }

        // POST: Gvcns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdGv,IdLop,TenGv,TenDangNhap,MatKhau")] Gvcn gvcn)
        {
            if (id != gvcn.IdGv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gvcn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GvcnExists(gvcn.IdGv))
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
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "TenLop", gvcn.IdLop);
            return View(gvcn);
        }

        // GET: Gvcns/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gvcn = await _context.Gvcns
                .Include(g => g.IdLopNavigation)
                .FirstOrDefaultAsync(m => m.IdGv == id);
            if (gvcn == null)
            {
                return NotFound();
            }

            return View(gvcn);
        }

        // POST: Gvcns/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var gvcn = await _context.Gvcns.FindAsync(id);
            if (gvcn != null)
            {
                _context.Gvcns.Remove(gvcn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GvcnExists(string id)
        {
            return _context.Gvcns.Any(e => e.IdGv == id);
        }
    }
}
