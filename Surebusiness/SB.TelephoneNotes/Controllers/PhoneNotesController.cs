using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SB.TelephoneNotes.Api.Models;
using SB.TelephoneNotes.BLL.Interfaces;
using SB.TelephoneNotes.BLL.Interfaces.Commands;
using SB.TelephoneNotes.BLL.Interfaces.Models;
using System;
using System.Threading.Tasks;


namespace SB.TelephoneNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneNotesController : ControllerBase
    {
        private readonly IPersistPhoneNotesService _persistPhoneNotesService;
        private readonly IQueryPhoneNotesService _queryPhoneNotesService;
        private readonly ILogger<PhoneNotesController> _logger;

        public PhoneNotesController(ILogger<PhoneNotesController> logger,
            IPersistPhoneNotesService persistPhoneNotesService,
            IQueryPhoneNotesService queryPhoneNotesService)
        {
            _logger = logger;
            _persistPhoneNotesService = persistPhoneNotesService;
            _queryPhoneNotesService = queryPhoneNotesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try {
                var notes = await _queryPhoneNotesService.GetAll();
                return Ok(notes);
            }catch(Exception exception)
            {
                _logger.LogError(exception, $"Failed to get notes");
                return StatusCode(StatusCodes.Status500InternalServerError, "Onverwachte fout opgetreden");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var phoneNote = await _queryPhoneNotesService.GetById(id);
            if(phoneNote == null)
            {
                return NotFound();
            }

            return Ok(phoneNote);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhoneNote), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreatePhoneNoteCommand createPhoneNoteCommand)
        {
            try
            {
                var createdPhoneNote = await _persistPhoneNotesService.Save(createPhoneNoteCommand);
                return CreatedAtAction(nameof(GetById), new { id = createdPhoneNote.Id }, createdPhoneNote);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed to create phone note");
                return StatusCode(StatusCodes.Status500InternalServerError, "Onverwachte fout opgetreden");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put()
        {
            try
            {
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed to update notes");
                return StatusCode(StatusCodes.Status500InternalServerError, "Onverwachte fout opgetreden");
            }
        }
    }
}
