--1) Crear una BD con el nombre "Broker"
USE master

CREATE DATABASE Broker



--2) Dentro de la BD "Broker", crear las 7 tablas: 
USE Broker

CREATE TABLE Localidades(
	Id_Localidad INT IDENTITY(1,1),
	Nombre VARCHAR(25) NOT NULL,
	Fecha_Alta DATETIME DEFAULT GETDATE(),
	Fecha_Baja DATETIME NULL,	
	
	CONSTRAINT Localidades_Id_Localidad_PK PRIMARY KEY(Id_Localidad)	
	)


CREATE TABLE Personas(
	Id_Persona INT IDENTITY(1,1),
	Nombre VARCHAR(25) NOT NULL,
	Apellido VARCHAR(25) NOT NULL,
	Dni VARCHAR(25) NOT NULL,
	Fecha_Nacimiento DATE NOT NULL,
	Usuario VARCHAR(25) NOT NULL,
	Contrasenia VARCHAR(25) NOT NULL,
	Fecha_Alta DATETIME DEFAULT GETDATE(),
	Fecha_Baja DATETIME NULL,
	Id_Localidad INT,
	
	CONSTRAINT Personas_Id_Persona_PK PRIMARY KEY(Id_Persona),
	CONSTRAINT Personas_Id_Localidad_FK FOREIGN KEY(Id_Localidad) REFERENCES Localidades(Id_Localidad)
	)	


CREATE TABLE Roles(
	Id_Rol INT IDENTITY(1,1),
	Nombre VARCHAR(25) NOT NULL,
	Fecha_Alta DATETIME DEFAULT GETDATE(),
	Fecha_Baja DATETIME NULL,	
	
	CONSTRAINT Roles_Id_Rol_PK PRIMARY KEY(Id_Rol)	
	)

CREATE TABLE Roles_Personas(
	Id_Rol_Persona INT IDENTITY(1,1),	
	Fecha_Alta DATETIME DEFAULT GETDATE(),
	Fecha_Baja DATETIME NULL,
	Id_Persona INT,
	Id_Rol INT,
	
	CONSTRAINT Roles_Personas_Id_Rol_Persona_PK PRIMARY KEY(Id_Rol_Persona),
	CONSTRAINT Roles_Personas_Id_Persona_FK FOREIGN KEY(Id_Persona) REFERENCES Personas(Id_Persona),
	CONSTRAINT Roles_Personas_Id_Rol_FK FOREIGN KEY(Id_Rol) REFERENCES Roles(Id_Rol)
	)


CREATE TABLE Cuentas(
	Id_Cuenta INT IDENTITY(1,1),
	Cbu VARCHAR(25) NOT NULL,
	Saldo DECIMAL(11,2) NOT NULL,
	Esta_Habilitada BIT NOT NULL,
	Fecha_Alta DATETIME DEFAULT GETDATE(),
	Fecha_Baja DATETIME NULL,
	Id_Persona INT,	
	
	CONSTRAINT Cuentas_Id_Cuenta_PK PRIMARY KEY(Id_Cuenta),
	CONSTRAINT Cuentas_Id_Persona_FK FOREIGN KEY(Id_Persona) REFERENCES Personas(Id_Persona),	
	CONSTRAINT Cuentas_Cbu_UK UNIQUE(Cbu)
	)	


CREATE TABLE Acciones(
	Id_Accion INT IDENTITY(1,1),
	Simbolo VARCHAR(50) NOT NULL,
	Empresa VARCHAR(25) NOT NULL,
	Logo VARCHAR(50) NOT NULL,
	Precio DECIMAL(11,2) NOT NULL,
	Fecha_Alta DATETIME DEFAULT GETDATE(),
	Fecha_Baja DATETIME NULL,	
	
	CONSTRAINT Acciones_Id_Accion_PK PRIMARY KEY(Id_Accion)	
	)


CREATE TABLE Compras(
	Id_Compra INT IDENTITY(1,1),
	Fecha DATETIME DEFAULT GETDATE(),
	Cantidad INT NOT NULL,	
	Total DECIMAL(11,2) NOT NULL,	
	Fecha_Baja DATETIME NULL,
	Id_Cuenta INT,
	Id_Accion INT,
	
	CONSTRAINT Compras_Id_Compra_PK PRIMARY KEY(Id_Compra),
	CONSTRAINT Compras_Id_Cuenta_FK FOREIGN KEY(Id_Cuenta) REFERENCES Cuentas(Id_Cuenta),
	CONSTRAINT Compras_Id_Accion_FK FOREIGN KEY(Id_Accion) REFERENCES Acciones(Id_Accion)
	)








