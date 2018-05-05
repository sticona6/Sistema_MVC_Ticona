--Crear Base de Datos
CREATE DATABASE db_galeria_web2
GO

USE db_galeria_web2
GO	

--crear tablas
if (not exists(select 1 from sys.tables where name = 'Categoria'))
    CREATE TABLE dbo.Categoria (
       categoria_id  int identity(1,1) NOT NULL,
       nombre        varchar(250) NOT NULL,
       descripcion 	 text NULL,
	   estado        char(1)       
       PRIMARY KEY (categoria_id)
)
go

if (not exists(select 1 from sys.tables where name = 'Galeria'))
    CREATE TABLE dbo.Galeria (
       galeria_id		int identity(1,1) NOT NULL,
	   categoria_id		int NOT NULL,
       nombre			varchar(250) NOT NULL,
       descripcion		text NULL,
	   imagen			varchar(250) NOT NULL,
	   thumbail			varchar(250) NOT NULL,	
	   estado			char(1)       
       PRIMARY KEY (galeria_id),
	   FOREIGN KEY (categoria_id) REFERENCES Categoria
)
go

if (not exists(select 1 from sys.tables where name = 'Documento'))
    CREATE TABLE dbo.Documento (
       documento_id		int identity(1,1) NOT NULL,
	   categoria_id		int NOT NULL,
       nombre			varchar(250) NOT NULL,
       descripcion		text NULL,
	   extension		varchar(4) NOT NULL,
       tamanio			varchar(20) NOT NULL,
	   tipo				varchar(250) NOT NULL,	
	   estado			char(1)       
       PRIMARY KEY (documento_id),
	   FOREIGN KEY (categoria_id) REFERENCES Categoria
)
go


if (not exists(select 1 from sys.tables where name = 'Persona'))
    CREATE TABLE dbo.Persona (
       persona_id      int identity(1,1) NOT NULL,       
       dni             varchar(8) NOT NULL UNIQUE,       
       apellido        varchar(100) NOT NULL,
	   nombre          varchar(50) NOT NULL,       
       email           varchar(100) NULL UNIQUE,
       celular	       varchar(15) NULL,
       estado          varchar(1) NULL,
       PRIMARY KEY (persona_id)       
)
go


if (not exists(select 1 from sys.tables where name = 'Usuario'))
    CREATE TABLE dbo.Usuario (
       usuario_id      int identity(1,1) NOT NULL,
       persona_id      int NOT NULL,         
       usuario         varchar(30) NOT NULL UNIQUE,
       clave           varchar(50) NOT NULL,
	   nivel		   varchar(45) NOT NULL,      
       avatar          varchar(250) NULL,	
       estado          varchar(1) NOT NULL,       
       PRIMARY KEY (usuario_id),
       FOREIGN KEY (persona_id)  REFERENCES Persona        
)
go


