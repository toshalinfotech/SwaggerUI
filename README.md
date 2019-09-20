Add below package references
Swashbuckle.AspNetCore 4.0.1
Swashbuckle.AspNetCore.Annotations 4.0.1
Swashbuckle.AspNetCore.ReDoc 4.0.1

Add below code in ConfigureServices of startup.cs
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
    {
        Version = "v1",
        Title = "My Swagger Demo",
        Description = "My Swagger Demo"
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "swagger_demo.xml");
    if (File.Exists(filePath))
    {
        c.IncludeXmlComments(filePath);
    }
});

services.ConfigureSwaggerGen(x =>
{
    x.EnableAnnotations();
});

Add below code in Configure of startup.cs
app.UseSwagger();
app.UseReDoc(c =>
{
    c.SpecUrl = "/swagger/v1/swagger.json";
    c.DocumentTitle = "My Swagger Demo - v1";
    c.RoutePrefix = string.Empty;
    c.ConfigObject = new Swashbuckle.AspNetCore.ReDoc.ConfigObject
    {
        LazyRendering = true,
        NoAutoAuth = true,
    };
});

Run the project.
You can see all the APIs are listed with controller names in swagger ui.

Note: You can define different Annotations to your API parameters.