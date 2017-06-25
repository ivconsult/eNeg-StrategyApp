CREATE PROC [dbo].[uspConversationStrategySettingsInsert] 
    @ConversationStrategySettingsID uniqueidentifier,
    @ConversationID uniqueidentifier,
    @StartDate datetime,
    @EndDate datetime,
    @BetaValue decimal(18, 2),
    @StrategyTypeID int,
    @NegotiationStrategySettingsID uniqueidentifier,
    @Deleted bit,
    @DeletedBy uniqueidentifier,
    @DeletedOn datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[ConversationStrategySettings] ([ConversationStrategySettingsID], [ConversationID], [StartDate], [EndDate], [BetaValue], [StrategyTypeID], [NegotiationStrategySettingsID], [Deleted], [DeletedBy], [DeletedOn])
	SELECT @ConversationStrategySettingsID, @ConversationID, @StartDate, @EndDate, @BetaValue, @StrategyTypeID, @NegotiationStrategySettingsID, @Deleted, @DeletedBy, @DeletedOn
	
	-- Begin Return Select <- do not remove
	SELECT [ConversationStrategySettingsID], [ConversationID], [StartDate], [EndDate], [BetaValue], [StrategyTypeID], [NegotiationStrategySettingsID], [Deleted], [DeletedBy], [DeletedOn]
	FROM   [dbo].[ConversationStrategySettings]
	WHERE  [ConversationStrategySettingsID] = @ConversationStrategySettingsID
	-- End Return Select <- do not remove
               
	COMMIT