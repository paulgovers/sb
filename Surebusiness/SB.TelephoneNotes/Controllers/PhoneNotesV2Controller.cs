using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SB.TelephoneNotes.BLL.Interfaces;
using SB.TelephoneNotes.BLL.Interfaces.Models;
using System;

namespace SB.TelephoneNotes.Controllers
{
    [ApiController]
    [Route("api/v2/phonenotes")]
    public class PhoneNotesV2Controller : ControllerBase
    {
        private readonly IQueryPhoneNotesService _queryPhoneNotesService;
        private readonly ILogger<PhoneNotesController> _logger;

        public PhoneNotesV2Controller(ILogger<PhoneNotesController> logger,
            IQueryPhoneNotesService queryPhoneNotesService)
        {
            _logger = logger;
            _queryPhoneNotesService = queryPhoneNotesService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(PagedList<PhoneNote>), StatusCodes.Status200OK)]
        public IActionResult GetPagedAndFilter([FromQuery] NotesFilter notesFilter)
        {
            try
            {
                var notes = _queryPhoneNotesService.GetNotes(notesFilter);
                var metadata = new
                {
                    notes.TotalCount,
                    notes.PageSize,
                    notes.CurrentPage,
                    notes.TotalPages,
                    notes.HasNext,
                    notes.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(notes);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed to get notes");
                return StatusCode(StatusCodes.Status500InternalServerError, "Onverwachte fout opgetreden");
            }
        }
    }
}
