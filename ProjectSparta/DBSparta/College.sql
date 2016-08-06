CREATE TABLE [dbo].[College]
(
	[CollegeId] INT NOT NULL , 
    [Name] VARCHAR(100) NULL, 
    [StateId] INT NOT NULL, 
    [Address] VARCHAR(MAX) NULL, 
    [DistrictId] INT NOT NULL, 
    CONSTRAINT [PK_College] PRIMARY KEY ([CollegeId]), 
    CONSTRAINT [FK_College_District] FOREIGN KEY ([DistrictId]) REFERENCES [District]([DistrictId]),
	CONSTRAINT [FK_College_State] FOREIGN KEY ([StateId]) REFERENCES [State]([StateId])
)
