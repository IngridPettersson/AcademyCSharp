CREATE TABLE [dbo].[Memories]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[MemoryHolder] nvarchar(50) NOT NULL,
	[PeopleInMemory] nvarchar(70) NULL,
	[MemoryTitle] nvarchar(70) NOT NULL,
	[WhenInWords] nvarchar(70) NULL,
	[Description] nvarchar(4000) NULL,
	[ImagePath] nvarchar(200) NULL,
	[HasImage] bit NULL,
	[AddedWhen] datetime NULL
)
