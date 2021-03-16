CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(50) NOT NULL,
	[Email] nvarchar(50) NOT NULL,
	[CompanyID] int NULL REFERENCES Companies(Id)
)
