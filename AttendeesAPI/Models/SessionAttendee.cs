using System;
using System.Collections.Generic;

namespace AttendeesAPI.Models {
    public partial class SessionAttendee {
        public int SessionAttendeesId { get; set; }
        public int AttendeeId { get; set; }
        public int SessionId { get; set; }

        public virtual Attendee Attendee { get; set; } = null!;
        public virtual Session Session { get; set; } = null!;
    }
}