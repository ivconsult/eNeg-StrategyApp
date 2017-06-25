CREATE PROC [dbo].[uspNegotiationStrategySettingsUpdate] 
    @NegotiationStrategySettingsID uniqueidentifier,
    @NegotiationID uniqueidentifier,
    @DefaultStartDate datetime,
    @DefaultEndDate datetime,
    @BetaValue decimal(18, 2),
    @StrategyTypeID int,
    @Deleted bit,
    @DeletedBy uniqueidentifier,
    @DeletedOn datetime
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[NegotiationStrategySettings]
	SET    [NegotiationStrategySettingsID] = @NegotiationStrategySettingsID, [NegotiationID] = @NegotiationID, [DefaultStartDate] = @DefaultStartDate, [DefaultEndDate] = @DefaultEndDate, [BetaValue] = @BetaValue, [StrategyTypeID] = @StrategyTypeID, [Deleted] = @Deleted, [DeletedBy] = @DeletedBy, [DeletedOn] = @DeletedOn
	WHERE  [NegotiationStrategySettingsID] = @NegotiationStrategySettingsID
	
	-- Begin Return Select <- do not remove
	SELECT [NegotiationStrategySettingsID], [NegotiationID], [DefaultStartDate], [DefaultEndDate], [BetaValue], [StrategyTypeID], [Deleted], [DeletedBy], [DeletedOn]
	FROM   [dbo].[NegotiationStrategySettings]
	WHERE  [NegotiationStrategySettingsID] = @NegotiationStrategySettingsID	
	-- End Return Select <- do not remove

	COMMIT TRAN