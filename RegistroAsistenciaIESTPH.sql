USE [master]
GO
/****** Object:  Database [Asitencia_IESTPH]    Script Date: 18/12/2023 12:49:54 ******/
CREATE DATABASE [Asitencia_IESTPH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Asitencia_IESTPH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Asitencia_IESTPH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Asitencia_IESTPH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Asitencia_IESTPH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Asitencia_IESTPH] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Asitencia_IESTPH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Asitencia_IESTPH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET ARITHABORT OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Asitencia_IESTPH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Asitencia_IESTPH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Asitencia_IESTPH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Asitencia_IESTPH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET RECOVERY FULL 
GO
ALTER DATABASE [Asitencia_IESTPH] SET  MULTI_USER 
GO
ALTER DATABASE [Asitencia_IESTPH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Asitencia_IESTPH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Asitencia_IESTPH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Asitencia_IESTPH] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Asitencia_IESTPH] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Asitencia_IESTPH] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Asitencia_IESTPH', N'ON'
GO
ALTER DATABASE [Asitencia_IESTPH] SET QUERY_STORE = OFF
GO
USE [Asitencia_IESTPH]
GO
/****** Object:  Table [dbo].[ASISTENCIA]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASISTENCIA](
	[AsistenciaID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[EstudianteID] [int] NOT NULL,
	[DocenteID] [int] NOT NULL,
	[CursoID] [int] NOT NULL,
 CONSTRAINT [PK__ASISTENC__72710F45FCDEBB4B] PRIMARY KEY CLUSTERED 
(
	[AsistenciaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CURSO]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CURSO](
	[CursoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Horario_Inicio] [varchar](20) NOT NULL,
	[Horario_Final] [varchar](20) NOT NULL,
	[DocenteID] [int] NOT NULL,
	[ProgramaEstudioID] [int] NOT NULL,
 CONSTRAINT [PK__CURSO__7E023A3797CA282B] PRIMARY KEY CLUSTERED 
(
	[CursoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CURSO_ESTUDIANTE]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CURSO_ESTUDIANTE](
	[CursoEstudianteID] [int] IDENTITY(1,1) NOT NULL,
	[EstudianteID] [int] NOT NULL,
	[CursoID] [int] NOT NULL,
 CONSTRAINT [PK_CURSO_ESTUDIANTE] PRIMARY KEY CLUSTERED 
(
	[CursoEstudianteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DOCENTE]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOCENTE](
	[DocenteID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[E_mail] [varchar](100) NULL,
	[Teléfono] [varchar](10) NOT NULL,
	[ProgramaEstudioID] [int] NOT NULL,
	[Contraseña] [varchar](30) NULL,
 CONSTRAINT [PK__DOCENTE__9CB7A941C13A8CC3] PRIMARY KEY CLUSTERED 
(
	[DocenteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ESTUDIANTE]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTUDIANTE](
	[EstudianteID] [int] IDENTITY(1,1) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Teléfono] [varchar](10) NOT NULL,
	[E_mail] [varchar](100) NULL,
	[ProgramaEstudioID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EstudianteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATRICULA_DOCENTE]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATRICULA_DOCENTE](
	[MatriculaDocenteID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramaEstudioID] [int] NOT NULL,
	[CursoID] [int] NOT NULL,
	[DocenteID] [int] NOT NULL,
 CONSTRAINT [PK_MATRICULA_DOCENTE] PRIMARY KEY CLUSTERED 
(
	[MatriculaDocenteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATRICULA_ESTUDIANTE]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATRICULA_ESTUDIANTE](
	[MatriculaEstudianteID] [int] IDENTITY(1,1) NOT NULL,
	[ProgramaEstudioID] [int] NOT NULL,
	[CursoID] [int] NOT NULL,
	[EstudianteID] [int] NOT NULL,
 CONSTRAINT [PK_MATRICULA_ESTUDIANTE] PRIMARY KEY CLUSTERED 
(
	[MatriculaEstudianteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROGRAMA_ESTUDIO]    Script Date: 18/12/2023 12:49:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROGRAMA_ESTUDIO](
	[ProgramaEstudioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK__PROGRAMA__FC0DFB5B9B203A35] PRIMARY KEY CLUSTERED 
(
	[ProgramaEstudioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/12/2023 12:49:55 ******/
