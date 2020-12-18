using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Model.AuthorizationHandler
{
    public class CheckPermissionsRequirement : IAuthorizationRequirement
    {
        public int chucnang_id { get; set; }
        public CheckPermissionsRequirement(int chucnang_id)
        {
            this.chucnang_id = chucnang_id;
        }
    }
}
