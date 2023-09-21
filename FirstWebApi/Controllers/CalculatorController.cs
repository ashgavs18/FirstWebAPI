using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // api/Calculator/Add?x=5&y=2
        [HttpGet("Calculator/Add")]
        public int Add(int x,int y)
        { 
            return x+y; 
        }
        [HttpGet("Calculator/Sum")]
        public int Sum(int x, int y)
        {
            return x + y + 1000;
        }
        // api/Calculator/Sub?x=5&y=2
        [HttpPost]
        public int Sub(int x, int y)
        {
            return x - y;
        }
        // api/Calculator/Mul?x=2&y=5
        [HttpPut]
        public int Mul(int x, int y)
        {
            return x * y;
        }
        // api/Calculator/Div?x=10&y=5
        [HttpDelete]
        public int Div(int x, int y)
        {
            return x / y;
        }
    }
}
