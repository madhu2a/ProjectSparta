CREATE TABLE [dbo].[Country]
(
	[CountryId] INT NOT NULL , 
    [Name] NCHAR(10) NULL, 
    [Region] NCHAR(10) NULL, 
    CONSTRAINT [PK_Country] PRIMARY KEY ([CountryId])
)
