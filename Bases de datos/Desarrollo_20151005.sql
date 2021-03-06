USE [master]
GO
/****** Object:  Database [BD_SeguridadInformatica]    Script Date: 05/10/2015 12:28:53 ******/
CREATE DATABASE [BD_SeguridadInformatica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_SeguridadInformatica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ECUIO0121834\MSSQL\DATA\BD_SeguridadInformatica.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 51200KB )
 LOG ON 
( NAME = N'BD_SeguridadInformatica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.ECUIO0121834\MSSQL\DATA\BD_SeguridadInformatica_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 51200KB )
GO
ALTER DATABASE [BD_SeguridadInformatica] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_SeguridadInformatica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_SeguridadInformatica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET  MULTI_USER 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_SeguridadInformatica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_SeguridadInformatica] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD_SeguridadInformatica', N'ON'
GO
USE [BD_SeguridadInformatica]
GO
/****** Object:  StoredProcedure [dbo].[Autorizados_List]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Autorizados_List]
as
BEGIN
SELECT [Nombre]
  FROM [BD_SeguridadInformatica].[dbo].[Autorizados]

END
GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_EditarLista]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_EditarLista]
	-- Add the parameters for the stored procedure here
		@IdLista INT,
		@NombreLista VARCHAR(100),
		@Valor VARCHAR(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@IdLista = 1)
	BEGIN
		--AÑADIR
		INSERT INTO [dbo].[BCA_Listas]
           ([IdLista]
           ,[NombreLista]
           ,[Valor])
     VALUES
           ((SELECT TOP 1 [IdLista] FROM [dbo].[BCA_Listas] WHERE [NombreLista] = @NombreLista)
           ,UPPER(@NombreLista)
           ,UPPER(@Valor))
	END
	ELSE
	BEGIN
		--ELIMINAR
		DELETE FROM [dbo].[BCA_Listas]
		WHERE [NombreLista] = @NombreLista AND [Valor] = @Valor
	END

END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_InsertDetalle]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_InsertDetalle]

			@IdServicio int
		   ,@Fecha date
           ,@Esfuerzo decimal(18,2)
           ,@Responsable varchar(50)
           ,@Detalle xml

AS

	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

	INSERT INTO [dbo].[BCA_Bitacora]
				([IdServicio]
				,[Fecha]
				,[Esfuerzo]
				,[Responsable]
				,[Detalle])
			VALUES
				(@IdServicio
				,@Fecha
				,@Esfuerzo
				,@Responsable
				,@Detalle)

		SET @Id = 1

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdRetorno'


GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_InsertLista]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_InsertLista]
	-- Add the parameters for the stored procedure here
		@NombreLista VARCHAR(100),
		@Valor VARCHAR(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @IdLista INT = 0
	SET @IdLista = (SELECT MAX(IdLista) FROM [BD_SeguridadInformatica].[dbo].[BCA_Listas]) + 1

	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		INSERT INTO [dbo].[BCA_Listas]
           ([IdLista]
           ,[NombreLista]
           ,[Valor])
		VALUES
           (@IdLista
           ,UPPER(RTRIM(LTRIM(@NombreLista)))
           ,UPPER(RTRIM(LTRIM(@Valor))))

		SET @Id = 1

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdRetorno'
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_ListaSelectAll]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_ListaSelectAll]
	-- Add the parameters for the stored procedure here
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdLista]
      ,[NombreLista]
      ,[Valor]
	FROM [BD_SeguridadInformatica].[dbo].[BCA_Listas]
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_SelectLista]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_SelectLista]
	-- Add the parameters for the stored procedure here
	@IdLista INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdLista]
	  ,[NombreLista]
      ,[Valor]
	FROM [BD_SeguridadInformatica].[dbo].[BCA_Listas]
	WHERE [IdLista] = @IdLista
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_SelectServicios]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_SelectServicios]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdServicio]
      ,[Nombre]
      ,[AuditUser]
      ,[AuditFecha]
      ,[AuditMachine]
	FROM [BD_SeguridadInformatica].[dbo].[BCA_Servicios]
	ORDER BY Nombre
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_SelectServiciosDetalles]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_SelectServiciosDetalles]
	-- Add the parameters for the stored procedure here
		@IdServicio INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdServicio]
      ,[Orden]
      ,[Nombre]
      ,[Tipo]
      ,[EsLista]
      ,[IdLista]
	FROM [BD_SeguridadInformatica].[dbo].[BCA_Servicios_Detalle]
	WHERE IdServicio = @IdServicio
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_Delete]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_Delete]
	-- Add the parameters for the stored procedure here
		@IdRegistro int		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		DELETE [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
		 WHERE [IdRegistro] = @IdRegistro

		SET @Id = @IdRegistro

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdBitacora'
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_Insert]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_Insert]
	-- Add the parameters for the stored procedure here
		@IdCategoria int,
		@IdEmpresa int,
		@FechaInicio datetime,
		@FechaFin datetime,
		@Tarea varchar(max),
		@Frecuencia varchar(50),
		@Evidencia varchar(max),
		@ResponsableIS varchar(20),
		@Esfuerzo decimal(18,2),
		@HoraExtra bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		INSERT INTO [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
			([IdCategoria]
			,[IdEmpresa]
			,[FechaInicio]
			,[FechaFin]
			,[Tarea]
			,[Frecuencia]
			,[Evidencia]
			,[ResponsableIS]
			,[Esfuerzo]
			,[HoraExtra])
		VALUES
			(@IdCategoria,
			@IdEmpresa,
			@FechaInicio,
			@FechaFin,
			@Tarea,
			@Frecuencia,
			@Evidencia,
			@ResponsableIS,
			@Esfuerzo,
			@HoraExtra)

		SET @Id = (select MAX([IdRegistro]) from [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad])

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdBitacora'
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectAll]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectAll]
	-- Add the parameters for the stored procedure here
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa]
	-- Add the parameters for the stored procedure here
	@IdEmpresa int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE [IdEmpresa] = @IdEmpresa
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa_User]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa_User]
	-- Add the parameters for the stored procedure here
	@IdEmpresa int
	, @ResponsableIS varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE [IdEmpresa] = @IdEmpresa
	  AND [ResponsableIS] = @ResponsableIS
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin]
	-- Add the parameters for the stored procedure here
	@FechaFin datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE CONVERT(DATE, [FechaFin]) = CONVERT(DATE, @FechaFin)
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin_User]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin_User]
	-- Add the parameters for the stored procedure here
	@FechaFin datetime
	, @ResponsableIS VARCHAR(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE CONVERT(DATE, [FechaFin]) = CONVERT(DATE, @FechaFin)
	  AND [ResponsableIS] = @ResponsableIS
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio]
	-- Add the parameters for the stored procedure here
	@FechaInicio datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE CONVERT(DATE, [FechaInicio]) = CONVERT(DATE, @FechaInicio)
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio_User]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio_User]
	-- Add the parameters for the stored procedure here
	@FechaInicio datetime
	, @ResponsableIS VARCHAR(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE CONVERT(DATE, [FechaInicio]) = CONVERT(DATE, @FechaInicio)
	  AND [ResponsableIS] = @ResponsableIS
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByIdResgistro]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByIdResgistro]
	-- Add the parameters for the stored procedure here
	@IdRegistro int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  where [IdRegistro] = @IdRegistro
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByMes]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByMes]
	-- Add the parameters for the stored procedure here
	@Mes VARCHAR(2)		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE MONTH([FechaFin]) = @Mes
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByMes_User]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByMes_User]
	-- Add the parameters for the stored procedure here
	@Mes VARCHAR(2)
	, @ResponsableIS varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE MONTH([FechaFin]) = @Mes
	  AND [ResponsableIS] = @ResponsableIS
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByResponsable]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByResponsable]
	-- Add the parameters for the stored procedure here
	@Responsable VARCHAR(20)		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE [ResponsableIS] like '%' + @Responsable + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio]
	-- Add the parameters for the stored procedure here
	@Servicio INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE [IdCategoria] = @Servicio
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio_User]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio_User]
	-- Add the parameters for the stored procedure here
	@Servicio INT
	, @ResponsableIS varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	  WHERE [IdCategoria] = @Servicio
	  AND [ResponsableIS] = @ResponsableIS
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectVariosFiltros]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_SelectVariosFiltros]
	-- Add the parameters for the stored procedure here
	@Servicio INT,
	@Responsable VARCHAR(20),
	@Mes VARCHAR(2),
	@FechaInicio datetime,
	@FechaFin datetime,
	@IdEmpresa int,
	@ano int,
	@extra bit
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @QUERY AS NVARCHAR(MAX)

	SET @QUERY = 'SELECT [IdRegistro]
		  ,[IdCategoria]
		  ,[IdEmpresa]
		  ,[FechaInicio]
		  ,[FechaFin]
		  ,[Tarea]
		  ,[Frecuencia]
		  ,[Evidencia]
		  ,[ResponsableIS]
		  ,[Esfuerzo]
		  ,[HoraExtra]
	  FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]'

--@Servicio	
IF @Servicio IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' [IdCategoria] = ' + CAST(@Servicio AS VARCHAR(MAX))
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' [IdCategoria] = ' + CAST(@Servicio AS VARCHAR(MAX))
	END
END

--@Responsable
IF @Responsable IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' [ResponsableIS] = ' +  char(39) + CAST(@Responsable AS VARCHAR(MAX)) +  char(39)
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' [ResponsableIS] = ' +  char(39) + CAST(@Responsable AS VARCHAR(MAX)) +  char(39)
	END
END

--@Mes VARCHAR(2),
IF @Mes IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' MONTH([FechaFin]) = ' +  char(39) + CAST(@Mes AS VARCHAR(MAX)) +  char(39)
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' MONTH([FechaFin]) = ' +  char(39) + CAST(@Mes AS VARCHAR(MAX)) +  char(39)
	END
END

--@FechaInicio datetime,
IF @FechaInicio IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' [FechaInicio] = ' +  char(39) + CAST(@FechaInicio AS VARCHAR(MAX)) +  char(39)
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' [FechaInicio] = ' +  char(39) + CAST(@FechaInicio AS VARCHAR(MAX)) +  char(39)
	END
END

--@FechaFin datetime,
IF @FechaFin IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' [FechaFin] = ' +  char(39) + CAST(@FechaFin AS VARCHAR(MAX)) +  char(39)
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' [FechaFin] = ' +  char(39) + CAST(@FechaFin AS VARCHAR(MAX)) +  char(39)
	END
END

--@IdEmpresa int
IF @IdEmpresa IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' [IdEmpresa] = ' + CAST(@IdEmpresa AS VARCHAR(MAX))
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' [IdEmpresa] = ' + CAST(@IdEmpresa AS VARCHAR(MAX))
	END
END

--@ano int
IF @ano IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' YEAR([FechaFin]) = ' + CAST(@ano AS VARCHAR(MAX))
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' YEAR([FechaFin]) = ' + CAST(@ano AS VARCHAR(MAX))
	END
END

--@extra int
IF @extra IS NOT NULL 
BEGIN
	IF ((SELECT CHARINDEX('WHERE', @QUERY)) = 0)
	BEGIN
		SET @QUERY = @QUERY + ' WHERE' + ' [HoraExtra] = ' + CAST(@extra AS VARCHAR(MAX))
	END
	ELSE
	BEGIN
		SET @QUERY = @QUERY + ' AND' + ' [HoraExtra] = ' + CAST(@extra AS VARCHAR(MAX))
	END
END

EXECUTE sp_executesql @QUERY
END

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_Update]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bitacora_IngenieriaSeguridad_Update]
	-- Add the parameters for the stored procedure here
		@IdRegistro int,
		@IdCategoria int,
		@IdEmpresa int, 
		@FechaInicio datetime,
		@FechaFin datetime,
		@Tarea varchar(max),
		@Frecuencia varchar(50),
		@Evidencia varchar(max),
		@ResponsableIS varchar(20),
		@Esfuerzo decimal(18,2),
		@HoraExtra bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		UPDATE [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
		   SET [IdCategoria] = @IdCategoria
		      ,[IdEmpresa] = @IdEmpresa
			  ,[FechaInicio] = @FechaInicio
			  ,[FechaFin] = @FechaFin			  
			  ,[Tarea] = @Tarea
			  ,[Frecuencia] = @Frecuencia
			  ,[Evidencia] = @Evidencia
			  ,[Esfuerzo] = @Esfuerzo
			  ,[HoraExtra] = @HoraExtra
		 WHERE [IdRegistro] = @IdRegistro

		SET @Id = @IdRegistro

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdBitacora'
END

GO
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_Delete]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categorias_IngenieriaSeguridad_Delete]
	-- Add the parameters for the stored procedure here
	@IdCategoria int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		DELETE FROM [BD_SeguridadInformatica].[dbo].[Categorias_IngenieriaSeguridad]
		WHERE [IdCategoria] = @IdCategoria

		SET @Id = @IdCategoria

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdCategoria'
END

GO
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_Insert]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categorias_IngenieriaSeguridad_Insert]
	-- Add the parameters for the stored procedure here
	@DescripcionCategoria varchar(200),
    @Audit_User varchar(20),
    @Audit_IpUsuario varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		INSERT INTO [BD_SeguridadInformatica].[dbo].[Categorias_IngenieriaSeguridad]
			   ([DescripcionCategoria]
			   ,[Audit_User]
			   ,[Audit_FechaUltimaModificacion]
			   ,[Audit_IpUsuario])
		 VALUES
			   (@DescripcionCategoria,
			   @Audit_User,
			   GETDATE(),
			   @Audit_IpUsuario)

		SET @Id = (select MAX([IdCategoria]) from [BD_SeguridadInformatica].[dbo].[Categorias_IngenieriaSeguridad])

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdCategoria'
END

GO
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_SelectAll]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categorias_IngenieriaSeguridad_SelectAll]
	-- Add the parameters for the stored procedure here
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdCategoria],
		[DescripcionCategoria],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Categorias_IngenieriaSeguridad]
END

GO
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_SelectbyDescripcion]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categorias_IngenieriaSeguridad_SelectbyDescripcion]
	-- Add the parameters for the stored procedure here
	@DescripcionCategoria varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdCategoria],
		[DescripcionCategoria],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Categorias_IngenieriaSeguridad]
	WHERE [DescripcionCategoria] LIKE '%' + @DescripcionCategoria + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_SelectbyId]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categorias_IngenieriaSeguridad_SelectbyId]
	-- Add the parameters for the stored procedure here
	@IdCategoria int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdCategoria],
		[DescripcionCategoria],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Categorias_IngenieriaSeguridad]
	WHERE [IdCategoria] = @IdCategoria
END

GO
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_Update]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Categorias_IngenieriaSeguridad_Update]
	-- Add the parameters for the stored procedure here
	@IdCategoria int,
	@DescripcionCategoria varchar(200),
    @Audit_User varchar(20),
    @Audit_IpUsuario varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		UPDATE [BD_SeguridadInformatica].[dbo].[Categorias_IngenieriaSeguridad]
		   SET [DescripcionCategoria] = @DescripcionCategoria,
			   [Audit_User] = @Audit_User,
			   [Audit_FechaUltimaModificacion] = GETDATE(),
			   [Audit_IpUsuario] = @Audit_IpUsuario
		 WHERE [IdCategoria] = @IdCategoria

		SET @Id = @IdCategoria

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdCategoria'
END

GO
/****** Object:  StoredProcedure [dbo].[Conocimiento_CabeceraLIsta]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Conocimiento_CabeceraLIsta] 
@idCat int
AS
	select Id, IdCat, Nombre from [dbo].[BCO_Cabecera]
	where IdCat =@idCat
	order by Nombre

GO
/****** Object:  StoredProcedure [dbo].[Conocimiento_CategoriasInsert]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Conocimiento_CategoriasInsert]
@Nombre varchar(100)
AS

declare @id Int
BEGIN TRY

	Insert into BCO_Categorias 
	select @Nombre

	COMMIT TRANSACTION
		   		
END TRY
BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

END CATCH

SELECT @Id as 'IdCat'
GO
/****** Object:  StoredProcedure [dbo].[Conocimiento_CategoriasLIsta]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Conocimiento_CategoriasLIsta]

AS
	select Id, Nombre from [dbo].[BCO_Categorias]
	order by Nombre

GO
/****** Object:  StoredProcedure [dbo].[Conocimiento_CategoriasUpdate]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Conocimiento_CategoriasUpdate]
@IdCat int,
@Nombre varchar(100)
AS

declare @id Int
BEGIN TRY
Begin tran
	update BCO_Categorias 
	set Nombre = @Nombre
	where id = @IdCat
	
	set @id = 0
	COMMIT TRANSACTION
		   		
END TRY
BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

END CATCH

SELECT @Id as 'IdCat'
GO
/****** Object:  StoredProcedure [dbo].[Conocimiento_DetalleInsert]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[Conocimiento_DetalleInsert]
	@IdCat int,
	@nombre varchar(200),
	@texto text,
	@observaciones text,
	@responsable varchar(50)
as


	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

	 INSERT INTO [dbo].[BCO_Cabecera]
           ([IdCat]
           ,[Nombre])
     VALUES
           (@IdCat
           ,@nombre)

		SET @Id = @@IDENTITY 


		INSERT INTO [dbo].[BCO_Detalle]
           ([IdCab]
           ,[Texto]
           ,[Observaciones]
           ,[Responsable]
           ,[FechaIngreso])
		VALUES
           (@Id
           ,@texto
           ,@observaciones
           ,@responsable 
           ,getdate())


		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdDetalle'

GO
/****** Object:  StoredProcedure [dbo].[Conocimiento_DetalleSelect]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Conocimiento_DetalleSelect]
@idCab int
AS
	select 
	IdCab,
	Texto,
	Observaciones,
	Responsable,
	FechaIngreso
	 from [dbo].[BCO_Detalle]
	where IdCab =@idCab


GO
/****** Object:  StoredProcedure [dbo].[Conocimiento_DetalleUpdate]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[Conocimiento_DetalleUpdate]
	@idCAB int, 
	@IdCat int,
	@nombre varchar(200),
	@texto text,
	@observaciones text,
	@responsable varchar(50)
as


	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

	 update [dbo].[BCO_Cabecera]
           set [IdCat] =@IdCat 
           ,[Nombre] = @nombre
		   where Id = @IDCAB

		UPDATE [dbo].[BCO_Detalle]
           set [Texto] = @texto
           ,[Observaciones] = @observaciones
           ,[Responsable] = @responsable 
           ,[FechaIngreso] = getdate()
		   where [IdCab] = @idCAB


		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdDetalle'

GO
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_Delete]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empresas_IngenieriaSeguridad_Delete]
	-- Add the parameters for the stored procedure here
	@IdEmpresa int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		DELETE FROM [BD_SeguridadInformatica].[dbo].[Empresas_IngenieriaSeguridad]
		WHERE [IdEmpresa] = @IdEmpresa

		SET @Id = @IdEmpresa

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdEmpresa'
END

GO
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_Insert]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empresas_IngenieriaSeguridad_Insert]
	-- Add the parameters for the stored procedure here
	@NombreEmpresa varchar(200),
    @Audit_User varchar(20),
    @Audit_IpUsuario varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		INSERT INTO [BD_SeguridadInformatica].[dbo].[Empresas_IngenieriaSeguridad]
			   ([NombreEmpresa]
			   ,[Audit_User]
			   ,[Audit_FechaUltimaModificacion]
			   ,[Audit_IpUsuario])
		 VALUES
			   (@NombreEmpresa,
			   @Audit_User,
			   GETDATE(),
			   @Audit_IpUsuario)

		SET @Id = (select MAX([IdEmpresa]) from [BD_SeguridadInformatica].[dbo].[Empresas_IngenieriaSeguridad])

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdEmpresa'
END

GO
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_SelectAll]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empresas_IngenieriaSeguridad_SelectAll]
	-- Add the parameters for the stored procedure here
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdEmpresa]
      ,[NombreEmpresa]
      ,[Audit_User]
      ,[Audit_FechaUltimaModificacion]
      ,[Audit_IpUsuario]
	  FROM [BD_SeguridadInformatica].[dbo].[Empresas_IngenieriaSeguridad]
END

GO
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_SelectByIdEmpresa]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empresas_IngenieriaSeguridad_SelectByIdEmpresa]
	-- Add the parameters for the stored procedure here
	@IdEmpresa int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT [IdEmpresa]
      ,[NombreEmpresa]
      ,[Audit_User]
      ,[Audit_FechaUltimaModificacion]
      ,[Audit_IpUsuario]
	  FROM [BD_SeguridadInformatica].[dbo].[Empresas_IngenieriaSeguridad]
	  where [IdEmpresa] = @IdEmpresa
END

GO
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_SelectbyNombreEmpresa]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empresas_IngenieriaSeguridad_SelectbyNombreEmpresa]
	-- Add the parameters for the stored procedure here
	@NombreEmpresa varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdEmpresa],
		[NombreEmpresa],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Empresas_IngenieriaSeguridad]
	WHERE [NombreEmpresa] LIKE '%' + @NombreEmpresa + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_Update]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empresas_IngenieriaSeguridad_Update]
	-- Add the parameters for the stored procedure here
	@IdEmpresa int,
	@NombreEmpresa varchar(200),
    @Audit_User varchar(20),
    @Audit_IpUsuario varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		UPDATE [BD_SeguridadInformatica].[dbo].[Empresas_IngenieriaSeguridad]
		   SET [NombreEmpresa] = @NombreEmpresa,
			   [Audit_User] = @Audit_User,
			   [Audit_FechaUltimaModificacion] = GETDATE(),
			   [Audit_IpUsuario] = @Audit_IpUsuario
		 WHERE [IdEmpresa] = @IdEmpresa

		SET @Id = @IdEmpresa

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdEmpresa'
END

GO
/****** Object:  StoredProcedure [dbo].[LogsConexion_Insert]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LogsConexion_Insert]
	-- Add the parameters for the stored procedure here
	@Accion varchar(max),
	@Autor varchar(20),
	@IpOrigen varchar(15),
	@Formulario varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION

	BEGIN TRY
		INSERT INTO [dbo].[LogsConexion]
           ([FechaHora]
           ,[Accion]
           ,[Autor]
           ,[IpOrigen]
           ,[Formulario])
		VALUES
           (GETDATE(),
            @Accion,
            @Autor,
            @IpOrigen,
            @Formulario)		

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION		

	END CATCH	
END

GO
/****** Object:  StoredProcedure [dbo].[ObtenerAno]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerAno]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
	DISTINCT(YEAR([FechaInicio])) 
	FROM [BD_SeguridadInformatica].[dbo].[Bitacora_IngenieriaSeguridad]
	ORDER BY YEAR([FechaInicio])
END

GO
/****** Object:  Table [dbo].[Autorizados]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Autorizados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Autorizados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCA_Bitacora]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCA_Bitacora](
	[IdBitacora] [int] IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Esfuerzo] [decimal](18, 2) NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[Detalle] [xml] NOT NULL,
 CONSTRAINT [PK_BCA_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdBitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCA_Listas]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCA_Listas](
	[IdLista] [int] NOT NULL,
	[NombreLista] [varchar](100) NOT NULL,
	[Valor] [varchar](500) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCA_Servicios]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCA_Servicios](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[AuditUser] [varchar](50) NOT NULL,
	[AuditFecha] [datetime] NOT NULL,
	[AuditMachine] [varchar](20) NULL,
 CONSTRAINT [PK_BCA_Servicios] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCA_Servicios_Detalle]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCA_Servicios_Detalle](
	[IdServicio] [int] NOT NULL,
	[Orden] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[EsLista] [bit] NOT NULL,
	[IdLista] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCO_Cabecera]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCO_Cabecera](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCat] [int] NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
 CONSTRAINT [PK_BCO_Cabecera] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCO_Categorias]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCO_Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_BCO_Categorias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCO_Detalle]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCO_Detalle](
	[IdCab] [int] NOT NULL,
	[Texto] [text] NULL,
	[Observaciones] [text] NULL,
	[Responsable] [varchar](50) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bitacora_IngenieriaSeguridad]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora_IngenieriaSeguridad](
	[IdRegistro] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdEmpresa] [int] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Tarea] [varchar](max) NOT NULL,
	[Frecuencia] [varchar](50) NOT NULL,
	[Evidencia] [varchar](max) NOT NULL,
	[ResponsableIS] [varchar](20) NOT NULL,
	[Esfuerzo] [decimal](18, 2) NOT NULL,
	[HoraExtra] [bit] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[IdRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categorias_IngenieriaSeguridad]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias_IngenieriaSeguridad](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionCategoria] [varchar](200) NOT NULL,
	[Audit_User] [varchar](20) NOT NULL,
	[Audit_FechaUltimaModificacion] [datetime] NOT NULL,
	[Audit_IpUsuario] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresas_IngenieriaSeguridad]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresas_IngenieriaSeguridad](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpresa] [varchar](150) NOT NULL,
	[Audit_User] [varchar](20) NOT NULL,
	[Audit_FechaUltimaModificacion] [datetime] NOT NULL,
	[Audit_IpUsuario] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Empresas_IngenieriaSeguridad] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HorasMes_Configuraciones]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HorasMes_Configuraciones](
	[Mes] [char](2) NOT NULL,
	[TotalHorasLaborables] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogsConexion]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogsConexion](
	[IdLogConexion] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Accion] [varchar](max) NOT NULL,
	[Autor] [varchar](20) NOT NULL,
	[IpOrigen] [varchar](15) NOT NULL,
	[Formulario] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LogsConexion] PRIMARY KEY CLUSTERED 
(
	[IdLogConexion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogsTransaccion]    Script Date: 05/10/2015 12:28:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogsTransaccion](
	[IdLog] [int] IDENTITY(1,1) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[DatoAnterior] [xml] NOT NULL,
	[DatoNuevo] [xml] NOT NULL,
	[Autor] [varchar](20) NOT NULL,
	[IpOrigen] [varchar](15) NOT NULL,
	[Tabla] [varchar](50) NOT NULL,
	[Accion] [char](1) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[IdLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [NonClusteredIndex-20150918-113400]    Script Date: 05/10/2015 12:28:53 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20150918-113400] ON [dbo].[BCA_Bitacora]
(
	[IdServicio] ASC,
	[Fecha] ASC,
	[Responsable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bitacora_IngenieriaSeguridad] ADD  CONSTRAINT [DF_Bitacora_IngenieriaSeguridad_HoraExtra]  DEFAULT ((0)) FOR [HoraExtra]
GO
ALTER TABLE [dbo].[LogsConexion] ADD  CONSTRAINT [DF_LogsConexion_FechaHora]  DEFAULT (getdate()) FOR [FechaHora]
GO
ALTER TABLE [dbo].[BCA_Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_BCA_Bitacora_BCA_Servicios] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[BCA_Servicios] ([IdServicio])
GO
ALTER TABLE [dbo].[BCA_Bitacora] CHECK CONSTRAINT [FK_BCA_Bitacora_BCA_Servicios]
GO
ALTER TABLE [dbo].[BCA_Servicios_Detalle]  WITH CHECK ADD  CONSTRAINT [FK_BCA_Servicios_Detalle_BCA_Servicios] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[BCA_Servicios] ([IdServicio])
GO
ALTER TABLE [dbo].[BCA_Servicios_Detalle] CHECK CONSTRAINT [FK_BCA_Servicios_Detalle_BCA_Servicios]
GO
ALTER TABLE [dbo].[Bitacora_IngenieriaSeguridad]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_IngenieriaSeguridad_Categorias_IngenieriaSeguridad] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias_IngenieriaSeguridad] ([IdCategoria])
GO
ALTER TABLE [dbo].[Bitacora_IngenieriaSeguridad] CHECK CONSTRAINT [FK_Bitacora_IngenieriaSeguridad_Categorias_IngenieriaSeguridad]
GO
ALTER TABLE [dbo].[Bitacora_IngenieriaSeguridad]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_IngenieriaSeguridad_Empresas_IngenieriaSeguridad] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresas_IngenieriaSeguridad] ([IdEmpresa])
GO
ALTER TABLE [dbo].[Bitacora_IngenieriaSeguridad] CHECK CONSTRAINT [FK_Bitacora_IngenieriaSeguridad_Empresas_IngenieriaSeguridad]
GO
USE [master]
GO
ALTER DATABASE [BD_SeguridadInformatica] SET  READ_WRITE 
GO
