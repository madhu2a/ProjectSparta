CREATE TABLE [dbo].[District]
(
	[DistrictId] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(50) NULL, 
    [StateId] INT NOT NULL,
	CONSTRAINT [PK_District] PRIMARY KEY ([DistrictId]),
    CONSTRAINT [FK_District_State] FOREIGN KEY ([StateId]) REFERENCES [State]([StateId]) ON DELETE NO ACTION ON UPDATE NO ACTION
)
