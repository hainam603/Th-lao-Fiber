using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Model;

namespace AuthService.Server.auth
{
    public interface Iauth
    {
        dynamic genToken(string username, string Rolename);
        dynamic login(LoginRequestModel lrm);
        dynamic getRole(LoginRequestModel lrm);
    }
}
