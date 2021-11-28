using System.Collections.Generic;

namespace WebNotesApplication.Models
{
    public class UpdateNoteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoteDocument { get; set; }
        public int UserId { get; set; }

        public List<string> NoteTags { get; set; }
    }
}
