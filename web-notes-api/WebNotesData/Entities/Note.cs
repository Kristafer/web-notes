using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebNotesData.Entities
{
    public class Note
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Title { get; set; }

        [Column(TypeName = "NVARCHAR(MAX)")]
        [MaxLength]
        public string NoteDocument { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<NoteTag> NoteTags { get; set; }

        public bool IsBookmark { get; set; }
        
        public List<ShareNote> ShareNotes { get; set; }
    }
}
