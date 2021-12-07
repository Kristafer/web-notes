using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WebNotesApi.Profiles;
using WebNotesApplication.Models;
using WebNotesApplication.Services;
using WebNotesData.Context;

namespace WeNotesTest
{
    public class NoteServiceTests
    {
        private ApplicationContext _context;


        private static IMapper _mapper;

        public NoteServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationContext(options);
        }

        [TestCase("Title")]
        [TestCase("Test")]
        [TestCase("")]
        public async Task CreateNote_Note_GetNoteAsync(string title)
        {
            var note = new CreateNoteModel()
            {
                Title = title,
                NoteTags = new List<string>()
            };
            var noteService = new NoteService(_context, _mapper);
            // Act
            var result = await noteService.CreateNoteAsync(note);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Title, title);
        }


        [TestCase("Title")]
        [TestCase("Test")]
        [TestCase("")]
        public async Task UpdateNote_Note_GetNoteAsync(string title)
        {
            var note = new CreateNoteModel()
            {
                Title = title,
                NoteTags = new List<string>()
            };
            var noteService = new NoteService(_context, _mapper);
            // Act
            var result = await noteService.CreateNoteAsync(note);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Title, title);
        }

        [TestCase("Title")]
        [TestCase("Test")]
        [TestCase("")]
        public async Task DeleteNote_Note_GetNoteAsync(string title)
        {
            var note = new CreateNoteModel()
            {
                Title = title,
                NoteTags = new List<string>()
            };
            var noteService = new NoteService(_context, _mapper);
            // Act
            var result = await noteService.CreateNoteAsync(note);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Title, title);
        }
    }
}