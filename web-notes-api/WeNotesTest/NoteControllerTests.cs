using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using WebNotesApi.Controllers;
using WebNotesApi.Models.Notes;
using WebNotesApi.Profiles;
using WebNotesApplication.Models;
using WebNotesApplication.Services;
using WebNotesData.Entities;

namespace WeNotesTest
{
    public class NoteControllerTests
    {
        private static IMapper _mapper;

        public NoteControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [TestCase("Test")]
        [TestCase("1")]
        [TestCase("")]
        public async Task CreateNote_CorrectModel_SuccessResult(string title)
        {
            var request = new CreateNoteRequest()
            {
                Title = title
            };

            var mock = new Mock<INoteService>();
            mock.Setup(a => a.CreateNoteAsync(It.IsAny<CreateNoteModel>())).ReturnsAsync(new Note()
            {
                Title = title
            });
            var controller = new NotesController(mock.Object, _mapper);
            
            // Act
            var result = await controller.CreateNote(request);

            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.Value.Title, title);
        }

        [TestCase("Test")]
        [TestCase("1")]
        [TestCase("")]
        public async Task CreateNote_CorrectModelSecond_SuccessResult(string title)
        {
            var request = new CreateNoteRequest()
            {
                Title = title,
                NoteTags = new List<string>()
                {
                    "Test",
                    "Tag"
                }
            };

            var mock = new Mock<INoteService>();
            mock.Setup(a => a.CreateNoteAsync(It.IsAny<CreateNoteModel>())).ReturnsAsync(new Note()
            {
                Title = title,
            });
            var controller = new NotesController(mock.Object, _mapper);

            // Act
            var result = await controller.CreateNote(request);

            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.Value.Title, title);
        }


        [TestCase("Test")]
        [TestCase("1")]
        [TestCase("")]
        public async Task UpdateNote_CorrectModel_SuccessResult(string title)
        {
            var request = new UpdateNoteRequest()
            {
                Title = title,
            };

            var mock = new Mock<INoteService>();
            mock.Setup(a => a.UpdateNoteAsync(It.IsAny<UpdateNoteModel>())).ReturnsAsync(new Note()
            {
                Title = title,
            });
            var controller = new NotesController(mock.Object, _mapper);

            // Act
            var result = await controller.UpdateNote(request);

            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.Value.Title, title);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(2)]
        public async Task DeleteNote_CorrectModel_SuccessResult(int id)
        {
            var mock = new Mock<INoteService>();
            mock.Setup(a => a.DeleteNoteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
            var controller = new NotesController(mock.Object, _mapper);
            
            // Act
            var result = await controller.DeleteNote(id);
            
            Assert.IsNotNull(result);
        }
    }
}
