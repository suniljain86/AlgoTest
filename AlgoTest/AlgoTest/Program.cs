using AlgoTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ISortingService, SortingService>();

var app = builder.Build();
var fileService = app.Services.GetRequiredService<IFileService>();
var sortingService = app.Services.GetRequiredService<ISortingService>();

var inputFileName = "PhoneNumbers-8-digits.csv";
var outputFileName = "PhoneNumbers-8-digits_Output.csv";

var phoneNumbers = fileService.ReadPhoneNumbers(inputFileName);
sortingService.Sort(phoneNumbers, 0, phoneNumbers.Length - 1);
fileService.WritePhoneNumbers(phoneNumbers, outputFileName);

app.Run();