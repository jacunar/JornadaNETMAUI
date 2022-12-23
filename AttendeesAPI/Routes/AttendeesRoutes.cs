using System.Net.NetworkInformation;

namespace AttendeesAPI.Routes {
    public static class AttendeesRoutes {
        const string ENDPOINT = "/attendees";

        public static IEndpointRouteBuilder AddAttendeesRoutes(this IEndpointRouteBuilder app) {
            app.MapGet(ENDPOINT, GetAttendees).WithTags(ENDPOINT);
            app.MapGet(ENDPOINT + "/{id}", GetAttendeeById).WithTags(ENDPOINT);
            app.MapPost(ENDPOINT, PostAttendee).WithTags(ENDPOINT);
            app.MapPut(ENDPOINT + "/{id}", PutAttendee).WithTags(ENDPOINT);
            app.MapDelete(ENDPOINT + "/{id}", DeleteAttendee).WithTags(ENDPOINT);

            return app;

            async Task<IResult> GetAttendees(AttendeesRepository repository)
                => Results.Ok(await repository.GetAllAsync());

            async Task<IResult> GetAttendeeById(AttendeesRepository repository, int id) {
                Attendee? attendee = await repository.GetAsync(id);
                return attendee is null ? Results.NotFound() : Results.Ok(attendee);
            }

            async Task<IResult> PostAttendee(AttendeesRepository repository, Attendee newAttendee) {
                var attendee = await repository.PostAsync(newAttendee);
                return Results.Ok(attendee);
            }
        }

    }
}