using Castle.Core.Logging;
using Einstein_Game.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Einstein_Game_Tests.Pruebas
{
    [TestClass]
    public class EinsteinControllerTests
    {
        [TestMethod]
        public async Task IncioJuegoDevuelveOk()
        {
            var mockIwebHostEnviroment = new Mock<IWebHostEnvironment>();
            var mockIlogger = new Mock<ILogger<EinsteinController>>();

            //PARA PASAR ESTA PRUEBA ES NECESARIO CONFIGURAR EL RETORNO DE WEBROOTPATH CON LA RUTA REAL DEL EQUIPO
            mockIwebHostEnviroment.Setup(env => env.WebRootPath).Returns("C:\\Users\\juang\\Desktop\\Desarrollo\\NET\\repos\\Proyectos\\Business_Insights\\Einstein_Game\\Einstein_Game\\wwwroot");

            var controller = new EinsteinController(mockIwebHostEnviroment.Object, mockIlogger.Object);

            var resultado = await controller.InicioJuego(13);

            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));
        }
    }
}