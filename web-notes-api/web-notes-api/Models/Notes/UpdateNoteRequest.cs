using System;
using System.Collections.Generic;

namespace WebNotesApi.Models.Notes
{
    public class UpdateNoteRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NoteDocument { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int UserId { get; set; }

        public List<string> NoteTags { get; set; }
    }
}
