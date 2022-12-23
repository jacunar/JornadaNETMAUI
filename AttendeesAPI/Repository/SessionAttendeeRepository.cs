namespace AttendeesAPI.Repository {
    public class SessionAttendeeRepository : GenericRepository<SessionAttendee, AttendeesContext> {
        public SessionAttendeeRepository(AttendeesContext context) : base(context) {
        }

        public override async Task DeleteAsync(int id) {
            var sessionAttendee = await _set.FindAsync(id);
            if(sessionAttendee is not null) {
                _set.Remove(sessionAttendee);
            }
        }
    }
}
