CREATE TABLE [dbo].[NegotiationStrategySettings]
(
	NegotiationStrategySettingsID UNIQUEIDENTIFIER PRIMARY KEY, 
	NegotiationID UNIQUEIDENTIFIER NOT NULL,
	DefaultStartDate DATETIME NOT NULL,
	DefaultEndDate DATETIME NOT NULL,
	BetaValue DECIMAL(18,2),
	StrategyTypeID INT REFERENCES StrategyType(StrategyTypeID) NOT NULL,
	Deleted BIT,
	DeletedBy UNIQUEIDENTIFIER,
	DeletedOn DATETIME
)
