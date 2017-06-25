CREATE PROC [dbo].[uspConversationStrategySettingsDelete] 
    @ConversationStrategySettingsID uniqueidentifier
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[ConversationStrategySettings]
	SET [Deleted] = 1, [DeletedOn] = GETDATE()
	WHERE  [ConversationStrategySettingsID] = @ConversationStrategySettingsID

	COMMIT