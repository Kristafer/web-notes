using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
