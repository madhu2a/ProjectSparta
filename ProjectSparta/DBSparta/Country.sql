CREATE TABLE [dbo].[Country]
(
	[CountryId] INT NOT NULL IDENTITY , 
    [Name] VARCHAR(50) NULL, 
    [Region] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Country] PRIMARY KEY ([CountryId]), 
)
