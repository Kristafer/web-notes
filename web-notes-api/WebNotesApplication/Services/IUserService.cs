using System.Collections.Generic;
using WebNotesApplication.Models;
using WebNotesData.Entities;

namespace WebNotesApplication.Services
{
    public interface IUserService
    {
        AuthenticateResult AuthenticateAsync(LoginModel model);
        AuthenticateResult RegisterAsync(User model);
        IEnumerable<User> GetAllAsync();
        User GetByIdAsync(int id);
    }
}
