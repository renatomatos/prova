USE [walmart]
GO
/****** Object:  User [walmart]    Script Date: 06/10/2013 00:12:33 ******/
CREATE USER [walmart] FOR LOGIN [walmart] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/10/2013 00:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](60) NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Senha] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Usuarios] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 06/10/2013 00:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Pais] [varchar](60) NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Sigla] [char](2) NOT NULL,
	[Regiao] [varchar](60) NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cidades]    Script Date: 06/10/2013 00:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cidades](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [int] NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Capital] [char](1) NOT NULL,
 CONSTRAINT [PK_Cidades] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_usuario_update]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_usuario_update]
(
	@Id int,
    @Nome varchar(60),
    @Senha varchar(max)
)
as
begin
	update [dbo].[Usuarios]
       set [Nome] = @Nome,
		   [Senha] = @Senha
	 where [Id] = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[usp_usuario_select]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_usuario_select]
(
	@Id int,
	@Login varchar(60)
)
as
begin
	declare @filter as table
	(
		id int primary key
	)
	
	if (@Id > 0)
	  begin
	    insert into @filter values (@Id)
	  end
	else if (RTRIM(LTRIM(@LOgin)) <> '')
	  begin
	    insert into @filter 
		select Id
		  from dbo.Usuarios us (nolock)
		 where us.[Login] = @Login 	
	  end
	else	  
	  begin
	    insert into @filter 
		select Id
		  from dbo.Usuarios us (nolock)
	  end
	
	select us.Id as US_ID,
		   us.Login as US_LOGIN,
		   us.Nome as US_NOME,
		   us.Senha as US_SENHA
	  from dbo.Usuarios us (nolock)
	 where exists (select 1
					 from @filter flt
					where flt.id = us.Id)

end
GO
/****** Object:  StoredProcedure [dbo].[usp_usuario_insert]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_usuario_insert]
(
	@Login varchar(60),
    @Nome varchar(60),
    @Senha varchar(max)
)
as
begin
	-- exec dbo.usp_usuario_insert 'walmart', 'walmart e-commerce', 'walmart'

	INSERT INTO [dbo].[Usuarios]
    (
		[Login],
        [Nome],
        [Senha]
    )
    VALUES
    (
		@Login,
        @Nome,
        @Senha
	)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_usuario_delete]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_usuario_delete]
(
	@Id int
)
as
begin
	delete from [dbo].[Usuarios]
	 where [Id] = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[usp_estado_update]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_estado_update]
(
	@Codigo int,
	@Pais varchar(60),
    @Nome varchar(60),
    @Sigla char(2),
    @Regiao varchar(60)
)
as
begin
	/*
		Edição de estados
		
		exec dbo.usp_estado_update 1, 'Brasil', 'São Paulo', 'SP', 'Sudeste'
	*/
	
	update [dbo].[Estados]
       set Pais = @Pais,
		   Nome = @NOme,
		   Sigla = @Sigla,
           Regiao = @Regiao
     where Codigo = @Codigo

end
GO
/****** Object:  StoredProcedure [dbo].[usp_estado_select]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_estado_select]
(
	@Codigo int,
	@Nome varchar(60)
)
as
begin
	/*
		consulta de estados
		
		exec dbo.usp_estado_select 1, ''	
	*/
	
	declare @filter as table
	(
		codigo int primary key
	)
	
	if (@Codigo > 0)
	  begin
		insert into @filter values (@Codigo)
	  end
	else if (LTRIM(Rtrim(@Nome)) <> '')
	  begin
		insert into @filter
		select codigo
		  from dbo.Estados (nolock)
		 where Nome like '%' + @Nome + '%'
	  end
	else
	  begin
		insert into @filter
		select codigo
		  from dbo.Estados (nolock)
	  end
	
	-- result
	select Codigo as UF_CODIGO, 
		   Nome as UF_NOME,
		   Sigla as UF_SIGLA,
		   Pais as UF_PAIS,
		   Regiao as UF_REGIAO
	  from [dbo].[Estados] (nolock) uf
     where exists (select 1
				     from @filter flt
					where flt.codigo = uf.Codigo) 

