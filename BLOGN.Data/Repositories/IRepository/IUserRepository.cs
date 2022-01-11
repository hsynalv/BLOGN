using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        User Authentice(string username,string password);
        User Register(string username,string password);
    }
}
