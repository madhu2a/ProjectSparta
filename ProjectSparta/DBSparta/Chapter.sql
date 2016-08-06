CREATE TABLE [dbo].[Chapter]
(
	[ChapterId] INT NOT NULL , 
    [ChapterName] VARCHAR(100) NULL, 
    [Duration] DECIMAL(18, 2) NULL, 
    [CourseId] INT NOT NULL, 
    CONSTRAINT [PK_Chapter] PRIMARY KEY ([ChapterId]), 
    CONSTRAINT [FK_Chapter_Course] FOREIGN KEY ([CourseId]) REFERENCES [Course]([CourseId])
)

GO

CREATE INDEX [IX_Chapter_ChapterId] ON [dbo].[Chapter] ([ChapterId])
