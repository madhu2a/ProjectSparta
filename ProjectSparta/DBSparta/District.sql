CREATE TABLE [dbo].[District]
(
	[DistrictId] INT NOT NULL , 
    [Name] VARCHAR(50) NULL, 
    [StateId] INT NOT NULL,
	CONSTRAINT [PK_District] PRIMARY KEY ([DistrictId]),
    CONSTRAINT [FK_District_State] FOREIGN KEY ([StateId]) REFERENCES [State]([StateId])
)
