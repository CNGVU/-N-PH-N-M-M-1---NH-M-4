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
    public class SinhViensController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public SinhViensController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }

        // GET: SinhViens
        [Authorize]
        public ActionResult Index(string? id, string? type)
        {
            if (type == "lop")
            {
                var dbQuanLyDiemRenLuyenContext = _context.SinhViens.Include(s => s.IdLopNavigation).Where(a => a.IdLop == id).ToList();
                return View(dbQuanLyDiemRenLuyenContext);
            }
            else
            {
                var dbQuanLyDiemRenLuyenContext = _context.SinhViens.Where(a => a.IdLopNavigation.IdKhoa == id).Include(s => s.IdLopNavigation);
                return View(dbQuanLyDiemRenLuyenContext);
            }

            /*var result = from  sv in _context.SinhViens 
                         join lop in _context.Lops on sv.IdLop equals lop.IdLop
                         join khoa in _context.Khoas on lop.IdKhoa equals khoa.IdKhoa
                         where khoa.IdKhoa == id
                         select new
                         {
                             MaSV = sv.IdSv,
                             TenSV = sv.TenSv,
                             Lop = lop.TenLop,
                             Khoa = khoa.TenKhoa,
                             TenDangNhap = sv.TenDangNhap

                         };
            ViewBag.Result = result.ToList(); */

        }

        // GET: SinhViens/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.IdLopNavigation)
                .FirstOrDefaultAsync(m => m.IdSv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhViens/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "IdLop");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSv,IdLop,TenSv,TenDangNhap,MatKhau,BanCanSu")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "IdLop", sinhVien.IdLop);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "IdLop", sinhVien.IdLop);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSv,IdLop,TenSv,TenDangNhap,MatKhau,BanCanSu")] SinhVien sinhVien)
        {
            if (id != sinhVien.IdSv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.IdSv))
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
            ViewData["IdLop"] = new SelectList(_context.Lops, "IdLop", "IdLop", sinhVien.IdLop);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.IdLopNavigation)
                .FirstOrDefaultAsync(m => m.IdSv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhViens.Any(e => e.IdSv == id);
        }

        public ActionResult Response(string id)
        {
            return RedirectToAction("CreatePoint", "DiemRenLuyens", new { id = id });
        }
        [Authorize]
        public async Task<IActionResult> CreatePoint(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.IdLopNavigation)
                .FirstOrDefaultAsync(m => m.IdSv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["IdHocKy"] = new SelectList(_context.HocKies, "IdHocKy", "TenHocKy");
            ViewBag.TrueOrFalse = "true";
            return View(sinhVien);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePoint(string idSV, string idHocKy)
        {
            if (_context.DiemRenLuyens.Where(s=> s.IdSv == idSV && s.IdHocKy == idHocKy).FirstOrDefault() == null)
            {
                var idDRLStr = _context.DiemRenLuyens.OrderByDescending(a => a.Id).Select(a => a.Id).First();
                var listTieuChi = _context.NoiDungTieuChis.Include(a => a.IdMucNavigation);
                var listResult = new List<DiemRenLuyen>();
                int id = Convert.ToInt32(idDRLStr.Substring(3));
                string resulitId = "";
                foreach (var item in listTieuChi)
                {
                    DiemRenLuyen diemRenLuyen = new DiemRenLuyen();
                    diemRenLuyen.IdSv = idSV;
                    diemRenLuyen.IdHocKy = idHocKy;
                    diemRenLuyen.IdNoiDung = item.IdNoiDung;
                    diemRenLuyen.IdMinhChung = "MC00000001";
                    diemRenLuyen.DiemSv = 0;
                    diemRenLuyen.DiemGv = 0;
                    diemRenLuyen.DiemBcs = 0;
                    diemRenLuyen.DiemKhoa = 0;
                    diemRenLuyen.DiemHoiDongDanhGia = 0;
                    id++;
                    if (id < 10)
                    {
                        resulitId = "DRL000000" + (id).ToString();
                    }
                    else if (id < 100)
                    {
                        resulitId = "DRL00000" + (id).ToString();
                    }
                    else if (id < 1000)
                    {
                        resulitId = "DRL0000" + (id).ToString();
                    }
                    else if (id < 10000)
                    {
                        resulitId = "DRL000" + (id).ToString();
                    }
                    else if (id < 100000)
                    {
                        resulitId = "DRL00" + (id).ToString();
                    }
                    else if (id < 1000000)
                    {
                        resulitId = "DRL0" + (id).ToString();
                    }

                    diemRenLuyen.Id = resulitId;
                    listResult.Add(diemRenLuyen);
                }

                await _context.AddRangeAsync(listResult);

                await _context.SaveChangesAsync();
                ViewBag.TrueOrFalse = "true";
                ViewBag.Mess = "Thêm thành công";
            }
            else
            {
                ViewBag.TrueOrFalse = "false";
                ViewBag.Mess = "Điểm đã tồn tại";
            }
            ViewData["IdHocKy"] = new SelectList(_context.HocKies, "IdHocKy", "TenHocKy");
            return View();
        }

        public async Task<IActionResult> Home()
        {
            return View();
        }
    }
}
