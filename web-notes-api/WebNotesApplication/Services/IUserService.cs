using System.Collections.Generic;
using WebNotesApplication.Models;
using WebNotesData.Entities;

namespace WebNotesApplication.Services
{
    public interface IUserService
    {
        AuthenticateResult Authenticate(LoginModel model);
        AuthenticateResult Register(User model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
