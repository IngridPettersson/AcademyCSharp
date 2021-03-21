CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Username] nvarchar(32) NOT NULL,
	[Password] nvarchar(64) NOT NULL
)
