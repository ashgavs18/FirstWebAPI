using FirstWebApi.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WebApiClientConsole
{
    internal class EmployeeApiClient
    {
        static Uri uri = new Uri("http://localhost:5137/");
        public static async Task CallGetAllEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string x = await response.Content.ReadAsStringAsync();
                    await Console.Out.WriteLineAsync(x);
                }
            }



        }
        public static async Task GetAllListlEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employees = new List<EmpViewModel>();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("GetAllEmployees");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {



                    string json = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);
                    foreach (EmpViewModel emp in employees)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName},{emp.LastName},{emp.Title},{emp.City},{emp.ReportsTo}");
                    }

                }
            }





        }
        public static async Task AddNewEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel employee = new EmpViewModel()
                {
                    FirstName = "WILLAIAM",
                    LastName = "john",
                    City = "india",
                    BirthDate = new DateTime(1980, 01, 01),
                    HireDate = new DateTime(2000, 01, 01),
                    Title = "Manager"
                };
                var mycontent = JsonConvert.SerializeObject(employee);
                var buffer = Encoding.UTF8.GetBytes(mycontent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await client.PostAsync("AddNewEmployeesw", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());


                }
            }



        }
        public static async Task UpdateEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                EmpViewModel emp = new EmpViewModel();
                emp.EmpId = 7;
                emp.FirstName = "Reena";
                emp.LastName = "Ross";
                emp.City = "Uk";
                emp.BirthDate = new DateTime(1992, 01, 01);
                emp.HireDate = new DateTime(2018, 04, 01);
                emp.Title = "Manager";





                var myContent = JsonConvert.SerializeObject(emp);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //httpPUT
                HttpResponseMessage response = await client.PutAsync("EditEmployee", byteContent);
                response.EnsureSuccessStatusCode();





            }
        }
        public static async Task DeleteEmployee(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //httpdelete
                HttpResponseMessage response = await client.DeleteAsync($"DeleteEmployee?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Error deleting employee. Status code: {response.StatusCode}");
                }
            }





        }
    }
}