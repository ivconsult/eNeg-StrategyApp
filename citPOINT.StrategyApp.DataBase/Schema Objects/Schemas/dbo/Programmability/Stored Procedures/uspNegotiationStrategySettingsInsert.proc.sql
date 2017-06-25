CREATE PROC [dbo].[uspNegotiationStrategySettingsInsert] 
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
	
	INSERT INTO [dbo].[NegotiationStrategySettings] ([NegotiationStrategySettingsID], [NegotiationID], [DefaultStartDate], [DefaultEndDate], [BetaValue], [StrategyTypeID], [Deleted], [DeletedBy], [DeletedOn])
	SELECT @NegotiationStrategySettingsID, @NegotiationID, @DefaultStartDate, @DefaultEndDate, @BetaValue, @StrategyTypeID, @Deleted, @DeletedBy, @DeletedOn
	
	-- Begin Return Select <- do not remove
	SELECT [NegotiationStrategySettingsID], [NegotiationID], [DefaultStartDate], [DefaultEndDate], [BetaValue], [StrategyTypeID], [Deleted], [DeletedBy], [DeletedOn]
	FROM   [dbo].[NegotiationStrategySettings]
	WHERE  [NegotiationStrategySettingsID] = @NegotiationStrategySettingsID
	-- End Return Select <- do not remove
               
	COMMIT