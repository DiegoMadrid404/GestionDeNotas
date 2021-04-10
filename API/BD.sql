
CREATE DATABASE [Notas]

USE [Notas]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 9/04/2021 7:54:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](240) NOT NULL,
	[PrimerApellido] [nvarchar](120) NOT NULL,
	[SegundoApellido] [nvarchar](120) NULL,
	[DocumentoIdentificacion] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Alumno_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 9/04/2021 7:54:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
	[Nombre] [nvarchar](240) NOT NULL,
 CONSTRAINT [PK_Materia_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nota]    Script Date: 9/04/2021 7:54:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nota](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAlumno] [int] NOT NULL,
	[IdMateria] [int] NOT NULL,
	[Calificacion] [decimal](2, 1) NULL,
 CONSTRAINT [PK_Nota_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Alumno] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumno] ([Id])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Alumno]
GO
ALTER TABLE [dbo].[Nota]  WITH CHECK ADD  CONSTRAINT [FK_Nota_Materia] FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([Id])
GO
ALTER TABLE [dbo].[Nota] CHECK CONSTRAINT [FK_Nota_Materia]
GO


INSERT INTO  [dbo].[Materia](Codigo,Nombre) 
VALUES
('ABC123','ESPAÑOL')

INSERT INTO  [dbo].[Materia](Codigo,Nombre) 
VALUES
('XYZ','INGLES')

INSERT INTO  [dbo].[Materia](Codigo,Nombre) 
VALUES
('QWERTY12','MATEMATICAS')

INSERT INTO [dbo].[Alumno] (Nombres, PrimerApellido, SegundoApellido,DocumentoIdentificacion,Email)
VALUES
('LUIS','PEREZ','PARRA','1976482','PEREZPARRAL@GMAIL.COM')

INSERT INTO [dbo].[Alumno] (Nombres, PrimerApellido, SegundoApellido,DocumentoIdentificacion,Email)
VALUES
('LINA','SOLER','LEON','3323','LINASOLER2@GMAIL.COM')
