using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNotesApplication.Authorization;
using WebNotesApplication.Exceptions;
using WebNotesApplication.Models;
using WebNotesData.Context;
using WebNotesData.Entities;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebNotesApplication.Services
{
    public class UserService : IUserService
    {
        private ApplicationContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        private readonly IMapper _mapper;

        public UserService(
            ApplicationContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }


        public async Task<AuthenticateResult> AuthenticateAsync(LoginModel model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                throw new AppException("Username or password is incorrect");
            }

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            var authResult = _mapper.Map<AuthenticateResult>(user);
            authResult.Token = jwtToken;

            return authResult;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            return user;
        }

        public async Task<AuthenticateResult> RegisterAsync(User user)
        {
            var existUser = await _context.Users.SingleOrDefaultAsync(x => x.UserName == user.UserName);
            if(existUser is not null)
            {
                throw new AppException($"User with user name {user.UserName} exists");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            var authResult = _mapper.Map<AuthenticateResult>(user);
            authResult.Token = jwtToken;

            return authResult;
        }
    }
}
