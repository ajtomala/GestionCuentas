USE [master]
GO
/****** Object:  Database [BaseDatos]    Script Date: 11/9/2022 18:43:14 ******/
CREATE DATABASE [BaseDatos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDatos', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Data\BaseDatos.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BaseDatos_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Data\BaseDatos_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BaseDatos] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDatos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseDatos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseDatos] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseDatos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseDatos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseDatos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseDatos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseDatos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseDatos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseDatos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseDatos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseDatos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseDatos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseDatos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseDatos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseDatos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseDatos] SET RECOVERY FULL 
GO
ALTER DATABASE [BaseDatos] SET  MULTI_USER 
GO
ALTER DATABASE [BaseDatos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseDatos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseDatos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseDatos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BaseDatos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BaseDatos] SET QUERY_STORE = OFF
GO
USE [BaseDatos]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BaseDatos]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/9/2022 18:43:15 ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/9/2022 18:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Personaid] [bigint] NOT NULL,
	[contrasenia] [varbinary](max) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Personaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 11/9/2022 18:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[cuentaid] [bigint] IDENTITY(1,1) NOT NULL,
	[numcuenta] [nvarchar](20) NOT NULL,
	[tipocuenta] [nvarchar](20) NOT NULL,
	[saldoinicial] [decimal](12, 2) NOT NULL,
	[estado] [bit] NOT NULL,
	[clienteid] [bigint] NOT NULL,
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[cuentaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimiento]    Script Date: 11/9/2022 18:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimiento](
	[movimientoid] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime2](7) NOT NULL,
	[tipomovimiento] [nvarchar](20) NOT NULL,
	[descripcion] [nvarchar](20) NOT NULL,
	[valor] [decimal](12, 2) NOT NULL,
	[saldo] [decimal](12, 2) NOT NULL,
	[cuentaid] [bigint] NOT NULL,
 CONSTRAINT [PK_Movimiento] PRIMARY KEY CLUSTERED 
(
	[movimientoid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 11/9/2022 18:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Personaid] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Genero] [nvarchar](10) NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Personaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220911043151_InitialCreate', N'5.0.17')
GO
INSERT [dbo].[Cliente] ([Personaid], [contrasenia], [estado]) VALUES (1, 0x1985AD3CFF2F49F0A7743CE6AEDB725CE078466631CBF3D2D799A5D5C2F0D1EF, 1)
INSERT [dbo].[Cliente] ([Personaid], [contrasenia], [estado]) VALUES (2, 0x1985AD3CFF2F49F0A7743CE6AEDB725CE078466631CBF3D2D799A5D5C2F0D1EF, 1)
INSERT [dbo].[Cliente] ([Personaid], [contrasenia], [estado]) VALUES (4, 0x473287F8298DBA7163A897908958F7C0EAE733E25D2E027992EA2EDC9BED2FA8, 1)
GO
SET IDENTITY_INSERT [dbo].[Cuenta] ON 

INSERT [dbo].[Cuenta] ([cuentaid], [numcuenta], [tipocuenta], [saldoinicial], [estado], [clienteid]) VALUES (1, N'478758 ', N'Ahorros', CAST(2000.00 AS Decimal(12, 2)), 1, 1)
INSERT [dbo].[Cuenta] ([cuentaid], [numcuenta], [tipocuenta], [saldoinicial], [estado], [clienteid]) VALUES (3, N'225487', N'Corriente', CAST(100.00 AS Decimal(12, 2)), 1, 2)
INSERT [dbo].[Cuenta] ([cuentaid], [numcuenta], [tipocuenta], [saldoinicial], [estado], [clienteid]) VALUES (5, N'495878 ', N'Ahorros', CAST(0.00 AS Decimal(12, 2)), 1, 4)
INSERT [dbo].[Cuenta] ([cuentaid], [numcuenta], [tipocuenta], [saldoinicial], [estado], [clienteid]) VALUES (6, N'496825', N'Ahorros', CAST(540.00 AS Decimal(12, 2)), 1, 2)
INSERT [dbo].[Cuenta] ([cuentaid], [numcuenta], [tipocuenta], [saldoinicial], [estado], [clienteid]) VALUES (7, N'585545', N'Corriente', CAST(1000.00 AS Decimal(12, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[Cuenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Movimiento] ON 

INSERT [dbo].[Movimiento] ([movimientoid], [fecha], [tipomovimiento], [descripcion], [valor], [saldo], [cuentaid]) VALUES (6, CAST(N'2022-09-11T15:10:13.1230000' AS DateTime2), N'Credito', N'0123456Prueba', CAST(20.00 AS Decimal(12, 2)), CAST(130.90 AS Decimal(12, 2)), 1)
INSERT [dbo].[Movimiento] ([movimientoid], [fecha], [tipomovimiento], [descripcion], [valor], [saldo], [cuentaid]) VALUES (7, CAST(N'2022-09-11T15:10:13.1230000' AS DateTime2), N'Debito', N'0123456Prueba', CAST(20.00 AS Decimal(12, 2)), CAST(110.90 AS Decimal(12, 2)), 1)
INSERT [dbo].[Movimiento] ([movimientoid], [fecha], [tipomovimiento], [descripcion], [valor], [saldo], [cuentaid]) VALUES (8, CAST(N'2022-09-11T15:26:24.1830000' AS DateTime2), N'Credito', N'string', CAST(1000.00 AS Decimal(12, 2)), CAST(1130.90 AS Decimal(12, 2)), 1)
SET IDENTITY_INSERT [dbo].[Movimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Personaid], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (1, N'Jose Lema', N'Masculino', 20, N'1709959652', N'Otavalo sn y principal ', N'098254785')
INSERT [dbo].[Persona] ([Personaid], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (2, N'Marianela Montalvo', N'Femenino', 13, N'1709959652', N'Amazonas y  NNUU ', N'097548965')
INSERT [dbo].[Persona] ([Personaid], [Nombre], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (4, N'Juan Osorio', N'Masculino', 30, N'1204040487', N'13 junio y Equinoccial ', N'098874587')
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
/****** Object:  Index [IX_clienteid]    Script Date: 11/9/2022 18:43:16 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_clienteid] ON [dbo].[Cliente]
(
	[Personaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cuenta_clienteid]    Script Date: 11/9/2022 18:43:16 ******/
CREATE NONCLUSTERED INDEX [IX_Cuenta_clienteid] ON [dbo].[Cuenta]
(
	[clienteid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cuenta_numcuenta]    Script Date: 11/9/2022 18:43:16 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cuenta_numcuenta] ON [dbo].[Cuenta]
(
	[numcuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimiento_cuentaid]    Script Date: 11/9/2022 18:43:16 ******/
CREATE NONCLUSTERED INDEX [IX_Movimiento_cuentaid] ON [dbo].[Movimiento]
(
	[cuentaid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Persona_Personaid] FOREIGN KEY([Personaid])
REFERENCES [dbo].[Persona] ([Personaid])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Persona_Personaid]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_Cliente_clienteid] FOREIGN KEY([clienteid])
REFERENCES [dbo].[Cliente] ([Personaid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_Cliente_clienteid]
GO
ALTER TABLE [dbo].[Movimiento]  WITH CHECK ADD  CONSTRAINT [FK_Movimiento_Cuenta_cuentaid] FOREIGN KEY([cuentaid])
REFERENCES [dbo].[Cuenta] ([cuentaid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimiento] CHECK CONSTRAINT [FK_Movimiento_Cuenta_cuentaid]
GO
USE [master]
GO
ALTER DATABASE [BaseDatos] SET  READ_WRITE 
GO
