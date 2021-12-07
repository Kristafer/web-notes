using System.Collections.Generic;

namespace WebNotesApplication.Models
{
    public class CreateNoteModel
    {
        public string Title { get; set; }
        public string NoteDocument { get; set; }
        public int UserId { get; set; }

        public List<string> NoteTags { get; set; }
    }
}
