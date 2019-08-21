CREATE DATABASE M_Peoples

Use M_Peoples

Create Table Funcionarios(
	IdFuncionario INT IDENTITY NOT NULL PRIMARY KEY
	,NomeFuncionario Varchar(255) not null 
	,SobrenomeFuncionario Varchar(255) not null 
);
	

Alter Table Funcionarios
Add DataNascimento Date
	
