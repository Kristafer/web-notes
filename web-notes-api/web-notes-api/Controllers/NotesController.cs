using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebNotesApi.Authorization;
using WebNotesApi.Models.Notes;
using WebNotesApi.Models.Users;
using WebNotesApplication.Models;
using WebNotesApplication.Services;
using WebNotesData.Entities;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace WebNotesApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController
    {
        private INoteService _noteService;
        private readonly IMapper _mapper;

        public NotesController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<NoteResponse>> GetNote(int id)
        {
            var response = await _noteService.GetNote(new SearchNoteModel()
            {
                Id = id
            });

            return _mapper.Map<NoteResponse>(response);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<NoteResponse>>> GetNotes([FromQuery]SearchNoteModel searchNoteModel)
        {
            var response = await _noteService.GetNotes(searchNoteModel);

            return _mapper.Map<List<NoteResponse>>(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<NoteResponse>> CreateNote(CreateNoteRequest request)
        {
            var response = await _noteService.CreateNoteAsync(_mapper.Map<CreateNoteModel>(request));

            return _mapper.Map<NoteResponse>(response);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<NoteResponse>> UpdateNote(UpdateNoteRequest request)
        {
            var response = await _noteService.UpdateNoteAsync(_mapper.Map<UpdateNoteModel>(request));

            return _mapper.Map<NoteResponse>(response);
        }

        //[AllowAnonymous]
        //[HttpGet("[action]/{id}")]
        //public async Task<ActionResult<NoteResponse>> GetNoteShared(Guid id)
        //{
        //    var response = await _noteService.GetNote(new SearchNoteModel()
        //    {
        //        Id = id
        //    });

        //    return _mapper.Map<NoteResponse>(response);
        //}
    }
}
