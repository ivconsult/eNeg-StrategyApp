/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


/*-----------------------------------------------
	[StrategyType] Script
-------------------------------------------------*/

IF NOT EXISTS (SELECT * FROM [dbo].[StrategyType])

BEGIN

	BEGIN TRANSACTION;
	INSERT INTO [dbo].[StrategyType]([StrategyTypeID],[StrategyTypeName],[Beta])
	SELECT 1,N'Neutral',1 UNION ALL
	SELECT 2,N'Conceder Light',2 UNION ALL
	SELECT 3,N'Conceder Strong',5 UNION ALL
	SELECT 4,N'Boulware Light',0.8 UNION ALL
	SELECT 5,N'Boulware Strong',0.5 UNION ALL
	SELECT 6,N'Other',0
	COMMIT;
	RAISERROR (N'[dbo].[StrategyType]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
End
GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'StrategyAppUser')
DROP USER [StrategyAppUser]
GO

/****** Object:  Login [StrategyAppUser]    Script Date: 08/25/2010 10:31:45 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'StrategyAppUser')
DROP LOGIN [StrategyAppUser]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [StrategyAppUser]   Script Date: 08/25/2010 10:31:45 ******/
CREATE LOGIN [StrategyAppUser] WITH PASSWORD='StrategyAppUserPassword', DEFAULT_DATABASE=[StrategyApp], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

 
CREATE USER [StrategyAppUser] FOR LOGIN [StrategyAppUser] 
GO


EXEC sp_addrolemember N'db_owner', N'StrategyAppUser'
go
