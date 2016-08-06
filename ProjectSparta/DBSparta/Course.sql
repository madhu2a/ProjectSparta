CREATE TABLE [dbo].[Course]
(
	[CourseId] INT NOT NULL , 
    [CourseName] VARCHAR(150) NOT NULL, 
    [CourseDesc] VARCHAR(MAX) NULL, 
    [Duration] DECIMAL(18, 2) NULL, 
    CONSTRAINT [PK_Course] PRIMARY KEY ([CourseId])
)

GO

CREATE INDEX [IX_Course_CourseId] ON [dbo].[Course] ([CourseId])
