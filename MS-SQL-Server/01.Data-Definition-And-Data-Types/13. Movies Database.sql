CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY(1,1),
DirectorName VARCHAR(30) NOT NULL,
Notes TEXT
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY(1,1),
GenreName VARCHAR(30) NOT NULL,
Notes TEXT
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName VARCHAR(30) NOT NULL,
Notes TEXT
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY(1,1),
Title VARCHAR(30) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT,
[Length] FLOAT,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating FLOAT,
Notes TEXT
)

INSERT INTO Directors(DirectorName)
VALUES ('Ala'),
	   ('Bala'),
	   ('Tra'),
	   ('La'),
	   ('Laa')

INSERT INTO Genres(GenreName)
VALUES ('GAla'),
	   ('GBala'),
	   ('GTra'),
	   ('GLa'),
	   ('GLaa')

INSERT INTO Categories(CategoryName)
VALUES ('CAla'),
	   ('CBala'),
	   ('CTra'),
	   ('CLa'),
	   ('CLaa')

INSERT INTO Movies(Title)
VALUES ('MAla'),
	   ('MBala'),
	   ('MTra'),
	   ('MLa'),
	   ('MLaa')