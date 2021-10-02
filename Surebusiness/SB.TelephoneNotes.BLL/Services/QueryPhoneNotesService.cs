using SB.TelephoneNotes.BLL.Interfaces.Models;
using SB.TelephoneNotes.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SB.TelephoneNotes.BLL.Mappers;
using SB.TelephoneNotes.BLL.Interfaces;

namespace SB.TelephoneNotes.BLL.Services
{
    public class QueryPhoneNotesService : IQueryPhoneNotesService
    {
        private readonly INotesRepository _notesRepository;
        public QueryPhoneNotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        public async Task<List<PhoneNote>> GetAll()
        {
            var noteEntities = await _notesRepository.GetAll();
            return noteEntities.MapToDomainModel();
        }

        public async Task<PhoneNote> GetById(int id)
        {
            var noteEntity = await _notesRepository.Get(id);
            return noteEntity.MapToDomainModel();
        }
    }
}
