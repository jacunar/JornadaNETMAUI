using System.Net.NetworkInformation;

namespace AttendeesAPI.Routes {
    public static class AttendeesRoutes {
        const string ENDPOINT = "/attendees";

        public static IEndpointRouteBuilder AddAttendeesRoutes(this IEndpointRouteBuilder app) {
            app.MapGet(ENDPOINT, GetAttendees).WithTags(ENDPOINT);
            app.MapGet(ENDPOINT + "/{id}", GetAttendeesById).WithTags(ENDPOINT);
            app.MapPost(ENDPOINT, PostAttendee).WithTags(ENDPOINT);
            app.MapPut(ENDPOINT + "/{id}", PutAttendee).WithTags(ENDPOINT);
            app.MapDelete(ENDPOINT + "/{id}", DeleteAttendee).WithTags(ENDPOINT);

            return app;

             
        }
    }
}