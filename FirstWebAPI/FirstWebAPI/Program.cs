//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using FirstWebAPI;
using FirstWebAPI.Services;
using System.Reflection;

//Type analyzerType = typeof(DocumentAnalyzer);

//Console.WriteLine($"Class name: {analyzerType.Name}"); 

//PropertyInfo[] properties = analyzerType.GetProperties();

//foreach(PropertyInfo prop in properties)
//{
//    Console.WriteLine($"Property name: {prop.Name}, Type: {prop.PropertyType}");
//}

//Console.WriteLine();

//MethodInfo[] methods = analyzerType.GetMethods();

//foreach(MethodInfo method in methods)
//{
//    Console.WriteLine($"Method name: {method.Name}, Return type: {method.ReturnType}");
//}

//Type targetType = typeof(DocumentAnalyzer);

//Object? dynamicInstance = Activator.CreateInstance(targetType);

//Console.WriteLine($"Created an instance of: {dynamicInstance?.GetType().Name}");

//Console.WriteLine();

//PropertyInfo? prop = targetType.GetProperty("modelName");
//prop?.SetValue(dynamicInstance, "UNet-Extractor");


//MethodInfo? method = targetType.GetMethod("LogInternalMetrics");
//object[] parameters = new [] { "/docs/satellite_image_01.png" };          

//method?.Invoke(dynamicInstance, parameters);

var container = new DIContainer();

container.RegisterTransient<IEmbeddingService, EmbeddingService>();
container.RegisterTransient <IDocumentService, DocumentService>();

var myDocService = container.Resolve<IDocumentService>();

myDocService.Process("/docs/satellite_image_01.png");
