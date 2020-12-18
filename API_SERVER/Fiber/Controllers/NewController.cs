using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiber.Server.New;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model.New;

namespace Fiber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        INew _new;
        public NewController(INew _new)
        {
            this._new = _new;
        }
        [HttpGet("test")]
        public dynamic test()
        {
            return "test successfully";
        }
        [HttpGet("Get_List_New")]
        public dynamic Get_List_New(string month)
        {
            return _new.Get_List_New(month);
        }
        [HttpGet("Get_List_News")]
        public dynamic Get_List_News(int year)
        {
            return _new.Get_List_News(year);
        }
        [HttpPost("Insert_List_New")]
        public dynamic Insert_List_New(string month)
        {
            return _new.Insert_List_New(month);
        }

        [HttpPost("Delete_List_New")]
        public dynamic Delete_List_New(string month)
        {
            return _new.Delete_List_New(month);
        }
        [HttpGet("Get_Info_ByID")]
        public dynamic Get_Info_ByID(string ma_tb)
        {
            return _new.Get_Info_ByID(ma_tb);
        }

        [HttpPut("Insert")]
        public dynamic Insert([FromBody] NewModel newModel)
        {
            return _new.Insert(newModel);
        }

    }
}
