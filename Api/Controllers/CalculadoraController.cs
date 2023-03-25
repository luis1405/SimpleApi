using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CalculadoraController : Controller
    {
        [HttpGet("{valor1}{valor2}{valor3}")]
        public int GetSuma(int valor1, int valor2, int valor3)
        {
            return Sumar(valor1, valor2, valor3);
        }
        [HttpPost("{valor1}{valor2}{valor3}")]
        public int PostSuma(int valor1, int valor2, int valor3)
        {
            return Sumar(valor1, valor2, valor3);
        }
        private static int Sumar(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
