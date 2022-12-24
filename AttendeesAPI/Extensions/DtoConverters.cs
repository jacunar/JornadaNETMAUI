using System.Net.NetworkInformation;
using System.Security.Policy;

namespace AttendeesAPI.Extensions {
    public static class DtoConverters {
        public static AttendeeDTO ToAttendeeDTO(this Attendee attendee)
            => new(attendee.AttendeeId, attendee.Name, attendee.AttendanceDate, attendee.Location, attendee.PhotoUrl);

        public static IEnumerable<AttendeeDTO> ToAttendeesDTO(this IEnumerable<Attendee> attendees)
            => attendees.Select(attendee => attendee.ToAttendeeDTO());

        public static Attendee ToAttendee(this NewAttendeeDTO newAttendeeDTO)
            => new() {
                Name = newAttendeeDTO.Name,
                AttendanceDate = newAttendeeDTO.AttendanceDate,
                Location = newAttendeeDTO.Location,
                PhotoUrl = newAttendeeDTO.PhotoUrl
            };

        public static Attendee ToAttendee(this AttendeeDTO attendeeDTO)
            => new() {
                AttendeeId = attendeeDTO.Id,
                Name = attendeeDTO.Name,
                AttendanceDate = attendeeDTO.AttendanceDate,
                Location = attendeeDTO.Location,
                PhotoUrl = attendeeDTO.PhotoUrl
            };

        public static SessionDTO ToSessionDTO(this Session attendee)
            => new(attendee.SessionId, attendee.Name);

        public static Session ToSession(this NewSessionDTO sessionDTO)
            => new() {
                Name = sessionDTO.Name
            };

        public static Session ToSession(this Session session)
            => new() {
                SessionId = session.SessionId,
                Name = session.Name
            };

        public static IEnumerable<SessionDTO> ToSessionsDTO(this IEnumerable<Session> sessions)
            => sessions.Select(session => session.ToSessionDTO());

        public static SessionAttendeeDTO ToSessionAttendeeDTO(this SessionAttendee sessionAttendee)
            => new(sessionAttendee.SessionAttendeesId,
                sessionAttendee.SessionId,
                sessionAttendee.AttendeeId);

        public static SessionAttendee ToSessionAttende(this NewSessionAttendeeDTO sessionAttendeeDTO)
            => new() {
                SessionId = sessionAttendeeDTO.SessionId,
                AttendeeId = sessionAttendeeDTO.AttendeeId
            };

        public static SessionAttendee ToSessionAttendee(this SessionAttendee sessionAttendee)
            => new() {
                SessionAttendeesId = sessionAttendee.SessionAttendeesId,
                SessionId = sessionAttendee.SessionId,
                AttendeeId = sessionAttendee.AttendeeId
            };

        public static IEnumerable<SessionAttendeeDTO> ToSessionsAttendees(this IEnumerable<SessionAttendee> sessionAttendees)
            => sessionAttendees.Select(sessionAttendee => sessionAttendee.ToSessionAttendeeDTO());
    }
}
