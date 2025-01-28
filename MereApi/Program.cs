var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/bible/{book}", (string reference) =>
{
    var r = BibleUtil.Reference.Parse(reference);

    return r.ToString();
});

app.Run();
