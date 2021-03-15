CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(50) NOT NULL,
	[Price] money NOT NULL
)
