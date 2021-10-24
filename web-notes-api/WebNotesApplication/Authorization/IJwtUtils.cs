using WebNotesData.Entities;

namespace WebNotesApplication.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string token);
    }
}
