using BibleUtil;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

var app = builder.Build();

// TODO: Disable this for dev
// if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
app.UseStatusCodePages();

app.MapGet("/", () => "Hello World!");

app.MapGet("/bible/{reference}", Results<NotFound<string>, Ok<string>> (string reference) =>
{
    try
    {
        var r = BibleUtil.Reference.Parse(reference);
        return TypedResults.Ok(r.ToString());
    }
    catch
    {
        return TypedResults.NotFound("The reference is not valid");
    }        
});

app.Run();
