using System.Collections.Generic;
using System.Threading.Tasks;
using WebNotesApplication.Models;
using WebNotesData.Entities;

namespace WebNotesApplication.Services
{
    public interface INoteService
    {

        Task<Note> GetNote(SearchNoteModel searchNoteModel);
        Task<List<Note>> GetNotes(SearchNoteModel searchNoteModel);
        Task<Note> CreateNoteAsync(CreateNoteModel createNoteModel);
        Task<Note> UpdateNoteAsync(UpdateNoteModel updateNoteModel);
        Task DeleteNoteAsync(int id);
    }
}
