using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SB.TelephoneNotes.Api.Models;
using SB.TelephoneNotes.BLL.Interfaces;
using SB.TelephoneNotes.BLL.Interfaces.Commands;
using SB.TelephoneNotes.BLL.Interfaces.Models;
using SB.TelephoneNotes.BLL.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SB.TelephoneNotes.Controllers
{
    [ApiController]
    [Route("api/v1/phonenotes")]
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
        [ProducesResponseType(typeof(IEnumerable<PhoneNote>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(PhoneNote), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var phoneNote = await _queryPhoneNotesService.GetById(id);
            if(phoneNote == null)
                return NotFound(false);

            return Ok(phoneNote);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhoneNote), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreatePhoneNote createPhoneNoteCommand)
        {
            try
            {
                var validateResult = new CreatePhoneNoteValidator().Validate(createPhoneNoteCommand);
                if (!validateResult.IsValid)
                    return BadRequest(new BadRequestModel(validateResult));

                var createdPhoneNote = await _persistPhoneNotesService.Save(createPhoneNoteCommand);
                return CreatedAtAction(nameof(GetById), new { id = createdPhoneNote.Id }, createdPhoneNote);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed to create phone note");
                return StatusCode(StatusCodes.Status500InternalServerError, "Onverwachte fout opgetreden");
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(PhoneNote), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<PatchPhoneNote> phoneNotePatchDocument)
        {
            try
            {
                if (phoneNotePatchDocument == null)
                    return BadRequest(new BadRequestModel("JsonPatchDocument missing"));

                var phoneNote = await _queryPhoneNotesService.GetById(id);
                if (phoneNote == null)
                    return NotFound(false);

                var savedPhoneNote = await _persistPhoneNotesService.Patch(id, phoneNotePatchDocument);

                return Ok(savedPhoneNote);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed to patch phone note with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Onverwachte fout opgetreden");
            }
        }
    }
}
