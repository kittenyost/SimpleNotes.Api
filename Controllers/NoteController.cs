using Microsoft.AspNetCore.Mvc;
using SimpleNotes.Api.Interfaces;
using SimpleNotes.Api.Models;

namespace SimpleNotes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult GetNotes() => Ok(_noteService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetNoteById(int id)
        {
            var note = _noteService.GetById(id);
            if (note == null)
                return NotFound("Note not found");
            return Ok(note);
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] Note note)
        {
            var createdNote = _noteService.Add(note);
            return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, createdNote);
        }
        // PUT: api/note
        [HttpPut]
        public IActionResult UpdateNote([FromBody] Note note)
        {
            var updatedNote = _noteService.Update(note);
            if (updatedNote == null)
                return NotFound("Note not found");

            return Ok(updatedNote);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            if (!_noteService.Delete(id))
                return NotFound("Note not found");
            return NoContent();
        }
    }
}