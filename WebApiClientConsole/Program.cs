// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;
Console.WriteLine("API CLIENT!");
//EmployeeApiClient.GetAllListlEmployee().Wait();
//Console.ReadLine();
EmployeeApiClient.AddNewEmployee().Wait();
Console.ReadLine();