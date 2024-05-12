using Microsoft.AspNetCore.Mvc;

namespace Einstein_Game.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EinsteinController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<EinsteinController> _logger;
        private string cadena = "";

        public EinsteinController(IWebHostEnvironment env, ILogger<EinsteinController> logger)
        {
            _env = env;
            _logger = logger;
        }

        [HttpGet("inicio/{numero}")]
        public async Task<ActionResult> InicioJuego(int numero)
        {
            _logger.LogWarning(DateTime.Now.ToString() + "_MétodoInicioJuego, param: " + numero.ToString());

            if (ModelState.IsValid)
            {
                try
                {
                    string res = "";

                    if (numero % 3 == 0)
                    {
                        res = "fizz";
                    }
                    if (numero % 5 == 0)
                    {
                        res = "buzz";
                    }
                    if (numero % 3 == 0 && numero % 5 == 0)
                    {
                        res = "fizzBuzz";
                    }
                    if (numero % 3 != 0 && numero % 5 != 0)
                    {
                        res = numero.ToString();
                    }

                    cadena += res + ", ";

                    var fecha = DateTime.Now.ToShortDateString();
                    fecha = fecha.Replace("/", "-");
                    
                    string archivo = $"Informe_{fecha}.txt";
                    string texto = $"\nEinstein Game\nFecha: {fecha}\n\n{cadena}";


                    var folder = System.IO.Path.Combine(_env.WebRootPath, "Informes");

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    string ruta = System.IO.Path.Combine(folder, archivo);

                    if (System.IO.File.Exists(ruta))
                    {
                        await System.IO.File.AppendAllTextAsync(ruta, cadena);
                    }
                    else
                    {
                        await System.IO.File.WriteAllTextAsync(ruta, texto);
                    }



                    return Ok(new { numero, res });
                }
                catch (Exception ex)
                {
                    _logger.LogError(DateTime.Now.ToString(), ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return BadRequest(new { message = "Eso no es un número válido.."});
            }
        }
    }
}
