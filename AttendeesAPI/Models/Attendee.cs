using System;
using System.Collections.Generic;

namespace AttendeesAPI.Models {
    public partial class Attendee {
        public Attendee() {
            SessionAttendees = new HashSet<SessionAttendee>();
        }

        public int AttendeeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime AttendanceDate { get; set; }
        public string Location { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;

        public virtual ICollection<SessionAttendee> SessionAttendees { get; set; }
    }
}