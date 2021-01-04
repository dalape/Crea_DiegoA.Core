print '--****** Creación de base de datos para la prueba de Crea sistemas. Realizada por Diego Alape --******'
print '***** Inicio de ejecución ' + Convert(varchar(50), getdate()) + ' *****'
If not Exists(SELECT name FROM master.sys.databases WHERE name = 'Crea_Test_DA') Begin
	print '**** Creando la base de Datos ****'
	Create database Crea_Test_DA
End
print '***** Fin de ejecución ' + Convert(varchar(50), getdate()) + ' *****'