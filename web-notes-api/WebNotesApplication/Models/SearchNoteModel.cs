﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNotesApplication.Models
{
    public class SearchNoteModel
    {
        
        public int Id { get; set; }
        public Guid SharedId { get; set; }

        public string SearchValue { get; set; }
    }
}
