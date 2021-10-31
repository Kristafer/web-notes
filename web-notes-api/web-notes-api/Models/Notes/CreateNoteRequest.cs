using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNotesApi.Models.Notes
{
    public class CreateNoteRequest
    {
        public string Title { get; set; }
        public string NoteDocument { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int UserId { get; set; }

        public List<string> Tags { get; set; }
    }
}
