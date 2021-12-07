using System;
using System.ComponentModel.DataAnnotations;

namespace WebNotesData.Entities
{
    public class ShareNote
    {
        public int Id { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }
        public DateTime InactivatedDateTime { get; set; }

        public Note Note { get; set; }
        public int NoteId { get; set; }
    }
}
