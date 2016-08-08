CREATE TABLE [dbo].[State]
(
	[StateId] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(50) NULL, 
    [CountryId] INT NOT NULL, 
	CONSTRAINT [PK_State] PRIMARY KEY ([StateId]),
    CONSTRAINT [FK_State_Country] FOREIGN KEY ([CountryId]) REFERENCES [Country]([CountryId])
	ON DELETE CASCADE    
)

GO

CREATE INDEX [IX_State_StateId] ON [dbo].[State] ([StateId])
