using System.Collections.Generic;

namespace WebNotesApi.Models.Notes
{
    public class CreateNoteRequest
    {
        public string Title { get; set; }
        public string NoteDocument { get; set; }
        public int UserId { get; set; }

        public List<string> NoteTags { get; set; }
    }
}
