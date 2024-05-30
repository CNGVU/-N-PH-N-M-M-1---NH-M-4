using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnPhanMem_Nhom4.Models;
using System.Collections;

namespace DoAnPhanMem_Nhom4.Controllers
{
    public class DiemRenLuyensController : Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;

        public DiemRenLuyensController(DbQuanLyDiemRenLuyenContext context)
        {
            _context = context;
        }
        private bool DiemRenLuyenExists(string id)
        {
            return _context.DiemRenLuyens.Any(e => e.Id == id);
        }

        
        public IActionResult AssessmentCommitteeScore(string id )
        {
            var dbQuanLyDiemRenLuyenContext = _context.DiemRenLuyens.Include(d => d.IdHocKy).Include(d => d.IdMinhChung).Include(d => d.IdNoiDung).Include(d => d.IdSv);
            var result = from drl in _context.DiemRenLuyens
                         join ndtc in _context.NoiDungTieuChis on drl.IdNoiDung equals ndtc.IdNoiDung
                         join mtc in _context.MucTieuChis on ndtc.IdMuc equals mtc.IdMuc
                         join hk in _context.HocKies on drl.IdHocKy equals hk.IdHocKy
                         join sv in _context.SinhViens on drl.IdSv equals sv.IdSv
                         join mc in _context.MinhChungs on drl.IdMinhChung equals mc.Id
                         join lop in _context.Lops on sv.IdLop equals lop.IdLop
                         join khoa in _context.Khoas on lop.IdKhoa equals khoa.IdKhoa
                         where sv.IdSv == id 
                         select new
                         {
                             MaSV = sv.IdSv,
                             TenSV = sv.TenSv,
                             Lop = lop.TenLop,
                             Khoa = khoa.TenKhoa,
                             TenMuc = mtc.TenMuc,
                             TenNoiDung = ndtc.TenNoiDung,
                             DiemToiDa = ndtc.DiemToiDa,
                             DiemSV = drl.DiemSv,
                             DiemBCS = drl.DiemBcs,
                             DiemGV = drl.DiemGv,
                             DiemKhoa = drl.DiemKhoa,
                             DiemHDDG = drl.DiemHoiDongDanhGia,
                             IdDRL = drl.Id, 
                             HinhAnhMC = mc.HinhAnh

                         };


            ViewBag.Name = result.First();
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveAssessmentCommitteeScore(List<DiemHDDG_ID> diems)
        {
            foreach (var item in diems)
            {
                if (item.IdDRL == null)
                {
                    return NotFound();
                }

                var pointToUpdate = await _context.DiemRenLuyens.FirstOrDefaultAsync(d => d.Id == item.IdDRL);

                if (pointToUpdate == null)
                {
                    return NotFound();
                }

                // Cập nhật các điểm
                pointToUpdate.DiemHoiDongDanhGia = (decimal?)item.DiemHDDG;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Xử lý ngoại lệ nếu có
                    throw;
                }
            }

            return RedirectToAction(nameof(AssessmentCommitteeScore), new { id = diems.First().MaSV }); // Chuyển hướng sau khi lưu thành công
        }
        
