# DisneyAPI

Pre-requisitos:
- Visual Studio 2022
- LocalDB:
    Si no esta instalado ejecutar Visual Studio Installer, ir a Modify -> Individual Components, buscarlo en la lupa e instalarlo.

Setup inicial:

Una vez abierto el .sln en Visual Studio, abrir la Package Manager Console (PM>) y ejecutar los siguientes comandos en este orden:

PM> add-migration Initial -Context DisneyAPIContext \
PM> update-database -Context DisneyAPIContext

Luego de eso ya podemos iniciar y probar nuestro proyecto.

Se recomienda utilizar Postman para probar request con bearer authentication. En la carpeta Postman de este repositorio se encuentran algunos ejemplos.
