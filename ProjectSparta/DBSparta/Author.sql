CREATE TABLE [dbo].[Author]
(
	[AuthorId] INT NOT NULL , 
    [Name] VARCHAR(50) NULL, 
    [Designation] VARCHAR(50) NULL, 
    [Qualification] VARCHAR(50) NULL, 
    [Rating] FLOAT NULL, 
    [Description] VARCHAR(250) NULL, 
    CONSTRAINT [PK_Author] PRIMARY KEY ([AuthorId])
)
