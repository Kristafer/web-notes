using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebNotesApplication.Exceptions;
using WebNotesApplication.Models;
using WebNotesData.Context;
using WebNotesData.Entities;

namespace WebNotesApplication.Services
{
    public class NoteService : INoteService
    {
        private ApplicationContext _context;

        private readonly IMapper _mapper;

        public NoteService(
            ApplicationContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Note> GetNote(SearchNoteModel searchNoteModel)
        {
            var note = await _context.Notes.Include(x => x.NoteTags).ThenInclude(x => x.Tag).SingleOrDefaultAsync(n => n.Id == searchNoteModel.Id);
            if (note is null)
            {
                throw new AppException($"Note with id = {searchNoteModel.Id} not founded");
            }

            return note;
        }

        public async Task<List<Note>> GetNotes(SearchNoteModel searchNoteModel)
        {
            var notes = await _context.Notes.Include(x => x.NoteTags).ThenInclude(x => x.Tag).Where(n => n.Id == searchNoteModel.Id).ToListAsync();
            if (!notes.Any())
            {
                throw new AppException($"Notes with search criteria not founded");
            }

            return notes;
        }

        public async Task<Note> CreateNoteAsync(CreateNoteModel createNoteModel)
        {
            var note = _mapper.Map<Note>(createNoteModel);
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            await CreateOrUpdateTags(note.Id, createNoteModel.Tags);
            // TODO Add Tags create and update

            return await GetNoteFull(note.Id);// include extend table
        }


        public async Task<Note> UpdateNoteAsync(UpdateNoteModel updateNoteModel)
        {
            var note = await _context.Notes.SingleOrDefaultAsync(n => n.Id == updateNoteModel.Id);
            note.NoteDocument = updateNoteModel.NoteDocument;
            note.Title = updateNoteModel.Title;

            // TODO Add Tags create and update
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            await CreateOrUpdateTags(note.Id, updateNoteModel.Tags);

            return await GetNoteFull(note.Id);// include extend table
        }

        private async Task CreateOrUpdateTags(int noteId, List<string> tags)
        {
            var existedNoteTags = await _context.NoteTags.Where(t => t.NoteId == noteId).ToListAsync();

            var removeNoteTags = existedNoteTags.Where(t => !tags.Contains(t.Tag.Value));
            var addTags = tags.Where(t => existedNoteTags.All(nt => nt.Tag.Value != t)).ToList();

            _context.NoteTags.RemoveRange(removeNoteTags);
            await _context.SaveChangesAsync();

            var tagsDb = await _context.Tags.ToListAsync();

            var addNewNoteTags = tagsDb.Where(at => addTags.Exists(x => x == at.Value)).ToList();
            var addNewTags = addTags.Where(at => addNewNoteTags.All(x => x.Value != at)).ToList();

            addNewTags.ForEach(async tag =>
            {
                var newTag = new Tag()
                {
                    Value = tag
                };
                await _context.Tags.AddAsync(newTag);

                var newNoteTag = new NoteTag()
                {
                    NoteId = noteId,
                    Tag = newTag
                };
                await _context.NoteTags.AddAsync(newNoteTag);
                await _context.SaveChangesAsync();
            });

            addNewNoteTags.ForEach(async tag =>
            {
                var newNoteTag = new NoteTag()
                {
                    NoteId = noteId,
                    Tag = tag
                };
                await _context.NoteTags.AddAsync(newNoteTag);
                await _context.SaveChangesAsync();
            });
        }

        private async Task<Note> GetNoteFull(int id)
        {
            return await _context.Notes.Include(x => x.NoteTags).ThenInclude(x => x.Tag).SingleOrDefaultAsync(n => n.Id == id);
        }
    }
}
