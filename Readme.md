## Einstein Game


# FrontEnd

- Restaurar node_modules con npm install
- Levantar aplicacion con ng serve -o
- Paquetes utilizados: Bootstrap


# BackEnd

- Implementado sistema de Log con nLog. Configurado para consola (nivel Debug) y archivo (nivel Debug, y nivel Warning), rutas respectivas : c:\temp\nLog\all.log y c:\temp\nLog\relevant.log
- Ruta informes diarios con la cadena resultante del juego:  wwwroot/Informes
- En el proyecto de pruebas unitarias, en el método InicioJuegoDevuelveOk es necesario  CONFIGURAR EL RETORNO DE WEBROOTPATH CON LA RUTA REAL DEL EQUIPO, en mi caso:
  mockIwebHostEnviroment.Setup(env => env.WebRootPath).Returns("C:\\Users\\juang\\Desktop\\Desarrollo\\NET\\repos\\Proyectos\\Business_Insights\\Einstein_Game\\Einstein_Game\\wwwroot");
- Paquetes utilizados: nLog y Moq en el proyecto de pruebas