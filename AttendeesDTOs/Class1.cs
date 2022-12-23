namespace AttendeesDTOs {
    public record NewAttendeeDTO(string Name, DateTime AttendanceDate, string Location, string PhotoUrl);

    public record NewSessionDTO(string Name);

    public record NewSessionAttendeeDTO(int SessionId, int AttendeeId);


    public record AttendeeDTO(int Id, String Name, DateTime AttendanceDate, string Location, string PhotoUrl);

    public record SessionDTO(int Id, string Name);

    public record SessionAttendeeDTO(int Id, int SessionId, int AttendeeId);
}