using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);
// Register DbContext with MySQL using connection string from configuration
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ToDoDB"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ToDoDB"))
    ));

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Version = "v1" });
});

// Enable permissive CORS for client access
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1");
});

app.UseCors();

// Basic health endpoint
app.MapGet("/", () => "Todo API running");

// CRUD endpoints for Items (scaffolded entity: NewTable)
app.MapGet("/api/items", async (ToDoDbContext db) =>
    await db.NewTables.AsNoTracking().ToListAsync());

app.MapGet("/api/items/{id:int}", async (int id, ToDoDbContext db) =>
    await db.NewTables.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)
        is { } item ? Results.Ok(item) : Results.NotFound());

app.MapPost("/api/items", async (NewTable item, ToDoDbContext db) =>
{
    db.NewTables.Add(item);
    await db.SaveChangesAsync();
    return Results.Created($"/api/items/{item.Id}", item);
});

app.MapPut("/api/items/{id:int}", async (int id, NewTable input, ToDoDbContext db) =>
{
    var entity = await db.NewTables.FindAsync(id);
    if (entity is null)
        return Results.NotFound();

    entity.Name = input.Name;
    entity.IsComplete = input.IsComplete;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/items/{id:int}", async (int id, ToDoDbContext db) =>
{
    var entity = await db.NewTables.FindAsync(id);
    if (entity is null)
        return Results.NotFound();
    db.NewTables.Remove(entity);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
