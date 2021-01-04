# Crea_DiegoA.Core
Prueba técnica para Crea Sistemas
#### Lenguaje de programación .Net Framework 4.7.2 c#.
### Configuración
* Ejecutar el script **1. Create Database.sql** en la carpeta **SQL** en motor de datos **SQL Server**, Version 2012+. 
* Ejecutar el script **2. Objects and initial Data.sql** en la carpeta **SQL** en motor de datos **SQL Server**, Version 2012+.
* Abrir en **Visual Studio 2019**. 
* Cambiar la cadena de conexión en el archivo **Web.config** del proyecto **Crea_DiegoA.Api**, y en la cadena llamada **Connection_Crea_Test_DA** cambiar el nombre de la base de datos creada anteriormente, junto con el usuario y contraseña.
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

* En el api de cambio de estado de la venta, https://localhost:44358/api/sale/changeState/{id}/{state} : **GET**, se debe tener en cuenta que los códigos de los estados son los siguientes:

** 1: Acceptada
** 2: Confirmada
** 3: Anulada
** 4: Rechazada

Si se envia un código que no se encuentre en la lista, el api enviara un mensaje notificando que el estado no exite.
