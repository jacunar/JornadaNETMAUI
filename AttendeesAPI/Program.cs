using AttendeesAPI.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AttendeesContext>(builder.Configuration.GetConnectionString("AttendeesDb"));
builder.Services.AddSqlServer<IdentityContext>(builder.Configuration.GetConnectionString("IdentityDb"));
builder.Services.AddScoped<AttendeesRepository>();
builder.Services.AddScoped<SessionAttendeeRepository>();
builder.Services.AddScoped<SessionRepository>();

builder.Services.AddIdentityCore<ApplicationUser>(
    options => {
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    }).AddEntityFrameworkStores<IdentityContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddAttendeesRoutes();
app.AddSessionAttendeeRoutes();
app.AddSessionsRoutes();

app.UseHttpsRedirection();

app.Run();