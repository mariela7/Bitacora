USE [master]
GO
/****** Object:  Database [BD_SeguridadInformatica]    Script Date: 05/10/2015 12:29:47 ******/
CREATE DATABASE [BD_SeguridadInformatica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_SeguridadInformatica', FILENAME = N'E:\SQL_Data\BD_SeguridadInformatica.mdf' , SIZE = 18432KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BD_SeguridadInformatica_log', FILENAME = N'E:\SQL_Logs\BD_SeguridadInformatica_log.ldf' , SIZE = 4224KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
USE [BD_SeguridadInformatica]
GO
/****** Object:  User [usrpddor]    Script Date: 05/10/2015 12:29:47 ******/
CREATE USER [usrpddor] FOR LOGIN [usrpddor] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [UIO\usradsql]    Script Date: 05/10/2015 12:29:47 ******/
CREATE USER [UIO\usradsql] FOR LOGIN [UIO\usradsql] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [UIO\GF_IngenieriaSeguridad_UIO]    Script Date: 05/10/2015 12:29:47 ******/
CREATE USER [UIO\GF_IngenieriaSeguridad_UIO] FOR LOGIN [UIO\GF_IngenieriaSeguridad_UIO] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [UIO\GF_IngenieriaSeguridad_UIO]
GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_SelectLista]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_SelectLista] 
@IdLista int
as
SELECT [Id_Lista]
      ,[Valor]
  FROM [BD_SeguridadInformatica].[dbo].[Listas]
  where [Id_Lista] = @IdLista

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_SelectServicios]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_SelectServicios]
as

SELECT [Id]
      ,[Nombre]
      ,[AuditUser]
      ,[AuditFecha]
      ,[AuditMachine]
  FROM [BD_SeguridadInformatica].[dbo].[BCA_Servicios]
  order by Nombre


