CREATE DATABASE DemoApps
use DemoApps
CREATE TABLE Countries
(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,
Area decimal
)

CREATE TABLE Cities
(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,
Area decimal,
CountryId int FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50),
Surname VARCHAR(50),
PhoneNumber VARCHAR(20),
Email  VARCHAR(40),
Age INT CHECK(Age>0),
Gender varchar(20),
HasCitizenship BIT,
CityId int FOREIGN KEY REFERENCES Cities(Id)
)

INSERT INTO Countries
VALUES('Azerbaycan',4567.9),
('Turkiye',1234.5),
('Italya',5468.2),
('Polsa',8976.2),
('Avstrya',123.5)

INSERT INTO Cities
VALUES('barda',87.9,1),
('varsava',76.8,4),
('Milano',98.4,3),
('gence',54.2,1),
('banqlades',23.2,null)

INSERT INTO People
VALUES('konul','huseynli','+994516764323','konul@gmail.com',19,'Female',1,1),
('aysun','huseynli','+994553247898','aysun@code.edu.az',19,'Female',1,1),
('mehemmed','quliyev','+994506754356','maqa@gmail.com',20,'Male',0,4),
('JANE','JACKSON','+11245678','JANE02@MAIL.RU',34,'Female',1,2)
--2
SELECT * FROM Countries
ORDER BY Area;
SELECT * FROM Cities
ORDER BY Name DESC;
--3
SELECT COUNT(*)
FROM Countries
WHERE Area > 5000 AND Name LIKE '%A%';  
GO  
--4
SELECT Name FROM Countries
UNION ALL
SELECT Name FROM Cities;

--5
SELECT CT.Name, COUNT(CityID) AS PersonCount
FROM Cities AS CT
INNER JOIN People AS P
ON CT.Id=P.CityId
GROUP BY CT.Name

--1.1
SELECT P.Name 'PersonName',CT.Name 'CountryName',C.Name 'CitiesName'
FROM Countries AS CT
INNER JOIN Cities AS C
ON CT.Id=C.CountryId
INNER JOIN People AS P
ON C.Id=P.CityId

--1.2

CREATE VIEW PersonfromCityCountry
AS
SELECT P.Name 'PersonName',CT.Name 'CountryName',C.Name 'CitiesName'
FROM Countries AS CT
INNER JOIN Cities AS C
ON CT.Id=C.CountryId
INNER JOIN People AS P
ON C.Id=P.CityId
SELECT *FROM PersonfromCityCountry