using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNotesData.Entities
{
    public class NoteTag
    {
        public int Id { get; set; }

        public int TagId { get; set; }
        public int NoteId { get; set; }

        public Tag Tag { get; set; }
        public Note Note { get; set; }

    }
}