        public IActionResult FacultyScore(string id)
        {
            var dbQuanLyDiemRenLuyenContext = _context.DiemRenLuyens.Include(d => d.IdHocKy).Include(d => d.IdMinhChung).Include(d => d.IdNoiDung).Include(d => d.IdSv);
            var result = from drl in _context.DiemRenLuyens
                         join ndtc in _context.NoiDungTieuChis on drl.IdNoiDung equals ndtc.IdNoiDung
                         join mtc in _context.MucTieuChis on ndtc.IdMuc equals mtc.IdMuc
                         join hk in _context.HocKies on drl.IdHocKy equals hk.IdHocKy
                         join sv in _context.SinhViens on drl.IdSv equals sv.IdSv
                         join mc in _context.MinhChungs on drl.IdMinhChung equals mc.Id
                         join lop in _context.Lops on sv.IdLop equals lop.IdLop
                         join khoa in _context.Khoas on lop.IdKhoa equals khoa.IdKhoa
                         where sv.IdSv == id
                         select new
                         {
                             MaSV = sv.IdSv,
                             TenSV = sv.TenSv,
                             Lop = lop.TenLop,
                             Khoa = khoa.TenKhoa,
                             TenMuc = mtc.TenMuc,
                             TenNoiDung = ndtc.TenNoiDung,
                             DiemToiDa = ndtc.DiemToiDa,
                             DiemSV = drl.DiemSv,
                             DiemBCS = drl.DiemBcs,
                             DiemGV = drl.DiemGv,
                             DiemKhoa = drl.DiemKhoa, 
                             IdDRL = drl.Id, 
                             HinhAnhMC = mc.HinhAnh

                         };


            ViewBag.Name = result.First();
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveFacultyScore(List<DiemKhoa_ID> diems)
        {
            foreach (var item in diems)
            {
                if (item.IdDRL == null)
                {
                    return NotFound();
                }

                var pointToUpdate = await _context.DiemRenLuyens.FirstOrDefaultAsync(d => d.Id == item.IdDRL);

                if (pointToUpdate == null)
                {
                    return NotFound();
                }

                // Cập nhật các điểm
                pointToUpdate.DiemKhoa = (decimal?)item.DiemKhoa;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Xử lý ngoại lệ nếu có
                    throw;
                }
            }

            return RedirectToAction(nameof(FacultyScore), new { id = diems.First().MaSV }); // Chuyển hướng sau khi lưu thành công
        }

        ////
        public IActionResult StudentScore(string id)
        {
            var dbQuanLyDiemRenLuyenContext = _context.DiemRenLuyens.Include(d => d.IdHocKy).Include(d => d.IdMinhChung).Include(d => d.IdNoiDung).Include(d => d.IdSv);
            var result = from drl in _context.DiemRenLuyens
                         join ndtc in _context.NoiDungTieuChis on drl.IdNoiDung equals ndtc.IdNoiDung
                         join mtc in _context.MucTieuChis on ndtc.IdMuc equals mtc.IdMuc
                         join hk in _context.HocKies on drl.IdHocKy equals hk.IdHocKy
                         join sv in _context.SinhViens on drl.IdSv equals sv.IdSv
                         join mc in _context.MinhChungs on drl.IdMinhChung equals mc.Id
                         join lop in _context.Lops on sv.IdLop equals lop.IdLop
                         join khoa in _context.Khoas on lop.IdKhoa equals khoa.IdKhoa
                         where sv.IdSv == id
                         select new
                         {
                             MaSV = sv.IdSv,
                             TenSV = sv.TenSv,
                             Lop = lop.TenLop,
                             Khoa = khoa.TenKhoa,
                             TenMuc = mtc.TenMuc,
                             TenNoiDung = ndtc.TenNoiDung,
                             DiemToiDa = ndtc.DiemToiDa,
                             IdDRL = drl.Id,
                             DiemSV = drl.DiemSv,
                             HinhAnhMC = mc.HinhAnh

                         };


            ViewBag.Name = result.First();
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveStudentScore(List<DiemSV_ID> diems)
        {
            foreach (var item in diems)
            {
                if (item.IdDRL == null)
                {
                    return NotFound();
                }

                var pointToUpdate = await _context.DiemRenLuyens.FirstOrDefaultAsync(d => d.Id == item.IdDRL);

                if (pointToUpdate == null)
                {
                    return NotFound();
                }

                // Cập nhật các điểm
                pointToUpdate.DiemKhoa = (decimal?)item.DiemSV;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Xử lý ngoại lệ nếu có
                    throw;
                }
            }

            return RedirectToAction(nameof(StudentScore), new { id = diems.First().MaSV }); // Chuyển hướng sau khi lưu thành công
        }
    }
}
