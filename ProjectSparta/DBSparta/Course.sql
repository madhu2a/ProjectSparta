CREATE TABLE [dbo].[Course]
(
	[CourseId] INT NOT NULL PRIMARY KEY, 
    [CourseName] VARCHAR(150) NOT NULL, 
    [CourseDesc] VARCHAR(MAX) NULL, 
    [Duration] DECIMAL(18, 2) NULL
)
