namespace AttendeesAPI.Repository {
    public class SessionRepository : GenericRepository<Session, AttendeesContext> {
        public SessionRepository(AttendeesContext context) : base(context) {
        }

        public async override Task DeleteAsync(int id) {
            var session = await _set.Include(s => s.SessionAttendees)
                .SingleOrDefaultAsync(s => s.SessionId == id);
            if (session is not null)
                _set.Remove(session);
        }
    }
}