end
GO
/****** Object:  StoredProcedure [dbo].[usp_estado_insert]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_estado_insert]
(
	@Pais varchar(60),
    @Nome varchar(60),
    @Sigla char(2),
    @Regiao varchar(60)
)
as
begin
	/*
		Inclusão de estados
		
		exec dbo.usp_estado_insert 'Brasil', 'São Paulo', 'SP', 'Sudeste'
	*/
	
	INSERT INTO [dbo].[Estados]
    (
		Pais,
        Nome,
        Sigla,
        Regiao
	)
    VALUES
    (	
		@Pais, 
        @Nome,
        @Sigla,
        @Regiao
	)	

end
GO
/****** Object:  StoredProcedure [dbo].[usp_estado_delete]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_estado_delete]
(
	@Codigo int
)
as
begin
	/*
		Exclusão de estados
		
		exec dbo.usp_estado_delete 1
	*/
	
	delete from [dbo].[Estados]
     where Codigo = @Codigo

end
GO
/****** Object:  StoredProcedure [dbo].[usp_cidade_update]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_cidade_update]
(
	@Codigo int,
	@Estado int,
	@Nome varchar(60),
	@Capital char(1)
)
as
begin
	/*
		exec dbo.usp_cidade_update 1, 1, 'Fortaleza', 'S'
	*/		

	update dbo.Cidades
	   set Estado = @Estado,
		   Nome = @Nome,
		   Capital = @Capital
	 where Codigo = @Codigo

end
GO
/****** Object:  StoredProcedure [dbo].[usp_cidade_select]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_cidade_select]
(
	@Codigo int,
	@Nome varchar(60)
)
as
begin
	/*
		exec dbo.usp_cidade_select 0, 'Fort'
	*/		
	
	declare @filter as table
	(
		codigo int primary key
	)
	
	if (@Codigo > 0)
	  begin
		insert into @filter values (@codigo)
	  end
    else if (RTRIM(ltrim(@nome)) <> '')	  
      begin
        insert into @filter 
        select codigo
          from dbo.Cidades (nolock)
         where Nome like '%' + @nome + '%'
      end
	else      
      begin
        insert into @filter 
        select codigo
          from dbo.Cidades (nolock)
      end

	select cd.Codigo as CD_CODIGO,
		   cd.Capital as CD_CAPITAL,
		   cd.Nome as CD_NOME,
		   uf.Codigo as UF_CODIGO,
		   uf.Nome as UF_NOME,
		   uf.Pais as UF_PAIS,
		   uf.Regiao as UF_REGIAO,
		   uf.Sigla as UF_SIGLA
	  from dbo.Cidades cd (nolock)
	 inner join dbo.Estados uf (nolock)
	    on uf.Codigo = cd.Estado
	 where exists (select 1
				     from @filter flt
				    where cd.Codigo = flt.codigo) 

end
GO
/****** Object:  StoredProcedure [dbo].[usp_cidade_insert]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_cidade_insert]
(
	@Estado int,
	@Nome varchar(60),
	@Capital char(1)
)
as
begin
	-- exec dbo.usp_cidade_insert 1, 'Fortaleza', 'S'

	insert into dbo.Cidades
	(
		Estado,
		Nome,
		Capital
	)
	values
	(
		@Estado,
		@Nome,
		@Capital
	)

end
GO
/****** Object:  StoredProcedure [dbo].[usp_cidade_delete]    Script Date: 06/10/2013 00:12:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_cidade_delete]
(
	@Codigo int
)
as
begin
	/*
		exec dbo.usp_cidade_delete 1
	*/		

	delete from dbo.Cidades
	 where Codigo = @Codigo

end
GO
/****** Object:  ForeignKey [FK_Cidades_Estados]    Script Date: 06/10/2013 00:12:35 ******/
ALTER TABLE [dbo].[Cidades]  WITH CHECK ADD  CONSTRAINT [FK_Cidades_Estados] FOREIGN KEY([Estado])
REFERENCES [dbo].[Estados] ([Codigo])
GO
ALTER TABLE [dbo].[Cidades] CHECK CONSTRAINT [FK_Cidades_Estados]
GO
