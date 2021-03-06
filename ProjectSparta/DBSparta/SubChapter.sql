﻿CREATE TABLE [dbo].[SubChapter]
(
	[SubChapterId] INT NOT NULL IDENTITY, 
    [SubChapterName] VARCHAR(50) NULL, 
    [Duration] DECIMAL(18, 2) NULL, 
    [ChapterId] INT NULL, 
    CONSTRAINT [PK_SubChapter] PRIMARY KEY ([SubChapterId]), 
    CONSTRAINT [FK_SubChapter_ToTable] FOREIGN KEY ([ChapterId]) REFERENCES [Chapter]([ChapterId])
	ON DELETE CASCADE
)

GO

CREATE INDEX [IX_SubChapter_SubChapterId] ON [dbo].[SubChapter] ([SubChapterId])
