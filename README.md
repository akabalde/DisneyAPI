# DisneyAPI

Pre-requisitos:
- Visual Studio 2022
- LocalDB:
    Ejecutar Visual Studio Installer, buscarlo en la lupa e instalarlo si no esta instalado.

Setup inicial:

Una vez abierto el .sln en Visual Studio, abrir la consola de Nuget Package Manager (PM>) y ejecutar los siguientes comandos:

PM> add-migration Initial -Context DisneyAPIContext
PM> update-database -Context DisneyAPIContext

PM> add-migration Initial -Context ApplicationDbContext
PM> update-database -Context ApplicationDbContext

Luego de eso ya podemos iniciar nuestro proyecto.
