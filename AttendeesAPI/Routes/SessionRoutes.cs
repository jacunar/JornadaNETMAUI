namespace AttendeesAPI.Routes {
    public static class SessionRoutes {
        const string ENDPOINT = "/sessions";

        public static IEndpointRouteBuilder AddSessionsRoutes(this IEndpointRouteBuilder app) {
            app.MapGet(ENDPOINT, GetSessions).WithTags(ENDPOINT);
            app.MapGet(ENDPOINT + "/{id}", GetAttendeeById).WithTags(ENDPOINT);
            app.MapPost(ENDPOINT, PostAttendee).WithTags(ENDPOINT);
            app.MapPut(ENDPOINT + "/{id}", PutAttendee).WithTags(ENDPOINT);
            app.MapDelete(ENDPOINT + "/{id}", DeleteAttendee).WithTags(ENDPOINT);
            return app;

            async Task<IResult> GetSessions(SessionRepository repository)
                => Results.Ok((await repository.GetAllAsync()).ToSessionsDTO());

            async Task<IResult> GetAttendeeById(SessionRepository repository, int id) {
                Session? session = await repository.GetAsync(id);
                return session is null ? Results.NotFound() : Results.Ok(session.ToSessionDTO());
            }

            async Task<IResult> PostAttendee(SessionRepository repository, NewSessionDTO newSessionDTO) {
                var session = await repository.PostAsync(newSessionDTO.ToSession());
                await repository.SaveChangesAsync();
                return Results.Ok(session.ToSessionDTO());
            }

            async Task<IResult> PutAttendee(SessionRepository repository, int id, NewSessionDTO newSessionDTO) {
                var existingSession = await repository.GetAsync(id);
                if (existingSession is not null) {
                    existingSession.Name = newSessionDTO.Name;

                    await repository.PutAsync(existingSession);
                    await repository.SaveChangesAsync();
                    return Results.Ok();
                } else
                    return Results.NotFound();
            }

            async Task<IResult> DeleteAttendee(SessionRepository repository, int id) {
                var existingAttendee = await repository.GetAsync(id);
                if (existingAttendee is not null) {
                    await repository.DeleteAsync(id);
                    await repository.SaveChangesAsync();
                    return Results.Ok();
                }
                return Results.NotFound();
            }
        }
    }
}
