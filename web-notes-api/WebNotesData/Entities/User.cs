using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebNotesData.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public List<Note> Notes { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
