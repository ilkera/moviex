CREATE database MovieDB

CREATE TABLE [dbo].[Location]
(
	[locationId] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(500) NULL, 
    [longitude] FLOAT NOT NULL, 
    [latitude] FLOAT NOT NULL, 
    [funfacts] NTEXT NULL
)

CREATE TABLE [dbo].[Movie]
(
	[movieId] INT NOT NULL PRIMARY KEY, 
    [title] NVARCHAR(200) NOT NULL, 
    [releaseYear] INT NOT NULL, 
    [productionCompany] NVARCHAR(100) NULL, 
    [distributor] NVARCHAR(100) NULL, 
    [director] NVARCHAR(100) NULL, 
    [writer] NVARCHAR(100) NULL, 
    [actor1] NVARCHAR(50) NULL, 
    [actor2] NVARCHAR(50) NULL, 
    [actor3] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[MovieLocation]
(
	[locationId] INT NOT NULL , 
    [movieId] INT NOT NULL, 
    PRIMARY KEY ([locationId], [movieId]), 
    CONSTRAINT [FK_MovieLocation_Movie] FOREIGN KEY ([movieId]) REFERENCES [dbo].[Movie]([movieId]),
	CONSTRAINT [FK_MovieLocation_Location] FOREIGN KEY ([locationId]) REFERENCES [dbo].[Location]([locationId])
)
