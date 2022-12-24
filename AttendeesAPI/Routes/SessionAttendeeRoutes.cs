using System.Drawing.Text;

namespace AttendeesAPI.Routes {
    public static class SessionAttendeeRoutes {
        const string ENDPOINT = "/sessionattendee";

        public static IEndpointRouteBuilder AddSessionAttendeeRoutes(this IEndpointRouteBuilder app) {
            app.MapGet(ENDPOINT + "/session/{id}", GetSessionAttendeeBySessionId).WithTags(ENDPOINT);
            app.MapGet(ENDPOINT + "/attendee/{id}", GetSessionAttendeeByAttendeeId).WithTags(ENDPOINT);
            app.MapPost(ENDPOINT, PostSessionAttendee).WithTags(ENDPOINT);
            app.MapDelete(ENDPOINT + "/{id}", DeleteSessionAttendee).WithTags(ENDPOINT);
            return app;

            async Task<IResult> GetSessionAttendeeBySessionId(SessionAttendeeRepository repository, int id) {
                IEnumerable<SessionAttendee> sessionAttendees =
                    (await repository.GetAllAsync()).Where(sa => sa.SessionId == id);

                if (sessionAttendees is not null)
                    return Results.Ok(sessionAttendees.ToSessionsAttendees());
                else
                    return Results.NotFound();
            }

            async Task<IResult> GetSessionAttendeeByAttendeeId(SessionAttendeeRepository repository, int id) {
                IEnumerable<SessionAttendee> sessionAttendees =
                    (await repository.GetAllAsync()).Where(sa => sa.AttendeeId == id);

                if (sessionAttendees is not null)
                    return Results.Ok(sessionAttendees.ToSessionsAttendees());
                else
                    return Results.NotFound();
            }

            async Task<IResult> PostSessionAttendee(SessionAttendeeRepository repository, NewSessionAttendeeDTO newSessionAttendeeDTO) {
                var sessionAttendee = await repository.PostAsync(newSessionAttendeeDTO.ToSessionAttende());
                if (sessionAttendee is not null) {
                    await repository.SaveChangesAsync();
                    return Results.Ok(sessionAttendee.ToSessionAttendeeDTO());
                }
                return Results.NotFound();
            }

            async Task<IResult> DeleteSessionAttendee(SessionAttendeeRepository repository, int id) {
                var existingSessionAttendee = await repository.GetAsync(id);
                if (existingSessionAttendee is not null) {
                    await repository.DeleteAsync(id);
                    await repository.SaveChangesAsync();
                    return Results.Ok();
                } else
                    return Results.NotFound();
            }
        }
    }
}