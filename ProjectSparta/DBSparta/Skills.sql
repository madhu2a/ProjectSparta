CREATE TABLE [dbo].[Skills]
(
	[SkillId] INT NOT NULL , 
    [Name] VARCHAR(50) NULL, 
    [Recognition] VARCHAR(50) NULL, 
    [Description] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Skills] PRIMARY KEY ([SkillId])
)
