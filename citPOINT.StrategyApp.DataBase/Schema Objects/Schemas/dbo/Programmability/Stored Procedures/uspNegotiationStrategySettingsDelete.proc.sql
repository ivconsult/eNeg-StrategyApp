CREATE PROC [dbo].[uspNegotiationStrategySettingsDelete] 
    @NegotiationStrategySettingsID uniqueidentifier
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[NegotiationStrategySettings]
	SET [Deleted] = 1, [DeletedOn] = GETDATE()
	WHERE  [NegotiationStrategySettingsID] = @NegotiationStrategySettingsID

	COMMIT
