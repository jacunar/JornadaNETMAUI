using System.Net.NetworkInformation;
using AttendeesAPI.Extensions;

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
                => Results.Ok((await repository.GetAllAsync()).ToAttendeesDTO());

            async Task<IResult> GetAttendeeById(AttendeesRepository repository, int id) {
                Attendee? attendee = await repository.GetAsync(id);
                return attendee is null ? Results.NotFound() : Results.Ok(attendee.ToAttendeeDTO());
            }

            async Task<IResult> PostAttendee(AttendeesRepository repository, NewAttendeeDTO newAttendee) {
                var attendee = await repository.PostAsync(newAttendee.ToAttendee());
                await repository.SaveChangesAsync();
                return Results.Ok(attendee.ToAttendeeDTO());
            }
        
            async Task<IResult> PutAttendee(AttendeesRepository repository, int id, NewAttendeeDTO newAttendeeDTO) {
                var existingAttendee = await repository.GetAsync(id);
                if (existingAttendee is not null) {
                    existingAttendee.AttendanceDate = newAttendeeDTO.AttendanceDate;
                    existingAttendee.Location = newAttendeeDTO.Location;
                    existingAttendee.Name = newAttendeeDTO.Name;
                    existingAttendee.PhotoUrl = newAttendeeDTO.PhotoUrl;

                    await repository.PutAsync(existingAttendee);
                    await repository.SaveChangesAsync();
                    return Results.Ok();
                } else
                    return Results.NotFound();
            }

            async Task<IResult> DeleteAttendee(AttendeesRepository repository, int id) {
                var existingAttendee = await repository.GetAsync(id);
                if(existingAttendee is not null) {
                    await repository.DeleteAsync(id);
                    await repository.SaveChangesAsync();
                    return Results.Ok();
                }
                return Results.NotFound();
            }
        }
    }
}