CREATE DATABASE [Notas]
go
USE [Notas]
GO
/****** Object:  Table [dbo].[Alumno]   ******/
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
/****** Object:  Table [dbo].[Materia]     ******/
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
/****** Object:  Table [dbo].[Nota]  ******/
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

INSERT INTO 
dbo.Materia (CODIGO,NOMBRE) 
VALUES 
('asd123','Ingles'),
('abc456','Matematicas'),
('asd123','Religión')

insert into 
dbo.Alumno(Nombres,PrimerApellido,SegundoApellido,DocumentoIdentificacion,Email)
values
('Diego','Madrid','Mdr','12345','diego@correo.com'),
('Juan','Gomez','Perez','6789','Juan@correo.com'),
('Luisa','Marquez','Ruiz','101112','luisa@correo.com')

insert into 
dbo.Nota(IdAlumno,IdMateria,Calificacion)
values
(1,1,5),
(1,1,4.5),
(2,2,1),
(2,2,3),
(2,1,5),
(3,3,3)
 