GO
/****** Object:  StoredProcedure [dbo].[Bitacora_CertificacionApp_SelectServiciosDetalles]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Bitacora_CertificacionApp_SelectServiciosDetalles] 
@Id_Servicio int
as

SELECT [IdServicio]
      ,[Orden]
      ,[Nombre]
      ,[Tipo]
      ,[EsLista]
      ,[IdLista]
  FROM [BD_SeguridadInformatica].[dbo].[BCA_Servicios_Detalle]
  where IdServicio = @Id_Servicio


GO
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_Delete]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_Insert]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectAll]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByEmpresa_User]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaFin_User]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByFechaInicio_User]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByIdResgistro]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByMes]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByMes_User]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByResponsable]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectByServicio_User]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_SelectVariosFiltros]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_IngenieriaSeguridad_Update]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_Delete]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_Insert]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_SelectAll]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_SelectbyDescripcion]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_SelectbyId]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Categorias_IngenieriaSeguridad_Update]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_Delete]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_Insert]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_SelectAll]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_SelectByIdEmpresa]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_SelectbyNombreEmpresa]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Empresas_IngenieriaSeguridad_Update]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[LogsConexion_Insert]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerAno]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  StoredProcedure [dbo].[Plataforma_CertificacionAplicaciones_Delete]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Plataforma_CertificacionAplicaciones_Delete]
	-- Add the parameters for the stored procedure here
	@IdPlataforma int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		DELETE FROM [BD_SeguridadInformatica].[dbo].[Plataforma_CertificacionAplicaciones]
		WHERE [IdPlataforma] = @IdPlataforma

		SET @Id = @IdPlataforma

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdPlataforma'
END

GO
/****** Object:  StoredProcedure [dbo].[Plataforma_CertificacionAplicaciones_Insert]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Plataforma_CertificacionAplicaciones_Insert]
	-- Add the parameters for the stored procedure here
	@DescripcionPlataforma varchar(200),
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

		INSERT INTO [BD_SeguridadInformatica].[dbo].[Plataforma_CertificacionAplicaciones]
			   ([DescripcionPlataforma]
			   ,[Audit_User]
			   ,[Audit_FechaUltimaModificacion]
			   ,[Audit_IpUsuario])
		 VALUES
			   (@DescripcionPlataforma,
			   @Audit_User,
			   GETDATE(),
			   @Audit_IpUsuario)

		SET @Id = (select MAX([IdPlataforma]) from [BD_SeguridadInformatica].[dbo].[Plataforma_CertificacionAplicaciones])

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdPlataforma'
END

GO
/****** Object:  StoredProcedure [dbo].[Plataforma_CertificacionAplicaciones_SelectAll]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Plataforma_CertificacionAplicaciones_SelectAll]
	-- Add the parameters for the stored procedure here
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdPlataforma],
		[DescripcionPlataforma],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Plataforma_CertificacionAplicaciones]
END

GO
/****** Object:  StoredProcedure [dbo].[Plataforma_CertificacionAplicaciones_SelectbyDescripcion]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Plataforma_CertificacionAplicaciones_SelectbyDescripcion]
	-- Add the parameters for the stored procedure here
	@DescripcionPlataforma varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdPlataforma],
		[DescripcionPlataforma],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Plataforma_CertificacionAplicaciones]
	WHERE [DescripcionPlataforma] LIKE '%' + @DescripcionPlataforma + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Plataforma_CertificacionAplicaciones_SelectbyId]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Plataforma_CertificacionAplicaciones_SelectbyId]
	-- Add the parameters for the stored procedure here
	@IdPlataforma int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdPlataforma],
		[DescripcionPlataforma],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Plataforma_CertificacionAplicaciones]
	WHERE [IdPlataforma] = @IdPlataforma
END

GO
/****** Object:  StoredProcedure [dbo].[Plataforma_CertificacionAplicaciones_Update]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Plataforma_CertificacionAplicaciones_Update]
	-- Add the parameters for the stored procedure here
	@IdPlataforma int,
	@DescripcionPlataforma varchar(200),
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

		UPDATE [BD_SeguridadInformatica].[dbo].[Plataforma_CertificacionAplicaciones]
		   SET [DescripcionPlataforma] = @DescripcionPlataforma,
			   [Audit_User] = @Audit_User,
			   [Audit_FechaUltimaModificacion] = GETDATE(),
			   [Audit_IpUsuario] = @Audit_IpUsuario
		 WHERE [IdPlataforma] = @IdPlataforma

		SET @Id = @IdPlataforma

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdPlataforma'
END

GO
/****** Object:  StoredProcedure [dbo].[Software_CertificacionAplicaciones_Delete]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Software_CertificacionAplicaciones_Delete]
	-- Add the parameters for the stored procedure here
	@IdSoftware int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Id INT = 0
	
	BEGIN TRANSACTION

	BEGIN TRY

		DELETE FROM [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones]
		WHERE [IdSoftware] = @IdSoftware

		SET @Id = @IdSoftware

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdSoftware'
END

GO
/****** Object:  StoredProcedure [dbo].[Software_CertificacionAplicaciones_Insert]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Software_CertificacionAplicaciones_Insert]
	-- Add the parameters for the stored procedure here
	@DescripcionSoftware varchar(200),
	@Tipo char(2),
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

		INSERT INTO [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones]
			   ([DescripcionSoftware]
			   ,[Tipo]
			   ,[Audit_User]
			   ,[Audit_FechaUltimaModificacion]
			   ,[Audit_IpUsuario])
		 VALUES
			   (@DescripcionSoftware,
			   @Tipo,
			   @Audit_User,
			   GETDATE(),
			   @Audit_IpUsuario)

		SET @Id = (select MAX([IdSoftware]) from [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones])

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdSoftware'
END

GO
/****** Object:  StoredProcedure [dbo].[Software_CertificacionAplicaciones_SelectAll]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Software_CertificacionAplicaciones_SelectAll]
	-- Add the parameters for the stored procedure here
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdSoftware],
		[DescripcionSoftware],
		[Tipo],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones]
END

GO
/****** Object:  StoredProcedure [dbo].[Software_CertificacionAplicaciones_SelectbyDescripcion]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Software_CertificacionAplicaciones_SelectbyDescripcion]
	-- Add the parameters for the stored procedure here
	@DescripcionSoftware varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdSoftware],
		[DescripcionSoftware],
		[Tipo],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones]
	WHERE [DescripcionSoftware] LIKE '%' + @DescripcionSoftware + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Software_CertificacionAplicaciones_SelectbyId]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Software_CertificacionAplicaciones_SelectbyId]
	-- Add the parameters for the stored procedure here
	@IdSoftware int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdSoftware],
		[DescripcionSoftware],
		[Tipo],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones]
	WHERE [IdSoftware] = @IdSoftware
END

GO
/****** Object:  StoredProcedure [dbo].[Software_CertificacionAplicaciones_SelectbyTipo]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Software_CertificacionAplicaciones_SelectbyTipo]
	-- Add the parameters for the stored procedure here
	@Tipo char(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [IdSoftware],
		[DescripcionSoftware],
		[Tipo],
		[Audit_User],
		[Audit_FechaUltimaModificacion],
		[Audit_IpUsuario]
	FROM [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones]
	WHERE [Tipo] = @Tipo
END

GO
/****** Object:  StoredProcedure [dbo].[Software_CertificacionAplicaciones_Update]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Software_CertificacionAplicaciones_Update]
	-- Add the parameters for the stored procedure here
	@IdSoftware int,
	@DescripcionSoftware varchar(200),
	@Tipo char(2),
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

		UPDATE [BD_SeguridadInformatica].[dbo].[Software_CertificacionAplicaciones]
		   SET [DescripcionSoftware] = @DescripcionSoftware,
			   [Tipo] = @Tipo,
			   [Audit_User] = @Audit_User,
			   [Audit_FechaUltimaModificacion] = GETDATE(),
			   [Audit_IpUsuario] = @Audit_IpUsuario
		 WHERE [IdSoftware] = @IdSoftware

		SET @Id = @IdSoftware

		COMMIT TRANSACTION
		   		
	END TRY
	BEGIN CATCH
		
		ROLLBACK TRANSACTION
		SET @Id = -1

	END CATCH

	SELECT @Id as 'IdSoftware'
END

GO
/****** Object:  Table [dbo].[BCA_Bitacora]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCA_Bitacora](
	[Id_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Esfuerzo] [decimal](18, 2) NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[Detalle] [xml] NOT NULL,
 CONSTRAINT [PK_BCA_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCA_Servicios]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BCA_Servicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[AuditUser] [varchar](50) NOT NULL,
	[AuditFecha] [datetime] NOT NULL,
	[AuditMachine] [varchar](20) NULL,
 CONSTRAINT [PK_BCA_Servicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BCA_Servicios_Detalle]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  Table [dbo].[Bitacora_IngenieriaSeguridad]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  Table [dbo].[Bitacora_SOySB_CertificacionAplicaciones]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora_SOySB_CertificacionAplicaciones](
	[IdRegistro] [int] IDENTITY(1,1) NOT NULL,
	[Identificador] [char](2) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Servidor] [varchar](max) NOT NULL,
	[Ip] [varchar](50) NOT NULL,
	[Rol] [varchar](max) NOT NULL,
	[Proyecto] [int] NOT NULL,
	[ODT] [varchar](10) NOT NULL,
	[Plataforma] [int] NOT NULL,
	[Software] [varchar](max) NOT NULL,
	[Revisiones] [int] NOT NULL,
	[VulnerabilidadesEncontradas] [int] NOT NULL,
	[VulnerabilidadesCerradas] [int] NOT NULL,
	[Estado] [varchar](30) NOT NULL,
	[Observaciones] [varchar](max) NULL,
	[ResponsableIS] [varchar](20) NOT NULL,
	[Esfuerzo] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Bitacora_SOySB_CertificacionAplicaciones] PRIMARY KEY CLUSTERED 
(
	[IdRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categorias_IngenieriaSeguridad]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  Table [dbo].[Empresas_IngenieriaSeguridad]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  Table [dbo].[HorasMes_Configuraciones]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  Table [dbo].[Listas]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Listas](
	[Id_Lista] [int] NOT NULL,
	[Valor] [varchar](300) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogsConexion]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  Table [dbo].[LogsTransaccion]    Script Date: 05/10/2015 12:29:48 ******/
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
/****** Object:  Table [dbo].[Plataforma_CertificacionAplicaciones]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Plataforma_CertificacionAplicaciones](
	[IdPlataforma] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionPlataforma] [varchar](200) NOT NULL,
	[Audit_User] [varchar](20) NOT NULL,
	[Audit_FechaUltimaModificacion] [datetime] NOT NULL,
	[Audit_IpUsuario] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Plataforma_CertificacionAplicaciones] PRIMARY KEY CLUSTERED 
(
	[IdPlataforma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Software_CertificacionAplicaciones]    Script Date: 05/10/2015 12:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Software_CertificacionAplicaciones](
	[IdSoftware] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionSoftware] [varchar](max) NOT NULL,
	[Tipo] [char](2) NOT NULL,
	[Audit_User] [varchar](20) NOT NULL,
	[Audit_FechaUltimaModificacion] [datetime] NOT NULL,
	[Audit_IpUsuario] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Software_CertificacionAplicaciones] PRIMARY KEY CLUSTERED 
(
	[IdSoftware] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Bitacora_IngenieriaSeguridad] ADD  CONSTRAINT [DF_Bitacora_IngenieriaSeguridad_HoraExtra]  DEFAULT ((0)) FOR [HoraExtra]
GO
ALTER TABLE [dbo].[LogsConexion] ADD  CONSTRAINT [DF_LogsConexion_FechaHora]  DEFAULT (getdate()) FOR [FechaHora]
GO
ALTER TABLE [dbo].[Plataforma_CertificacionAplicaciones] ADD  CONSTRAINT [DF_Plataforma_CertificacionAplicaciones_Audit_FechaUltimaModificacion]  DEFAULT (getdate()) FOR [Audit_FechaUltimaModificacion]
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
