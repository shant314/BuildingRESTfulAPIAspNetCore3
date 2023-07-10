using BuildingRESTfulAPIAspNetCore3.Infrastructure;
using BuildingRESTfulAPIAspNetCore3.Infrastructure.Abstractions;
using BuildingRESTfulAPIAspNetCore3.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//AddDbContextPool, reuse the db context for better performance.
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}

//add authorization capabilities to the request pipeline, it must be configured in the DI.
app.UseAuthorization();

app.MapControllers();// api controller attribute routes

app.Run();


/*
 The project debug setting is set to use port 51044.
 */

/*
REST is an architectural style, evoking an image on how a well-designed web application should behave.

Rest constraints,
    Uniform interface constraint.
        API and consumers share one single, technical interface: URI, Method, Media Type (payload).
        Identification of resources.
        Manipulation of resources through representation.
        Self-descriptive message.
        Hypermedia as the engine of the application state(HATEOAS): self documented API.
    Client-Server.
        client and server are separated (client and server can evolve separately).
    Statelessness
        state is contained within the request: state is kept on the client only.
    Layered System
        client cannot tell what layer it's connected to.
    Cacheable
        each response message must explicitly state if it can be cached or not.
    Code on demand(optional)
        server can extend client functionality.


In this project we are using the Layered Architecture
This is a RESTFul API, we skip creating a service layer, the repository will be accessed directly form the controller.

 */