CREATE PROC [dbo].[uspNegotiationStrategySettingsSelect] 
    @NegotiationStrategySettingsID UNIQUEIDENTIFIER
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [NegotiationStrategySettingsID], [NegotiationID], [DefaultStartDate], [DefaultEndDate], [BetaValue], [StrategyTypeID], [Deleted], [DeletedBy], [DeletedOn] 
	FROM   [dbo].[NegotiationStrategySettings] 
	WHERE  ([NegotiationStrategySettingsID] = @NegotiationStrategySettingsID OR @NegotiationStrategySettingsID IS NULL) 

	COMMIT