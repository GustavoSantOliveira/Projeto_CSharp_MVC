USE [master]
GO
CREATE DATABASE Teste_Analista

USE Teste_Analista
GO
CREATE TABLE dbo.Contatos(
	Id int IDENTITY(1,1) NOT NULL,
	Nome nvarchar(100) NOT NULL,
	Email nvarchar(100) NULL,
	Telefone nvarchar(100) NULL,
 CONSTRAINT [PK_Contatos] PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
  ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

USE [Teste_Analista]
GO

INSERT INTO [dbo].[TB_CONTATO]
           ([Nome]
           ,[Email]
           ,[Telefone])
     VALUES
           ('Gustavo', 'gustavo@email.com', '11111111'),
		   ('Pedro', 'pedro@email.com', '222222222'),
		   ('Beatriz', 'Beatriz@email.com', '33333333')
GO