using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Server.Role.QuyenSudungChucnang;
using AuthService.Server.user;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Iuser user;
        IquyenSudungChucnang quyensudungchucnang;
        public UserController(Iuser user, IquyenSudungChucnang quyensudungchucnang)
        {
            this.user = user;
            this.quyensudungchucnang = quyensudungchucnang;
        }
        [HttpGet("test")]
        public dynamic test()
        { return "success"; }
        //[Authorize(Policy = "3")]
        
        [HttpGet("Lay_DS_Nguoidung")]
        public dynamic Lay_DS_Nguoidung()
        {
            return user.Lay_DS_Nguoidung();
        }
        // Quyền người dùng
        [Authorize(Policy = "11")]
        [HttpGet("Lay_DS_Quyen_Nguoidung")]
        public dynamic Lay_DS_Quyen_Nguoidung(string ma_nd, int chucnang_id)
        {
            return user.Lay_DS_Quyen_Nguoidung(ma_nd);
        }
        //Menu người dùng
        [Authorize(Policy = "2")]
        [HttpGet("Lay_DS_Menu_Nguoidung")]
        public dynamic Lay_DS_Menu_Nguoidung(string ma_nd)
        {
            return user.Lay_DS_Menu_Nguoidung(ma_nd);
        }
        [Authorize(Policy = "2")]
        [HttpGet("Lay_DS_LoaiNV_Nguoidung")]
        public dynamic Lay_DS_LoaiNV_Nguoidung(string ma_nd)
        {
            return user.Lay_DS_LoaiNV_Nguoidung(ma_nd);
        }
        //Báo cáo người dùng
        [Authorize(Policy = "4")]
        [HttpGet("Lay_DS_Nhombaocao_Nguoidung")]
        public dynamic Lay_DS_Nhombaocao_Nguoidung(string ma_nd)
        {
            return user.Lay_DS_Nhombaocao_Nguoidung(ma_nd);
        }
        [Authorize(Policy = "4")]
        [HttpGet("Lay_DS_Baocao_Nguoidung")]
        public dynamic Lay_DS_Baocao_Nguoidung(string ma_nd, int nhom_bc_id)
        {
            return user.Lay_DS_Baocao_Nguoidung(ma_nd, nhom_bc_id);
        }

    }
}
