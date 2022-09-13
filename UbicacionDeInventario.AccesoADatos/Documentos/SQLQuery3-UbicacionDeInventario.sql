CREATE DATABASE UbicacionDeInventaro;
USE UbicacionDeInventaro;

Go

CREATE TABLE [dbo].[Rol](
  [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
  [Nombre] [varchar](30) NOT NULL
)
GO
CREATE TABLE [dbo].[Usuario](
   [Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
   [IdRol] [int] NOT NULL,
   [Nombre] [varchar](30) NOT NULL,
   [Apellido] [varchar](30) NOT NULL,
   [Login] [varchar](25) NOT NULL,
   [Password] [char](32) NOT NULL,
   [Estatus] [tinyint] NOT NULL,
   [FechaRegistro] [datetime] NOT NULL,
   CONSTRAINT FK1_Rol_Usuario FOREIGN KEY (IdRol) REFERENCES Rol (Id)
)
GO

CREATE TABLE Sucursal(
 Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
 Nombre varchar(30)NOT NULL,
 Telefono varchar(11) NOT NULL,
)
GO

CREATE TABLE Bodega(
Id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
Nombre varchar(30) NOT NULL,
FechaDeCreacion datetime  NOT NULL,
Estatus tinyint NOT NULL,
Descripcion varchar(150) NOT NULL,
IdSucursal int NOT NULL,
CONSTRAINT FK1_Sucursal_Bodega FOREIGN KEY (IdSucursal) REFERENCES Sucursal(Id)

)
GO

CREATE TABLE Estante(
	Id int PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nombre varchar(20) NOT NULL,
	IdBodega int NOT NULL,
	CONSTRAINT FK1_Bodega_Estante FOREIGN KEY (IdBodega) REFERENCES Bodega(Id)
)
Go