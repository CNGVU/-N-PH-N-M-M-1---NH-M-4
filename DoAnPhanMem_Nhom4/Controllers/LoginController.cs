
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Mvc;
using DoAnPhanMem_Nhom4.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnPhanMem_Nhom4.Controllers
{
    public class LoginController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DbQuanLyDiemRenLuyenContext _context;
        public LoginController(DbQuanLyDiemRenLuyenContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "HomePage");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(VMLogin modelLogin)
        {
			string controllerName = "", actionName = "", id = "";
			if (modelLogin.Role == "sinh-vien" || modelLogin.Role == "ban-can-su" || modelLogin.Role == "ban-can-su"||
				  modelLogin.Role == "giang-vien-chu-nhiem"||modelLogin.Role == "khoa"||
				  modelLogin.Role == "phong-cong-tac-sinh-vien"||modelLogin.Role == "hoi-dong-danh-gia") 
			{
				var claims = new List<Claim>();

				if (modelLogin.Role == "sinh-vien")
				{
					var user = await _context.SinhViens.Where(a=> a.TenDangNhap == modelLogin.Username && a.MatKhau == modelLogin.Password 
																&& a.BanCanSu == "0" ).FirstOrDefaultAsync();
					claims.Add(new Claim(ClaimTypes.Name, user.TenDangNhap));
					claims.Add(new Claim(ClaimTypes.NameIdentifier, user.IdSv));
					claims.Add(new Claim(ClaimTypes.Role, "sinh-vien"));
					controllerName = "DiemRenLuyens";
					actionName = "";
				}
				else if (modelLogin.Role == "ban-can-su")
				{
					var user = await _context.SinhViens.Where(a => a.TenDangNhap == modelLogin.Username && a.MatKhau == modelLogin.Password
																&& a.BanCanSu == "1").FirstOrDefaultAsync();
					claims.Add(new Claim(ClaimTypes.Name, user.TenDangNhap));
					claims.Add(new Claim(ClaimTypes.NameIdentifier, user.IdSv));
					controllerName = "DiemRenLuyens";
					actionName = "";
				}
				else if (modelLogin.Role == "giang-vien-chu-nhiem")
				{
					var user = await _context.Gvcns.Where(a => a.TenDangNhap == modelLogin.Username && a.MatKhau == modelLogin.Password).FirstOrDefaultAsync();
					claims.Add(new Claim(ClaimTypes.Name, user.TenDangNhap));
					claims.Add(new Claim(ClaimTypes.NameIdentifier, user.IdGv));
					controllerName = "DiemRenLuyens";
					actionName = "";

				}
				else if (modelLogin.Role == "khoa")
				{
					var user = await _context.Khoas.Where(a => a.TaiKhoan == modelLogin.Username && a.MatKhau == modelLogin.Password).FirstOrDefaultAsync();
					claims.Add(new Claim(ClaimTypes.Name, user.TaiKhoan));
					claims.Add(new Claim(ClaimTypes.NameIdentifier, user.IdKhoa));
                    claims.Add(new Claim(ClaimTypes.Role, "khoa"));
                    controllerName = "Lops";
					actionName = "Index" ;
					id = user.IdKhoa;
				}
				else if (modelLogin.Role == "phong-cong-tac-sinh-vien")
				{
					var user = await _context.Pctsvs.Where(a => a.TenDangNhap == modelLogin.Username && a.MatKhau == modelLogin.Password).FirstOrDefaultAsync();
					claims.Add(new Claim(ClaimTypes.Name, user.TenDangNhap));
					claims.Add(new Claim(ClaimTypes.NameIdentifier, user.IdCb));
					controllerName = "DiemRenLuyens";
					actionName = "";
				}
				else if (modelLogin.Role == "hoi-dong-danh-gia")
				{
					var user = await _context.ThanhVienHoiDongs.Where(a => a.TenDangNhap == modelLogin.Username && a.MatKhau == modelLogin.Password).FirstOrDefaultAsync();
					claims.Add(new Claim(ClaimTypes.Name, user.TenDangNhap));
					claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
					controllerName = "DiemRenLuyens";
					actionName = "AssessmentCommitteeScore";
				}
				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				AuthenticationProperties properties = new AuthenticationProperties()
				{
					AllowRefresh = true,
					IsPersistent = modelLogin.KeepLoggedIn
				};
				var princial = new ClaimsPrincipal(claimsIdentity);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princial, properties);
				return RedirectToAction(actionName, controllerName, new { id});
			}
			 
			return View();
        }
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
