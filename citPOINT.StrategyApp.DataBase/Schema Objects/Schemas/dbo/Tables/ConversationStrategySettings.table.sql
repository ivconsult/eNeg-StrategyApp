CREATE TABLE [dbo].[ConversationStrategySettings]
(
	ConversationStrategySettingsID UNIQUEIDENTIFIER PRIMARY KEY , 
	ConversationID UNIQUEIDENTIFIER NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	BetaValue DECIMAL(18,2),
	StrategyTypeID INT REFERENCES StrategyType(StrategyTypeID) NOT NULL,
	NegotiationStrategySettingsID UNIQUEIDENTIFIER REFERENCES NegotiationStrategySettings(NegotiationStrategySettingsID), 
	Deleted BIT,
	DeletedBy UNIQUEIDENTIFIER,
	DeletedOn DATETIME
)
