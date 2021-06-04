using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Logic.Services
{
    public interface ISessionService
    {
        Task<string> CreateAuthCookieAsync(int id);
        Task<int> GetIdFromAuthCookieAsync(string cookie);
    }
}
