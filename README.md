# DisneyAPI

Web API para gestionar películas y personajes de Disney con operaciones CRUD, autenticación con JWT, autorización con filtros y middleware, subida de imágenes y persistencia en BBDD. 

**Tecnologías usadas:**

- .NET 6
- ASP.NET Web API
- EntityFramework Core 6
- SQL Server
- Swagger

**Pre-requisitos:**
- Visual Studio 2022
- LocalDB:
    Si no esta instalado ejecutar Visual Studio Installer, ir a Modify -> Individual Components, buscarlo en la lupa e instalarlo.

**Setup inicial:**

Una vez abierto el .sln en Visual Studio, abrir la Package Manager Console (PM>) y ejecutar los siguientes comandos en este orden:

PM> add-migration Initial \
PM> update-database

Luego de eso ya podemos iniciar y probar nuestro proyecto.

En esta ocasion vamos a utilizar Postman para probar requests con bearer authentication. En la carpeta Postman de este repositorio se encuentran algunos ejemplos.

**Subir imágenes:**

Debemos colocar en Authorization el bearer token. En Body seleccionar form-data, en key cambiar Text por File y cargar la imagen en value.

![image](https://user-images.githubusercontent.com/38809423/182511766-d95a4ca8-b516-40ba-af60-b674fd30ed38.png)

