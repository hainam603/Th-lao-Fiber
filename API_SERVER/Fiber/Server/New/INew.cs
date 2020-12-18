using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Model.New;

namespace Fiber.Server.New
{
    public interface INew
    {
        dynamic Insert_List_New(string month);
        dynamic Delete_List_New(string month);
        dynamic Get_List_New(string month);
        dynamic Get_List_News(int year);
        dynamic Get_Info_ByID(string ma_tb);
        dynamic Insert(NewModel New);
        dynamic Update(NewModel New);
        dynamic Delete(NewModel New);
    }
}
