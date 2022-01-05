using System;

namespace WebNotesApplication.Models
{
    public class SearchNoteModel
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid SharedId { get; set; }

        public string SearchValue { get; set; }
    }
}
