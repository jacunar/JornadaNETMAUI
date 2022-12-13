using AttendeesAPI.Models;
using AttendeesAPI.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AttendeesAPI.Repository {
    public class AttendeesRepository : GenericRepository<Attendee, AttendeesContext> {
        public AttendeesRepository(AttendeesContext context) : base(context) {

        }

        public override Task DeleteAsync(int id) {
            var attendee = _set
                .Include(a => a.SessionAttendees)
                .ThenInclude(a => a.Session)
                .SingleOrDefault(a => a.AttendeeId == id);

            if (attendee is not null)
                _set.Remove(attendee);
            return Task.CompletedTask;
        }

    }
}
