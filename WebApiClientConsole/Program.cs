// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;
Console.WriteLine("API CLIENT!");
EmployeeApiClient.CallGetAllEmployee().Wait();
Console.WriteLine();