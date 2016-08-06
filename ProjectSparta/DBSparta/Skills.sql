CREATE TABLE [dbo].[Skills]
(
	[SkillId] INT NOT NULL , 
    [Name] VARBINARY(50) NULL, 
    [Recognition] VARBINARY(50) NULL, 
    [Description] VARBINARY(50) NULL, 
    CONSTRAINT [PK_Skills] PRIMARY KEY ([SkillId])
)
