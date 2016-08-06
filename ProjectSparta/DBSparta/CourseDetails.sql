CREATE TABLE [dbo].[CourseDetails]
(
	[CourseId] INT NOT NULL , 
    [AuthorId] INT NULL, 
    [Level] VARCHAR(50) NULL, 
    [DateOfAdd] DATETIME NULL, 
    [Duration] VARCHAR(50) NULL, 
    [Rating] FLOAT NULL, 
    CONSTRAINT [FK_CourseDetails_Course] FOREIGN KEY ([CourseId]) REFERENCES [Course]([CourseId]), 
    CONSTRAINT [FK_CourseDetails_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Author]([AuthorId]),

)
