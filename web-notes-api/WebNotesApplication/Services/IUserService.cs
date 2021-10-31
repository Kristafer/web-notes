using System.Collections.Generic;
using System.Threading.Tasks;
using WebNotesApplication.Models;
using WebNotesData.Entities;

namespace WebNotesApplication.Services
{
    public interface IUserService
    {
        Task<AuthenticateResult> AuthenticateAsync(LoginModel model);
        Task<AuthenticateResult> RegisterAsync(User model);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
    }
}
