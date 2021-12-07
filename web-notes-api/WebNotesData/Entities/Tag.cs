#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebNotesData.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public User? User { get; set; }

        public int? UserId { get; set; }

        public List<NoteTag> NoteTags { get; set; }
    }
}
