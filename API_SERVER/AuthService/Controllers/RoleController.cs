using AuthService.Server.Role;
using AuthService.Server.Role.Chucnang;
using AuthService.Server.Role.Phanquyen;
using AuthService.Server.Role.QuyenSudungChucnang;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
  
    public class RoleController : ControllerBase
    {
        Iphanquyen phanquyen;
        Iquyen quyen;
        Ichucnang chucnang;
        IquyenSudungChucnang quyensudungchucnang;

        public RoleController(Iphanquyen phanquyen, Iquyen quyen, 
            Ichucnang chucnang, IquyenSudungChucnang quyensudungchucnang)
        {
            this.phanquyen = phanquyen;
            this.quyen = quyen;
            this.chucnang = chucnang;
            this.quyensudungchucnang = quyensudungchucnang;
        }
        [AllowAnonymous]
        [HttpGet("test")]
        public dynamic test()
        {
            return "success";
        }

        [HttpGet("Lay_DS_Quyen")]
        public dynamic Lay_DS_Quyen()
        {
            return quyen.Lay_DS_Quyen();
        }
        
        [HttpGet("Lay_Quyen_Nguoidung")]
        public dynamic Lay_Quyen_Nguoidung(string ma_nd)
        {
            return phanquyen.Lay_Quyen_Nguoidung(ma_nd);
        }
        //Chức năng
        [HttpGet("Lay_DS_Chucnang")]
        public dynamic Lay_DS_Chucnang()
        {
            return chucnang.Lay_DS_Chucnang();
        }

        [HttpGet("Lay_DS_Chucnang_Theo_DS_Chucnang_ID")]
        public dynamic Lay_DS_Chucnang_Theo_DS_Chucnang_ID(string dschucnang_id)
        {
            return chucnang.Lay_DS_Chucnang_Theo_DS_Chucnang_ID(dschucnang_id);
        }
        //Quyền sử dụng chức năng
        
        [HttpGet("Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID")]
        public dynamic Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(int quyen_id)
        {
            return quyensudungchucnang.Lay_DS_Quyen_Sudung_Chucnang_Theo_Quyen_ID(quyen_id);
        }

        //Quản trị
        [Authorize(Policy = "10")]
        [HttpGet("Lay_DS_Chucnang_Theo_Quyen_ID")]
        public dynamic Lay_DS_Chucnang_Theo_Quyen_ID(int quyen_id)
        {
            return chucnang.Lay_DS_Chucnang_Theo_Quyen_ID(quyen_id);
        }
        [Authorize(Policy = "10")]
        [HttpDelete("Xoa_Quyen_Sudung_Chucnang")]
        public dynamic Xoa_Quyen_Sudung_Chucnang([FromBody] RoleUpdateRequestModel roleUpdateRequest)
        {
            return quyensudungchucnang.Xoa_Quyen_Sudung_Chucnang(roleUpdateRequest);
        }
        [Authorize(Policy = "10")]
        [HttpPut("Them_Quyen_Sudung_Chucnang")]
        public dynamic Them_Quyen_Sudung_Chucnang([FromBody] RoleUpdateRequestModel roleUpdateRequest)
        {
            return quyensudungchucnang.Them_Quyen_Sudung_Chucnang(roleUpdateRequest);
        }
        [Authorize(Policy = "10")]
        [HttpPut("Them_Quyen")]
        public dynamic Them_Quyen([FromBody] QuyenModel quyenmodel)
        {
            return quyen.Them_Quyen(quyenmodel);
        }
        [Authorize(Policy = "10")]
        [HttpGet("Lay_DS_Nguoidung_Theo_Quyen")]
        public dynamic Lay_DS_Nguoidung_Theo_Quyen(int quyen_id)
        {
            return phanquyen.Lay_DS_Nguoidung_Theo_Quyen(quyen_id);
        }
        [Authorize(Policy = "10")]
        [HttpPut("Them_Phanquyen_Nguoidung")]
        public dynamic Them_Phanquyen_Nguoidung(PhanquyenModel phanquyenmodel)
        {
            return phanquyen.Them_Phanquyen_Nguoidung(phanquyenmodel);
        }
        [Authorize(Policy = "10")]
        [HttpPut("Xoa_Phanquyen_Nguoidung")]
        public dynamic Xoa_Phanquyen_Nguoidung(PhanquyenModel phanquyenmodel)
        {
            return phanquyen.Xoa_Phanquyen_Nguoidung(phanquyenmodel);
        }
    }
}
