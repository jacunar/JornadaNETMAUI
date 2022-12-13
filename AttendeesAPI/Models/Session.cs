using System;
using System.Collections.Generic;

namespace AttendeesAPI.Models {
    public partial class Session {
        public Session() {
            SessionAttendees = new HashSet<SessionAttendee>();
        }

        public int SessionId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<SessionAttendee> SessionAttendees { get; set; }
    }
}