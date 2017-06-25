CREATE PROC [dbo].[uspConversationStrategySettingsSelect] 
    @ConversationStrategySettingsID UNIQUEIDENTIFIER
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ConversationStrategySettingsID], [ConversationID], [StartDate], [EndDate], [BetaValue], [StrategyTypeID], [NegotiationStrategySettingsID], [Deleted], [DeletedBy], [DeletedOn] 
	FROM   [dbo].[ConversationStrategySettings] 
	WHERE  ([ConversationStrategySettingsID] = @ConversationStrategySettingsID OR @ConversationStrategySettingsID IS NULL) 

	COMMIT