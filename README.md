# Crea_DiegoA.Core
Prueba técnica para Crea Sistemas
#### Lenguaje de programación .Net Framework 4.7.2 c#.
### Configuración
* Ejecutar el script **1. Create Database.sql** en la carpeta **SQL** en motor de datos **SQL Server**, Version 2012+. 
* Ejecutar el script **2. Objects and initial Data.sql** en la carpeta **SQL** en motor de datos **SQL Server**, Version 2012+.
* Abrir en **Visual Studio 2019**. 
* Cambiar la cadena de conexión en el archivo **Web.config** del proyecto **Crea_DiegoA.Api**, por la conexión a la base de datos creada anteriormente.
* Establecer el proyecto de inicio **Crea_DiegoA.Api**.
### Endpoints
En la carpeta de **POSTMAN**, se adjunta la colección y el entorno para ejecución y prueas de los apis, un ejemplo del consumo de los apis es el siguiente:
* https://localhost:44358/api/customer/create: **POST**, Crea un cliente. Utiliza el siguiente objecto json para su consumo:
   {
    "FirtsName": "Juanito",
    "LastName": "Jimenez",
    "Document": "909090",
    "Phone": "4330090",
    "Email": "juanito@correo.com"
  }
