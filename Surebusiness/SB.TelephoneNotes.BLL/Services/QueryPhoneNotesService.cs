using SB.TelephoneNotes.BLL.Interfaces.Models;
using SB.TelephoneNotes.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SB.TelephoneNotes.BLL.Mappers;
using SB.TelephoneNotes.BLL.Interfaces;
using System.Linq;

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

        public PagedList<PhoneNote> GetNotes(NotesFilter notesFilter)
        {
            var notesIQueryable = _notesRepository.GetIQueryable();

            if (!string.IsNullOrEmpty(notesFilter.AssignedTo))
                notesIQueryable = notesIQueryable.Where(x => x.AssignedTo == notesFilter.AssignedTo);
            
            if (!string.IsNullOrEmpty(notesFilter.Status))
                notesIQueryable = notesIQueryable.Where(x => x.Status == notesFilter.Status);

            var count = notesIQueryable.Count();
            var items = notesIQueryable.Skip((notesFilter.PageNumber - 1) * notesFilter.PageSize).Take(notesFilter.PageSize).ToList().MapToDomainModel();
            return PagedList<PhoneNote>.ToPagedList(items, count, notesFilter.PageNumber, notesFilter.PageSize);
        }
      
    }
}
