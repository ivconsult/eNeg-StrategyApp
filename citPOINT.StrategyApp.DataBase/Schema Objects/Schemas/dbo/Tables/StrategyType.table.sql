CREATE TABLE [dbo].[StrategyType]
(
	StrategyTypeID int primary key, 
	StrategyTypeName nvarchar(200) not null,
	Beta decimal(18,2)
)
