use Moviesapps
Create DATABASE Moviesapps

CREATE TABLE Directorsss(
Id int PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,
Surname VARCHAR(50)
)
CREATE TABLE Languagessss(
Id int PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,
)

CREATE TABLE Moviesss (
Id INT PRIMARY KEY Identity,
Name VARCHAR(70),
Description VARCHAR(80),
CoverPhoto Bit,
DirectorId Int FOREIGN KEY REFERENCES Directorsss(Id),
LanguageId INT FOREIGN KEY REFERENCES Languagessss(Id)
)

CREATE TABLE Genresss(
Id int PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,
)

CREATE TABLE Actorsss(
Id int PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,
Surname VARCHAR(50)
)

CREATE TABLE MovieWithActorsss(
Id int PRIMARY KEY IDENTITY,
MovieId INT FOREIGN KEY REFERENCES Moviesss(Id),
ActorId INT FOREIGN KEY REFERENCES Actorsss(Id)
)

CREATE TABLE MovieWithGenresss(
Id int PRIMARY KEY IDENTITY,
MovieId INT FOREIGN KEY  REFERENCES Moviesss(Id),
GenreId INT FOREIGN KEY REFERENCES Genresss(Id)
)

SELECT*FROM Actorsss
SELECT*FROM Genresss
SELECT*FROM Moviesss
SELECT*FROM Languagessss
SELECT*FROM MovieWithActorsss
SELECT*FROM MovieWithGenresss
SELECT*FROM Directorsss

INSERT INTO Directorsss
VALUES('Robert','Schwentke'),
('Scott','Thomson'),
('M.Night','Shyamalan'),
('joe','johnson')

INSERT INTO Languagessss
VALUES('Aze'),
('Eng'),
('Ru'),
('China')

INSERT INTO Moviesss
VALUES('Red','Red follows Frank Moses (Willis) t.. ',1,1,1),
('Fast & Furios','media franchise centered on..',1,2,2),
('Split','Three girls are kidnapped by a man.. ',1,3,2),
('Jumanji','The story revealed the jungle..',0,null,4)

INSERT INTO Genresss
VALUES('Adventure'),
('Action'),
('horror'),
('comedy')

INSERT INTO Actorsss
VALUES('Bruce','Willis'),
('Morgan','Freeman'),
('Dvayne','Johnson'),
('Karen','Gillen'),
('James','Mcavoy')

INSERT INTO MovieWithActorsss
VALUES(1,2),
(1,1),
(2,3),
(2,4),
(3,5),
(4,3)

INSERT INTO MovieWithGenresss
VALUES(1,2),
(2,1),
(2,2),
(3,3),
(4,1)
--1

CREATE OR ALTER PROCEDURE usp_GetAllFilmsLanguage @directorId  int
AS
SELECT M.Name AS MOVIENAEM, L.Name AS LANGUAGENAME FROM Moviesss AS M
INNER JOIN Languagessss AS L
On M.LanguageId=L.Id
WHERE M.DirectorId=@directorId
EXEC usp_GetAllFilmsLanguage @directorId = 1


--2

CREATE OR ALTER FUNCTION GetMoviesCountByLanguage (@languageId int=2)
RETURNS int
AS
BEGIN
RETURN (SELECT COUNT(*) FROM Moviesss AS M  WHERE M.LanguageId=@languageId)
END

SELECT * FROM Moviesss
SELECT dbo.GetMoviesCountByLanguage(default)

--3

CREATE OR ALTER PROCEDURE usp_GetAllFilmsDirectors  @genreId  int
AS
SELECT M.Name AS MOVIENAME, D.Name AS DirectorNAME FROM MovieWithGenresss AS MG
INNER JOIN Moviesss AS M ON M.Id=MG.MovieId
INNER JOIN Directorsss AS D ON M.DirectorId=D.Id
WHERE MG.GenreId= @genreId
EXEC usp_GetAllFilmsDirectors  @genreId  = 3

--4

CREATE OR ALTER FUNCTION GetMoviesAndDirectorsbyGenre (@actorId int=2)
RETURNS BIT
AS
BEGIN
DECLARE @BOOL BIT =0
if (SELECT COUNT(*) FROM MovieWithActorsss AS MA  WHERE MA.actorId=@actorId)>3 SELECT @BOOL=1
RETURN @BOOL
END

SELECT * FROM MovieWithActorsss
SELECT dbo.GetMoviesAndDirectorsbyGenre(default)


CREATE OR ALTER TRIGGER JoinTables ON Moviesss
AFTER INSERT
AS
BEGIN
	SELECT M.Name,M.Description,M.CoverPhoto, M.DirectorId,M.LanguageId, D.Name ,L.Name  FROM Moviesss AS M
	INNER JOIN Directorsss AS D ON M.DirectorId=D.Id
	INNER JOIN Languagessss AS L ON M.LanguageId=L.Id
END
INSERT INTO Moviesss
VALUES('Teen-wolf','actionfilm','true','2','1')

SELECT*FROM Moviesss
