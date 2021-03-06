USE [DBServer_Teste]
GO
/****** Object:  Table [dbo].[TB_CONTA]    Script Date: 03/11/2019 23:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CONTA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [varchar](3) NULL,
	[Agencia] [int] NULL,
	[CC] [int] NULL,
	[Digito] [int] NULL,
	[Nome] [varchar](200) NULL,
 CONSTRAINT [PK_TB_CONTA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TB_CONTA] ON
INSERT [dbo].[TB_CONTA] ([Id], [Banco], [Agencia], [CC], [Digito], [Nome]) VALUES (2, N'001', 1, 18090, 3, N'Luiz Gustavo Saraiva')
INSERT [dbo].[TB_CONTA] ([Id], [Banco], [Agencia], [CC], [Digito], [Nome]) VALUES (4, N'237', 2, 7878, 1, N'Fabiola Rissi')
INSERT [dbo].[TB_CONTA] ([Id], [Banco], [Agencia], [CC], [Digito], [Nome]) VALUES (5, N'341', 1, 23232, 4, N'Ricardo Santos')
INSERT [dbo].[TB_CONTA] ([Id], [Banco], [Agencia], [CC], [Digito], [Nome]) VALUES (6, N'001', 1, 25671, 3, N'Jose Santos')
SET IDENTITY_INSERT [dbo].[TB_CONTA] OFF
/****** Object:  Table [dbo].[TB_LANCAMENTO]    Script Date: 03/11/2019 23:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_LANCAMENTO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Conta_Origem] [int] NULL,
	[Id_Conta_Destino] [int] NULL,
	[Valor] [float] NULL,
	[Data] [datetime] NULL,
 CONSTRAINT [PK_TB_LANCAMENTO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_LANCAMENTO] ON
INSERT [dbo].[TB_LANCAMENTO] ([Id], [Id_Conta_Origem], [Id_Conta_Destino], [Valor], [Data]) VALUES (4, 2, 4, 200, CAST(0x0000AA0A00035202 AS DateTime))
INSERT [dbo].[TB_LANCAMENTO] ([Id], [Id_Conta_Origem], [Id_Conta_Destino], [Valor], [Data]) VALUES (5, 4, 5, 300, CAST(0x0000AA0A00035202 AS DateTime))
INSERT [dbo].[TB_LANCAMENTO] ([Id], [Id_Conta_Origem], [Id_Conta_Destino], [Valor], [Data]) VALUES (6, 2, 5, 500, CAST(0x0000AA0A00035202 AS DateTime))
INSERT [dbo].[TB_LANCAMENTO] ([Id], [Id_Conta_Origem], [Id_Conta_Destino], [Valor], [Data]) VALUES (7, 2, 4, 500, CAST(0x0000AA0D0145AC69 AS DateTime))
INSERT [dbo].[TB_LANCAMENTO] ([Id], [Id_Conta_Origem], [Id_Conta_Destino], [Valor], [Data]) VALUES (9, 4, 5, 300, CAST(0x0000AA0D0145CAE3 AS DateTime))
INSERT [dbo].[TB_LANCAMENTO] ([Id], [Id_Conta_Origem], [Id_Conta_Destino], [Valor], [Data]) VALUES (10, 4, 5, 300.57, CAST(0x0000AA0D0145D359 AS DateTime))
INSERT [dbo].[TB_LANCAMENTO] ([Id], [Id_Conta_Origem], [Id_Conta_Destino], [Valor], [Data]) VALUES (11, 2, 4, 200, CAST(0x0000AA0D0163A969 AS DateTime))
SET IDENTITY_INSERT [dbo].[TB_LANCAMENTO] OFF
/****** Object:  StoredProcedure [dbo].[sp_conta_obter]    Script Date: 03/11/2019 23:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luiz Gustavo Saraiva
-- Create date: 11/03/2018
-- Description:	Obter Conta por Banco, Agencia, CC, Digito
-- Execute:     exec sp_conta_obter '001', 1, 18090
-- =============================================
CREATE PROCEDURE [dbo].[sp_conta_obter]
	@banco varchar(3)='',
	@agencia int = 0,
	@cc int =0,
	@digito int=0
AS
BEGIN
	select Id, Banco, Agencia, CC, Digito,Nome 
	from TB_CONTA
	where Banco = @banco
	and Agencia = @agencia
	and CC = @cc
	and Digito = @digito
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_conta_inserir]    Script Date: 03/11/2019 23:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luiz Gustavo Saraiva
-- Create date: 11/03/2018
-- Description:	Inserir Conta
-- Execute:     exec sp_conta_inserir '001', 1, 25671, 3,'Jose Santos'
-- =============================================
CREATE PROCEDURE [dbo].[sp_conta_inserir]
	@banco   varchar(3)='',
	@agencia int = 0,
	@cc      int =0,
	@digito  int=0,
	@nome    varchar(200)
AS
BEGIN

	insert into TB_CONTA(Banco, Agencia, CC, Digito, Nome)
	values(@banco, @agencia, @cc, @digito, @nome);
	
	select Id, Banco, Agencia, CC, Digito, Nome from TB_CONTA where Id = @@IDENTITY
	
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_lancamento_inserir]    Script Date: 03/11/2019 23:56:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Luiz Gustavo Saraiva
-- Create date: 11/03/2018
-- Description:	Inserir Lancamento
-- Execute:     exec sp_lancamento_inserir 2, 4, 500
-- =============================================
CREATE PROCEDURE [dbo].[sp_lancamento_inserir]
	@id_conta_origem   varchar(3)='',
	@id_conta_destino  int   = 0,
	@valor             float = 0
AS
BEGIN

	insert into TB_LANCAMENTO(Id_Conta_Origem, Id_Conta_Destino, Valor, Data)
	values(@id_conta_origem, @id_conta_destino, @valor, getdate());
	
	select Id, Id_Conta_Origem, Id_Conta_Destino, Valor,Data from TB_LANCAMENTO where Id = @@IDENTITY
	
	
END
GO
/****** Object:  Default [DF_TB_LANCAMENTO_DATA]    Script Date: 03/11/2019 23:56:30 ******/
ALTER TABLE [dbo].[TB_LANCAMENTO] ADD  CONSTRAINT [DF_TB_LANCAMENTO_DATA]  DEFAULT (getdate()) FOR [Data]
GO
/****** Object:  ForeignKey [FK_TB_LANCAMENTO_TB_CONTA]    Script Date: 03/11/2019 23:56:30 ******/
ALTER TABLE [dbo].[TB_LANCAMENTO]  WITH CHECK ADD  CONSTRAINT [FK_TB_LANCAMENTO_TB_CONTA] FOREIGN KEY([Id_Conta_Destino])
REFERENCES [dbo].[TB_CONTA] ([Id])
GO
ALTER TABLE [dbo].[TB_LANCAMENTO] CHECK CONSTRAINT [FK_TB_LANCAMENTO_TB_CONTA]
GO
/****** Object:  ForeignKey [FK_TB_LANCAMENTO_TB_CONTA1]    Script Date: 03/11/2019 23:56:30 ******/
ALTER TABLE [dbo].[TB_LANCAMENTO]  WITH CHECK ADD  CONSTRAINT [FK_TB_LANCAMENTO_TB_CONTA1] FOREIGN KEY([Id_Conta_Origem])
REFERENCES [dbo].[TB_CONTA] ([Id])
GO
ALTER TABLE [dbo].[TB_LANCAMENTO] CHECK CONSTRAINT [FK_TB_LANCAMENTO_TB_CONTA1]
GO
