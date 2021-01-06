# Crea_DiegoA.Core
Technical test for "Crea Sistemas"
#### Programming language .Net Framework 4.7.2 c#.
### configuration
* execute the script **1. Create Database.sql** in the folder **SQL** in the data engine **SQL Server**, version 2012+. 
* execute the script **2. Objects and initial Data.sql** in the folder **SQL** in the data engine **SQL Server**, version 2012+.
* Open in **Visual Studio 2019**. 
* change connection string in file **Web.config** in the project **Crea_DiegoA.Api**, in the key **Connection_Crea_Test_DA** rename the database,user and password.
* set startup project **Crea_DiegoA.Api**.
### Endpoints
in the folder **POSTMAN**, the collection and environment exist for testing execution of the Apis, Example:
* https://localhost:44358/api/customer/create: **POST**, create a customer with the following JSon object:
   {
    "FirtsName": "Juanito",
    "LastName": "Jimenez",
    "Document": "909090",
    "Phone": "4330090",
    "Email": "juanito@correo.com"
  }

* In the change of sale status, https://localhost:44358/api/sale/changeState/{id}/{state} : **GET**, the following status codes should be observed:

** 1: Acceptada
** 2: Confirmada
** 3: Anulada
** 4: Rechazada

If an incorrect code is sent, a message will be displayed informing the incorrect status.
