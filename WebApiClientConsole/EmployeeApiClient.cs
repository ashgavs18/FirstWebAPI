using FirstWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClientConsole
{
    internal class EmployeeApiClient
    {
        static Uri uri = new Uri("http://localhost:5000/");
        public static async Task CallGetAllEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<Employee> employees = new List<Employee>();
                client.DefaultRequestHeaders
                    .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                    foreach (Employee emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmployeeId},{emp.FirstName},{emp.LastName},{emp.Title},{emp.City}");
                    }
                }
            }

        }
    }
}
