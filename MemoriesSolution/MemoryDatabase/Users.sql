CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Username] nvarchar(32) NOT NULL,
	[Password] nvarchar(64) NOT NULL
)