/****** Commit*****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[usuario] [varchar](30) NULL,
	[contraseña] [varchar](30) NULL,
	[Nivel] [varchar](30) NOT NULL,
 CONSTRAINT [PK__Usuarios__3214EC0714418AFC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ASISTENCIA] ON 

INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (1, CAST(N'2023-12-12T00:00:00.000' AS DateTime), N'ASISTIO', 17, 1, 1)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (2, CAST(N'2023-12-17T22:40:22.997' AS DateTime), N'Tarde', 17, 1, 1)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (3, CAST(N'2023-12-17T22:40:22.997' AS DateTime), N'Falta', 17, 1, 1)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (4, CAST(N'2023-12-17T22:40:22.997' AS DateTime), N'Falta', 17, 1, 1)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (5, CAST(N'2023-12-17T22:53:10.440' AS DateTime), N'Asistió', 21, 12, 1010)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (6, CAST(N'2023-12-17T23:05:17.757' AS DateTime), N'Asistió', 21, 12, 1010)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (7, CAST(N'2023-12-17T23:21:15.900' AS DateTime), N'Tarde', 21, 12, 1010)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (8, CAST(N'2023-12-18T08:32:48.000' AS DateTime), N'Asistió', 21, 12, 1010)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (9, CAST(N'2023-12-18T09:42:42.000' AS DateTime), N'Tarde', 21, 12, 1010)
INSERT [dbo].[ASISTENCIA] ([AsistenciaID], [Fecha], [Estado], [EstudianteID], [DocenteID], [CursoID]) VALUES (10, CAST(N'2023-12-18T09:45:24.727' AS DateTime), N'Asistió', 21, 12, 1010)
SET IDENTITY_INSERT [dbo].[ASISTENCIA] OFF
GO
SET IDENTITY_INSERT [dbo].[CURSO] ON 

INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (1, N'Taller de Base de Datos', N'Apr 12 2023  7:30PM', N'Apr 12 2023 10:30PM', 1, 1)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (2, N'Lógica de Programación', N'Apr 13 2023  6:00PM', N'Apr 13 2023  7:30PM', 2, 2)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (3, N'Ofimatica', N'Apr 14 2023  9:30PM', N'Apr 14 2023 10:30PM', 3, 1)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (5, N'Estadistica', N'Apr 12 2023  8:30PM', N'Apr 12 2023 10:30PM', 3, 3)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (6, N'Comunicacion', N'Dec  4 2023  8:30PM', N'Dec  4 2023 10:30PM', 1, 2)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (1005, N'Saneamiento', N'Oct  1 2023  8:30PM', N'Oct  1 2023 10:30PM', 5, 5)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (1006, N'Cr ianza de animales menores', N'Jan  1 1900  8:00AM', N'Jan  1 1900 10:00AM', 12, 5)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (1007, N'Programacion', N'Jan  1 1900  6:00PM', N'Jan  1 1900  9:00PM', 1, 1)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (1008, N'Metalurgia', N'Jan  1 1900  9:00AM', N'Jan  1 1900 11:00AM', 10, 5)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (1010, N'Pastos y forrajes', N'8:00 AM', N'9:30 AM', 12, 6)
INSERT [dbo].[CURSO] ([CursoID], [Nombre], [Horario_Inicio], [Horario_Final], [DocenteID], [ProgramaEstudioID]) VALUES (1011, N'Gestion de Documentos ', N'9:30 AM', N'11:00 AM', 11, 8)
SET IDENTITY_INSERT [dbo].[CURSO] OFF
GO
SET IDENTITY_INSERT [dbo].[DOCENTE] ON 

INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (1, N'22323245', N'Raul', N'Quispe Taipe', N'raul@gmail.com', N'987654321', 1, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (2, N'23456789', N'Roxana', N'Tunque Ruiz', N'rox@gmail.com', N'987654324', 2, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (3, N'20206080', N'Pamela', N'De La Cruz Castro', N'palmer@gmail.com', N'923459436', 3, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (4, N'23456709', N'Beatriz', N'Jorge Manriquez', N'jorge@gmail.com', N'987609811', 4, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (6, N'24242526', N'Ricardo', N'Lujan Castro', N'Lujan@gmail.com', N'978787878', 1, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (8, N'23205497', N'Maria', N'Geronimo Grimaldo', N'maria@gmail.com', N'987789789', 4, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (10, N'45675345', N'Delfina', N'Cayetano Giraldes', N'cayetano@hotmail.com', N'978387526', 5, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (11, N'45672632', N'Junior Yarel', N'De La Cruz Quinto', N'junior@hotmail.com', N'966267283', 8, N'12345')
INSERT [dbo].[DOCENTE] ([DocenteID], [DNI], [Nombres], [Apellidos], [E_mail], [Teléfono], [ProgramaEstudioID], [Contraseña]) VALUES (12, N'23208089', N'Raquel', N'Arias Belito', N'arias@outlook.pe', N'953452786', 6, N'12345')
SET IDENTITY_INSERT [dbo].[DOCENTE] OFF
GO
SET IDENTITY_INSERT [dbo].[ESTUDIANTE] ON 

INSERT [dbo].[ESTUDIANTE] ([EstudianteID], [DNI], [Nombres], [Apellidos], [Teléfono], [E_mail], [ProgramaEstudioID]) VALUES (17, N'70654344', N'Junior Yarel', N'Espinoza Taipe', N'987456789', N'Yerson_123@gmailcom', 1)
INSERT [dbo].[ESTUDIANTE] ([EstudianteID], [DNI], [Nombres], [Apellidos], [Teléfono], [E_mail], [ProgramaEstudioID]) VALUES (20, N'23456574', N'Hector', N'Alanya Aguirre', N'978642189', N'Hector@gmail.com', 1010)
INSERT [dbo].[ESTUDIANTE] ([EstudianteID], [DNI], [Nombres], [Apellidos], [Teléfono], [E_mail], [ProgramaEstudioID]) VALUES (21, N'23453455', N'Angel', N'Mulato Quispe', N'923763945', N'Angel.di@outlook.pe', 6)
INSERT [dbo].[ESTUDIANTE] ([EstudianteID], [DNI], [Nombres], [Apellidos], [Teléfono], [E_mail], [ProgramaEstudioID]) VALUES (22, N'23234564', N'Predro', N'Acevedo Taipe', N'978654376', N'pedro@hotmail.com', 3)
INSERT [dbo].[ESTUDIANTE] ([EstudianteID], [DNI], [Nombres], [Apellidos], [Teléfono], [E_mail], [ProgramaEstudioID]) VALUES (23, N'44544767', N'Magno', N'Huaman Dueñas', N'987345276', N'Dueñas@gmail.com', 9)
INSERT [dbo].[ESTUDIANTE] ([EstudianteID], [DNI], [Nombres], [Apellidos], [Teléfono], [E_mail], [ProgramaEstudioID]) VALUES (24, N'26267890', N'Jesus', N'Ticona Ticllasuca', N'987678787', N'Ticona@gmail.com', 5)
INSERT [dbo].[ESTUDIANTE] ([EstudianteID], [DNI], [Nombres], [Apellidos], [Teléfono], [E_mail], [ProgramaEstudioID]) VALUES (25, N'60768534', N'Nelly', N'Huincho Delgado', N'967543245', N'Nelly@gmail.com', 8)
SET IDENTITY_INSERT [dbo].[ESTUDIANTE] OFF
GO
SET IDENTITY_INSERT [dbo].[MATRICULA_DOCENTE] ON 

INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (1, 1, 1, 4)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (2, 5, 1005, 10)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (3, 1, 3, 6)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (11, 1, 1, 8)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (15, 1, 1, 1)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (16, 3, 5, 3)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (17, 1, 1, 6)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (18, 5, 1006, 10)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (20, 3, 5, 3)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (21, 6, 1010, 12)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (22, 5, 1005, 10)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (23, 6, 1010, 12)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (24, 5, 1005, 10)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (25, 3, 5, 3)
INSERT [dbo].[MATRICULA_DOCENTE] ([MatriculaDocenteID], [ProgramaEstudioID], [CursoID], [DocenteID]) VALUES (26, 3, 5, 3)
SET IDENTITY_INSERT [dbo].[MATRICULA_DOCENTE] OFF
GO
SET IDENTITY_INSERT [dbo].[MATRICULA_ESTUDIANTE] ON 

INSERT [dbo].[MATRICULA_ESTUDIANTE] ([MatriculaEstudianteID], [ProgramaEstudioID], [CursoID], [EstudianteID]) VALUES (1, 6, 1010, 21)
INSERT [dbo].[MATRICULA_ESTUDIANTE] ([MatriculaEstudianteID], [ProgramaEstudioID], [CursoID], [EstudianteID]) VALUES (2, 1, 1, 17)
SET IDENTITY_INSERT [dbo].[MATRICULA_ESTUDIANTE] OFF
GO
SET IDENTITY_INSERT [dbo].[PROGRAMA_ESTUDIO] ON 

INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (1, N'Computación e Informática')
INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (3, N'Secretariado Ejecutivo')
INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (5, N'Mecánica de Producción Industrial')
INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (6, N'Producción Agropecuaria')
INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (8, N'Contabilidad')
INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (9, N'Construcción Civil')
INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (1010, N'Enfermería')
INSERT [dbo].[PROGRAMA_ESTUDIO] ([ProgramaEstudioID], [Nombre]) VALUES (1011, N'administracion')
SET IDENTITY_INSERT [dbo].[PROGRAMA_ESTUDIO] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre], [usuario], [contraseña], [Nivel]) VALUES (1, N'Yesika', N'yesika', N'12345', N'Administrador')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [usuario], [contraseña], [Nivel]) VALUES (2, N'Junior', N'Junior', N'12345', N'Usuario')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  StoredProcedure [dbo].[Listar_Matricula_Docentes]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Listar_Matricula_Docentes]
AS
SELECT md.MatriculaDocenteID,pe.Nombre AS NombrePE,c.Nombre  AS NombreCurso ,d.Nombres+' '+d.Apellidos AS NombreCompleto
FROM MATRICULA_DOCENTE md INNER JOIN PROGRAMA_ESTUDIO pe
ON md.ProgramaEstudioID=pe.ProgramaEstudioID INNER JOIN CURSO c 
ON pe.ProgramaEstudioID=c.ProgramaEstudioID INNER JOIN DOCENTE d
ON c.DocenteID=d.DocenteID
GO
/****** Object:  StoredProcedure [dbo].[SP_VizualizarDocente]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_VizualizarDocente]
@CursoID INT
AS
SELECT c.CursoID, d.Nombres +' '+ d.Apellidos AS NombreCompleto 
FROM CURSO c INNER JOIN DOCENTE d ON c.DocenteID=d.DocenteID 
where CursoID = @CursoID
GO
/****** Object:  StoredProcedure [dbo].[USP_ASISTENCIA_GUARDAR]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ASISTENCIA_GUARDAR]
@Fecha datetime,
@Estado varchar (20),
@EstudianteID int,
@DocenteID int,
@CursoID int
AS
INSERT INTO ASISTENCIA (Fecha,Estado,EstudianteID,DocenteID,CursoID)
VALUES (@Fecha,@Estado,@EstudianteID,@DocenteID,@CursoID)
GO
/****** Object:  StoredProcedure [dbo].[USP_CONSULTA]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_CONSULTA]
AS
SELECT ASISTENCIA.Fecha, ESTUDIANTE.Nombres, ESTUDIANTE.Apellidos, ASISTENCIA.Estado,CURSO.Nombre AS Curso
FROM ASISTENCIA  INNER JOIN ESTUDIANTE ON Asistencia.EstudianteID = Estudiante.EstudianteID
INNER JOIN MATRICULA_ESTUDIANTE ON Asistencia.EstudianteID = MATRICULA_ESTUDIANTE.EstudianteID
INNER JOIN CURSO ON MATRICULA_ESTUDIANTE.CursoID = Curso.CursoID
INNER JOIN PROGRAMA_ESTUDIO ON ESTUDIANTE.ProgramaEstudioID = PROGRAMA_ESTUDIO.ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_CURSO_Actualizar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_CURSO_Actualizar]
@CursoID INT,
@Nombre varchar(50),
@Horario_Inicio varchar(20),
@Horario_Final varchar(20),
@DocenteID int ,
@ProgramaEstudioID int
AS
UPDATE CURSO
SET Nombre=@Nombre,Horario_Inicio=@Horario_Inicio,Horario_Final=@Horario_Final,
DocenteID=@DocenteID,ProgramaEstudioID=@ProgramaEstudioID 
WHERE CursoID = @CursoID 
GO
/****** Object:  StoredProcedure [dbo].[USP_CURSO_Eliminar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_CURSO_Eliminar]
@CursoID int
AS
DELETE FROM CURSO WHERE CursoID = @CursoID
GO
/****** Object:  StoredProcedure [dbo].[USP_CURSO_Guardar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_CURSO_Guardar]
@Nombre varchar(50),
@Horario_Inicio varchar(20),
@Horario_Final varchar(20),
@DocenteID int,
@ProgramaEstudioID int

AS
INSERT INTO CURSO (Nombre,Horario_Inicio,Horario_Final,DocenteID,ProgramaEstudioID)
VALUES(@Nombre,@Horario_Inicio,@Horario_Final,@DocenteID,@ProgramaEstudioID) 
GO
/****** Object:  StoredProcedure [dbo].[USP_CURSO_Listar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_CURSO_Listar]
AS
SELECT CursoID, c.Nombre, c.Horario_Inicio, c.Horario_Final,pe.Nombre as NombrePE,d.Nombres+' '+ d.Apellidos as NombreCompleto
FROM CURSO c INNER JOIN PROGRAMA_ESTUDIO pe on c.ProgramaEstudioID = pe.ProgramaEstudioID
INNER JOIN DOCENTE d on  c.DocenteID=d.DocenteID
GO
/****** Object:  StoredProcedure [dbo].[USP_DOCENTE_Actualizar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_DOCENTE_Actualizar]
@DocenteID INT,
@DNI varchar(8),
@Nombres varchar(50),
@Apellidos varchar(50),
@E_mail varchar(100),
@Teléfono varchar (10),
@ProgramaEstudioID int,
@Contraseña varchar(30)

AS
UPDATE DOCENTE
SET DNI=@DNI,Nombres=@Nombres,Apellidos=@Apellidos,E_mail=@E_mail,Teléfono=@Teléfono,ProgramaEstudioID=@ProgramaEstudioID,Contraseña=@Contraseña
WHERE DocenteID = @DocenteID
GO
/****** Object:  StoredProcedure [dbo].[USP_Docente_Curso]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Docente_Curso]
@DocenteID INT
AS
SELECT CursoID,Nombre,Horario_Inicio,Horario_Final,ProgramaEstudioID
FROM CURSO WHERE DocenteID=@DocenteID
GO
/****** Object:  StoredProcedure [dbo].[USP_DOCENTE_Eliminar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_DOCENTE_Eliminar]
@DocenteID int
AS
DELETE FROM DOCENTE WHERE DocenteID = @DocenteID
GO
/****** Object:  StoredProcedure [dbo].[USP_DOCENTE_Guardar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_DOCENTE_Guardar]
	@DNI varchar(8),
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@E_mail varchar(100),
	@Teléfono varchar (10),
	@ProgramaEstudioID int,
	@Contraseña varchar(30)

AS
INSERT INTO DOCENTE (DNI,Nombres,Apellidos,E_mail,Teléfono,ProgramaEstudioID,Contraseña)
VALUES(@DNI,@Nombres,@Apellidos,@E_mail,@Teléfono,@ProgramaEstudioID,@Contraseña) 
GO
/****** Object:  StoredProcedure [dbo].[USP_DOCENTE_Listar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_DOCENTE_Listar]
AS
select DocenteID, DNI, Nombres, Apellidos, E_mail, Teléfono,Nombre,Contraseña
from DOCENTE d INNER JOIN PROGRAMA_ESTUDIO pe on  pe.ProgramaEstudioID = d.ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_ESTUDIANTE_Actualizar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ESTUDIANTE_Actualizar]

@EstudianteID int,
@DNI varchar(8),
@Nombres varchar(50),
@Apellidos varchar(50),
@Teléfono varchar (10),
@E_mail varchar(100),
@ProgramaEstudioID int

AS
UPDATE ESTUDIANTE
SET DNI=@DNI,Nombres=@Nombres,Apellidos=@Apellidos,Teléfono=@Teléfono,E_mail=@E_mail,ProgramaEstudioID=@ProgramaEstudioID WHERE EstudianteID = @EstudianteID
GO
/****** Object:  StoredProcedure [dbo].[USP_ESTUDIANTE_Eliminar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ESTUDIANTE_Eliminar]
@EstudianteID int
AS
DELETE FROM ESTUDIANTE WHERE EstudianteID = @EstudianteID
GO
/****** Object:  StoredProcedure [dbo].[USP_ESTUDIANTE_Guardar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_ESTUDIANTE_Guardar]
    @DNI varchar(8),
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Teléfono varchar (10),
	@E_mail varchar(100),
	@ProgramaEstudioID int


AS
INSERT INTO ESTUDIANTE (DNI,Nombres,Apellidos,Teléfono,E_mail,ProgramaEstudioID)
VALUES(@DNI,@Nombres,@Apellidos,@Teléfono,@E_mail,@ProgramaEstudioID) 
GO
/****** Object:  StoredProcedure [dbo].[USP_ESTUDIANTE_Listar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ESTUDIANTE_Listar]
AS
select e.EstudianteID, e.DNI, e.Nombres, e.Apellidos,e.Teléfono, e.E_mail, pe.Nombre from ESTUDIANTE e
INNER JOIN PROGRAMA_ESTUDIO pe on  pe.ProgramaEstudioID = e.ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_HistorialAsistencia]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_HistorialAsistencia]
@EstudianteID int
as
select Asistencia.Fecha, Asistencia.Estado, Estudiante.Nombres, Estudiante.Apellidos,Estudiante.DNI
FROM Asistencia INNER JOIN Estudiante ON Asistencia.EstudianteID = Estudiante.EstudianteID
WHERE Estudiante.EstudianteID = @EstudianteID
ORDER BY Asistencia.Fecha DESC;
GO
/****** Object:  StoredProcedure [dbo].[USP_Listar_CursosAsistencia]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Listar_CursosAsistencia]
@DocenteID INT
AS
SELECT CursoID, Nombre, Horario_Inicio, Horario_Final, ProgramaEstudioID from CURSO
WHERE DocenteID=@DocenteID
GO
/****** Object:  StoredProcedure [dbo].[USP_Listar_Matricula_Estudiantes]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Listar_Matricula_Estudiantes]
AS
SELECT me.MatriculaEstudianteID,pe.Nombre AS NombrePE,c.Nombre AS NombreCurso ,e.Nombres +' '+ e.Apellidos AS NombreCompleto
FROM MATRICULA_ESTUDIANTE me INNER JOIN PROGRAMA_ESTUDIO pe
ON me.ProgramaEstudioID=pe.ProgramaEstudioID INNER JOIN CURSO c 
ON pe.ProgramaEstudioID=c.ProgramaEstudioID INNER JOIN ESTUDIANTE e
ON c.ProgramaEstudioID=e.ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_ListarCursos_X_ProgEst]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ListarCursos_X_ProgEst]
@ProgramaEstudioID int 
AS
SELECT CursoID, Nombre FROM CURSO WHERE ProgramaEstudioID = @ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_ListarDocentes_X_ProgEst]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ListarDocentes_X_ProgEst]
@ProgramaEstudioID int
AS
SELECT DocenteID, Nombres +' '+ Apellidos AS NombreCompleto FROM DOCENTE
WHERE ProgramaEstudioID = @ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_ListarEstudiante_X_Curso]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ListarEstudiante_X_Curso]
@CursoID int
AS
SELECT E.EstudianteID, E.Nombres +' '+ E.Apellidos as NombreCompleto,Estado ='Falta'
FROM MATRICULA_ESTUDIANTE ME INNER JOIN  ESTUDIANTE E ON E.EstudianteID=ME.EstudianteID
INNER JOIN CURSO C ON C.ProgramaEstudioID= E.ProgramaEstudioID
WHERE ME.CursoID=@CursoID
GO
/****** Object:  StoredProcedure [dbo].[USP_ListarEstudiantes_X_ProgEst]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_ListarEstudiantes_X_ProgEst]
@ProgramaEstudioID int
AS
SELECT EstudianteID, Nombres +' '+ Apellidos AS NombreCompleto FROM ESTUDIANTE
WHERE ProgramaEstudioID = @ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_MATRICULA_DOCENTE_Guardar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_MATRICULA_DOCENTE_Guardar]
    @ProgramaEstudioID  int,
	@CursoID  int,
	@DocenteID int
AS
INSERT INTO MATRICULA_DOCENTE (ProgramaEstudioID,CursoID,DocenteID)
VALUES(@ProgramaEstudioID, @CursoID, @DocenteID) 
GO
/****** Object:  StoredProcedure [dbo].[USP_MATRICULA_ESTUDIANTE_Guardar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_MATRICULA_ESTUDIANTE_Guardar]
    @ProgramaEstudioID  int,
	@CursoID  int,
	@EstudianteID int
AS
INSERT INTO MATRICULA_ESTUDIANTE (ProgramaEstudioID,CursoID,EstudianteID)
VALUES(@ProgramaEstudioID, @CursoID, @EstudianteID) 
GO
/****** Object:  StoredProcedure [dbo].[USP_Mostrar_Docente]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[USP_Mostrar_Docente]
 @DocenteID int
AS
SELECT Docente.Nombres +' '+ Docente.Apellidos AS NombreCompleto FROM Curso INNER JOIN Docente
ON Curso.DocenteID = Docente.DocenteID WHERE Curso.DocenteID = @DocenteID
GO
/****** Object:  StoredProcedure [dbo].[USP_PROGRAMA_ESTUDIO_Actualizar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from PROGRAMA_ESTUDIO

 CREATE PROCEDURE [dbo].[USP_PROGRAMA_ESTUDIO_Actualizar]
@ProgramaEstudioID int,
@Nombre varchar(200)
AS
UPDATE PROGRAMA_ESTUDIO SET Nombre=@Nombre WHERE ProgramaEstudioID = @ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_PROGRAMA_ESTUDIO_CURSO]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SELECT * FROM PROGRAMA_ESTUDIO
--SELECT * FROM CURSO


CREATE PROCEDURE [dbo].[USP_PROGRAMA_ESTUDIO_CURSO]
@ProgramaEstudioID int 
AS
SELECT PE.Nombre, C.Nombre FROM  PROGRAMA_ESTUDIO AS PE INNER JOIN CURSO AS C 
ON PE.ProgramaEstudioID = C.ProgramaEstudioID WHERE PE.ProgramaEstudioID = @ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_PROGRAMA_ESTUDIO_Eliminar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_PROGRAMA_ESTUDIO_Eliminar]
@ProgramaEstudioID int
AS
DELETE FROM PROGRAMA_ESTUDIO WHERE ProgramaEstudioID = @ProgramaEstudioID
GO
/****** Object:  StoredProcedure [dbo].[USP_PROGRAMA_ESTUDIO_Guardar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_PROGRAMA_ESTUDIO_Guardar]
@Nombre varchar (200)
AS
INSERT INTO PROGRAMA_ESTUDIO (Nombre)VALUES(@Nombre) 
GO
/****** Object:  StoredProcedure [dbo].[USP_PROGRAMA_ESTUDIO_Listar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_PROGRAMA_ESTUDIO_Listar]
AS
select ProgramaEstudioID, Nombre from PROGRAMA_ESTUDIO order by 1
GO
/****** Object:  StoredProcedure [dbo].[USP_Usuarios_Autenticar]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from Usuarios

CREATE PROCEDURE [dbo].[USP_Usuarios_Autenticar]
@Usuario nvarchar(30),
@contraseña nvarchar(30)
AS
SELECT Id, Nombre, Nivel FROM Usuarios
WHERE Usuario=@Usuario AND contraseña=@contraseña

GO
/****** Object:  StoredProcedure [dbo].[USP_UsuariosLogin]    Script Date: 18/12/2023 12:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[USP_UsuariosLogin] 
	@DNI int,
	@Contraseña varchar (30)
AS
SELECT DocenteID, Nombres + ' ' + Apellidos as Nombres,ProgramaEstudioID FROM DOCENTE
WHERE DNI=@DNI AND Contraseña=@Contraseña
GO
USE [master]
GO
ALTER DATABASE [Asitencia_IESTPH] SET  READ_WRITE 
GO
