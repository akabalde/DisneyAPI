# DisneyAPI

Pre-requisitos:
- Visual Studio 2022
- LocalDB:
    Si no esta instalado ejecutar Visual Studio Installer, ir a Modify -> Individual Components, buscarlo en la lupa e instalarlo.

Setup inicial:

Una vez abierto el .sln en Visual Studio, abrir la Package Manager Console (PM>) y ejecutar los siguientes comandos en este orden:

PM> add-migration Initial \
PM> update-database

Luego de eso ya podemos iniciar y probar nuestro proyecto.

Se recomienda utilizar Postman para probar request con bearer authentication. En la carpeta Postman de este repositorio se encuentran algunos ejemplos.

Subir imagenes:

Debemos colocar en Authorization el bearer token. En Body seleccionar form-data, en key cambiar Text por File y cargar la imagen en value.

![image](https://user-images.githubusercontent.com/38809423/182511766-d95a4ca8-b516-40ba-af60-b674fd30ed38.png)

