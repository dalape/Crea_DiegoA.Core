print '--****** database creation --******'
print '***** Start of execution ' + Convert(varchar(50), getdate()) + ' *****'
If not Exists(SELECT name FROM master.sys.databases WHERE name = 'Crea_Test_DA') Begin
	print '**** creating database ****'
	Create database Crea_Test_DA
End
print '***** end of execution ' + Convert(varchar(50), getdate()) + ' *****'
