USE [master]
GO
/****** Object:  Database [BrokerDB]    Script Date: 14/10/2023 04:48:38 ******/
CREATE DATABASE [BrokerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BrokerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BrokerDB.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BrokerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BrokerDB_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BrokerDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BrokerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BrokerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BrokerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BrokerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BrokerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BrokerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BrokerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BrokerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BrokerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BrokerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BrokerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BrokerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BrokerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BrokerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BrokerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BrokerDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BrokerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BrokerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BrokerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BrokerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BrokerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BrokerDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BrokerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BrokerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BrokerDB] SET  MULTI_USER 
GO
ALTER DATABASE [BrokerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BrokerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BrokerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BrokerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BrokerDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BrokerDB', N'ON'
GO
USE [BrokerDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Acciones]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acciones](
	[IdAccion] [int] IDENTITY(1,1) NOT NULL,
	[Simbolo] [varchar](50) NOT NULL,
	[Empresa] [varchar](15) NOT NULL,
	[Logo] [varchar](50) NOT NULL,
	[Precio] [decimal](11, 2) NOT NULL,
	[FechaAlta] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Acciones] PRIMARY KEY CLUSTERED 
(
	[IdAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Cantidad] [int] NOT NULL,
	[Total] [decimal](11, 2) NOT NULL,
	[FechaBaja] [datetime] NULL,
	[IdCuenta] [int] NULL,
	[IdAccion] [int] NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[IdCuenta] [int] IDENTITY(1,1) NOT NULL,
	[Cbu] [varchar](15) NOT NULL,
	[Saldo] [decimal](11, 2) NOT NULL,
	[EstaHabilitada] [bit] NOT NULL,
	[FechaAlta] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
	[IdPersona] [int] NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[IdLocalidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](15) NOT NULL,
	[FechaAlta] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonaModelRolModel]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonaModelRolModel](
	[PersonasIdPersona] [int] NOT NULL,
	[RolesIdRol] [int] NOT NULL,
 CONSTRAINT [PK_PersonaModelRolModel] PRIMARY KEY CLUSTERED 
(
	[PersonasIdPersona] ASC,
	[RolesIdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](15) NOT NULL,
	[Apellido] [varchar](15) NOT NULL,
	[Dni] [varchar](15) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Usuario] [varchar](15) NOT NULL,
	[Contrasenia] [varchar](15) NOT NULL,
	[FechaAlta] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
	[IdLocalidad] [int] NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 14/10/2023 04:48:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](15) NOT NULL,
	[FechaAlta] [datetime] NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231014013445_Inicio', N'7.0.12')
GO
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([IdLocalidad], [Nombre], [FechaAlta], [FechaBaja]) VALUES (1, N'Alta G', CAST(N'2023-10-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Localidades] ([IdLocalidad], [Nombre], [FechaAlta], [FechaBaja]) VALUES (2, N'Capilla', CAST(N'2023-10-14T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
GO
/****** Object:  Index [IX_Compras_IdAccion]    Script Date: 14/10/2023 04:48:38 ******/
CREATE NONCLUSTERED INDEX [IX_Compras_IdAccion] ON [dbo].[Compras]
(
	[IdAccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Compras_IdCuenta]    Script Date: 14/10/2023 04:48:38 ******/
CREATE NONCLUSTERED INDEX [IX_Compras_IdCuenta] ON [dbo].[Compras]
(
	[IdCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cuentas_IdPersona]    Script Date: 14/10/2023 04:48:38 ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_IdPersona] ON [dbo].[Cuentas]
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonaModelRolModel_RolesIdRol]    Script Date: 14/10/2023 04:48:38 ******/
CREATE NONCLUSTERED INDEX [IX_PersonaModelRolModel_RolesIdRol] ON [dbo].[PersonaModelRolModel]
(
	[RolesIdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Personas_IdLocalidad]    Script Date: 14/10/2023 04:48:38 ******/
CREATE NONCLUSTERED INDEX [IX_Personas_IdLocalidad] ON [dbo].[Personas]
(
	[IdLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Acciones_IdAccion] FOREIGN KEY([IdAccion])
REFERENCES [dbo].[Acciones] ([IdAccion])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Acciones_IdAccion]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Cuentas_IdCuenta] FOREIGN KEY([IdCuenta])
REFERENCES [dbo].[Cuentas] ([IdCuenta])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Cuentas_IdCuenta]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Personas_IdPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Personas] ([IdPersona])
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Personas_IdPersona]
GO
ALTER TABLE [dbo].[PersonaModelRolModel]  WITH CHECK ADD  CONSTRAINT [FK_PersonaModelRolModel_Personas_PersonasIdPersona] FOREIGN KEY([PersonasIdPersona])
REFERENCES [dbo].[Personas] ([IdPersona])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonaModelRolModel] CHECK CONSTRAINT [FK_PersonaModelRolModel_Personas_PersonasIdPersona]
GO
ALTER TABLE [dbo].[PersonaModelRolModel]  WITH CHECK ADD  CONSTRAINT [FK_PersonaModelRolModel_Roles_RolesIdRol] FOREIGN KEY([RolesIdRol])
REFERENCES [dbo].[Roles] ([IdRol])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonaModelRolModel] CHECK CONSTRAINT [FK_PersonaModelRolModel_Roles_RolesIdRol]
GO
ALTER TABLE [dbo].[Personas]  WITH CHECK ADD  CONSTRAINT [FK_Personas_Localidades_IdLocalidad] FOREIGN KEY([IdLocalidad])
REFERENCES [dbo].[Localidades] ([IdLocalidad])
GO
ALTER TABLE [dbo].[Personas] CHECK CONSTRAINT [FK_Personas_Localidades_IdLocalidad]
GO
USE [master]
GO
ALTER DATABASE [BrokerDB] SET  READ_WRITE 
GO
