using AutoMapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
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


        public AuthenticateResult Authenticate(LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

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

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            return user;
        }

        public AuthenticateResult Register(User user)
        {
            var existUser = _context.Users.SingleOrDefault(x => x.Username == user.Username);
            if(existUser is not null)
            {
                throw new AppException($"User with user name {user.Username} exists");
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
