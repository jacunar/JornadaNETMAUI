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
    }
}
