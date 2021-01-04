print '--****** Creación de tablas y data inicial para la prueba de Crea sistemas. Realizada por Diego Alape ******--'
print '***** Inicio de ejecución ' + Convert(varchar(50), getdate()) + ' *****'

Use Crea_Test_DA
Declare @tableName varchar(50)

Set @tableName = 'Customer'
IF OBJECT_ID(@tableName) is not null Begin
	print '--> Eliminando tabla ' + @tableName
	Drop table Sale
	Drop table Customer
End

print '--> Creando tabla ' + @tableName
Create table Customer
(
	ID int identity primary key,
	FirtsName varchar(100) not null,
	LastName varchar(100) not null,
	Document varchar(50) not null,
	Phone varchar(20) null,
	Email varchar(50) null,
	[Enable] bit null,
	CreatedDate datetime default getdate() null,
	UpdatedDate datetime default getdate() null
)

Set @tableName = 'Product'
IF OBJECT_ID(@tableName) is not null Begin
	print '--> Eliminando tabla ' + @tableName
	Drop table Product
End

print '--> Creando tabla ' + @tableName
Create table Product
(
	ID int identity primary key,
	[Name] varchar(200) unique not null,
	[Description] varchar(max) null,
	UnitPrice money not null,
	[Enable] bit null,
	CreatedDate datetime default getdate() null,
	UpdatedDate datetime default getdate() null
)

Set @tableName = 'Sale'
IF OBJECT_ID(@tableName) is not null Begin
	print '--> Eliminando tabla ' + @tableName
	Drop table Sale
End

print '--> Creando tabla ' + @tableName
Create table Sale
(
	ID int identity primary key,
	SaleGuid uniqueidentifier, 
	CustomerID int foreign key references Customer(ID) not null,
	ProductID int foreign key references Product(ID) not null,
	Quantity int default 1 not null,
	[State] varchar(100) null,
	SaleDate datetime default getdate() null
)

print '**** Insertando data inicial ****'
print '--> Insertando Clientes '
Insert Into Customer
Values	('Diego Fernando', 'Alape', '103070256', '30001010', 'dalape47@gmail.com', null, default, null),
		('Maria Fernanda', 'Zapata', '19002302', '31388990', 'mafez@gmail.com', null, default, null)

print '--> Insertando Productos'
Insert Into Product
Values	('Computador ACER', 'Portatil de 16 pulgadas marca ACER', 1500000, 1, default, null),
		('Mouse Genius', 'Mouse marca Genius', 50000, 1, default, null),
		('Monitor Samsung', 'Monitor de 21 pulgadas curvo marca Samsung', 900000, 1, default, null)

print '--> Insertando Ventas'
Insert Into Sale
Values	(NEWID(), 1, 1, default, 'Aceptada', default)

print '***** Fin de ejecución ' + Convert(varchar(50), getdate()) + ' *****'