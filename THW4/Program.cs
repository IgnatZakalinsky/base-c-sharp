using Microsoft.Extensions.FileProviders;
using System.Text.Json;
using System.Text.Json.Serialization;

// using Classes;
// global using Classes; // for all files

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
// ||
// app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));
// ||
/*
app.Run(async (context) =>
{
    // // +- // context.Response.StatusCode = 404;
    // var response = context.Response;
    // response.Headers.ContentLanguage = "ru-RU";
    // response.Headers.ContentType = "text/plain; charset=utf-8";
    // response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
    // await response.WriteAsync("ѕривет METANIT.COM");
    // ||
    // response.ContentType = "text/html; charset=utf-8";
    // await response.WriteAsync("<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET Core</h3>");
    // ||

    /* context.Response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<table>");

    foreach (var header in context.Request.Headers)
    {
        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    }
    stringBuilder.Append("</table>");

    stringBuilder.Append($"Path: {context.Request.Path}");
    var now = DateTime.Now;
    stringBuilder.Append($"Date: {now.ToShortDateString()}");
    stringBuilder.Append($"Time: {now.ToShortTimeString()}");

    stringBuilder.Append($"<p>QueryString: {context.Request.QueryString}</p>");
    stringBuilder.Append("<tr><td>ѕараметр</td><td>«начение</td></tr>");
    foreach (var param in context.Request.Query)
    {
        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
    }
    stringBuilder.Append("</table>");

    await context.Response.WriteAsync(stringBuilder.ToString());
    */
// ||
// await context.Response.SendFileAsync("D:\\world-tree\\i1-work\\programming\\dotnet\\THW4\\THW4\\x4.png");
// ||
// await context.Response.SendFileAsync("x4.png");

// ||
// context.Response.ContentType = "text/html; charset=utf-8";
// await context.Response.SendFileAsync("html/index.html");
// ||
/* var response = context.Response;
var path = context.Request.Path;
var fullPath = $"html/{path}";
response.ContentType = "text/html; charset=utf-8";
if (File.Exists(fullPath))
{
    await response.SendFileAsync(fullPath);
}
else
{
    response.StatusCode = 404;
    await response.WriteAsync("<h2>Not Found</h2>");
} */

/*
// save to download
context.Response.Headers.ContentDisposition = "attachment; filename=my_forest2.jpg";

var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
var fileinfo = fileProvider.GetFileInfo("forest.jpg");
await context.Response.SendFileAsync(fileinfo);
// ||    
// await context.Response.SendFileAsync("forest.jpg");
*/
/*
});
*/

app.Run(HandleRequst2);



async Task HandleRequst2(HttpContext context)
{
    /*if (context.Request.Path == "/new")
    {
        await context.Response.WriteAsync("New Page");
    }
    else
    {
        context.Response.Redirect("/new");
    }*/


    var response = context.Response;
    var request = context.Request;
    if (request.HasJsonContentType())
    {
        var responseText = "Ќекорректные данные";   // содержание сообщени€ по умолчанию

        // определ€ем параметры сериализации/десериализации
        var jsonoptions = new JsonSerializerOptions();
        // добавл€ем конвертер кода json в объект типа Person
        jsonoptions.Converters.Add(new PersonConverter());
        // десериализуем данные с помощью конвертера PersonConverter
        var person = await request.ReadFromJsonAsync<Person>(jsonoptions);
        // ||
        // var person = await request.ReadFromJsonAsync<Person>();

        if (person != null)
        {
            responseText = $"Name: {person.Name}  Age: {person.Age}";
            await response.WriteAsJsonAsync(new { text = responseText });
            return;
        }
    }

    // Person tom = new("Tom", 22);
    // await context.Response.WriteAsJsonAsync(tom);
    // || 
    response.Headers.ContentType = "application/json; charset=utf-8";
    await response.WriteAsync("{'name':'Tom', 'age':37}");

}

async Task HandleRequst(HttpContext context)
{
    // Classes.B5Classes.Person x = new Classes.B5Classes.Person();

    context.Response.ContentType = "text/html; charset=utf-8";

    // если обращение идет по адресу "/postuser", получаем данные формы
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];

        string[] languages = form["languages"];
        // создаем из массива languages одну строку
        string langList = "";
        foreach (var lang in languages)
        {
            langList += $"<li>{lang}</li>";
        }

        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>" +
            $"<div>Languages:<ul>{langList}</ul></div>");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
}

app.Run();
// ||
// await app.StartAsync();
// await Task.Delay(10000);
// await app.StopAsync();  // через 10 секунд завершаем выполнение приложени€

public record Person(string Name, int Age);
public class PersonConverter : JsonConverter<Person>
{
    public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var personName = "Undefined";
        var personAge = 0;
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    // если свойство Age/age и оно содержит число
                    case "age" or "Age" when reader.TokenType == JsonTokenType.Number:
                        personAge = reader.GetInt32();  // считываем число из json
                        break;
                    // если свойство Age/age и оно содержит строку
                    case "age" or "Age" when reader.TokenType == JsonTokenType.String:
                        string? stringValue = reader.GetString();
                        // пытаемс€ конвертировать строку в число
                        if (int.TryParse(stringValue, out int value))
                        {
                            personAge = value;
                        }
                        break;
                    case "Name" or "name":  // если свойство Name/name
                        string? name = reader.GetString();
                        if (name != null)
                            personName = name;
                        break;
                }
            }
        }
        return new Person(personName, personAge);
    }
    // сериализуем объект Person в json
    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name", person.Name);
        writer.WriteNumber("age", person.Age);

        writer.WriteEndObject();
    }
}
