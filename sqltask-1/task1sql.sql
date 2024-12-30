use DemoApp;
CREATE TABLE User2(
Personid int IDENTITY(1,1) PRIMARY KEY ,
Name varchar(50) NOT NULL,
Surname varchar(60) NOT NULL,
Email varchar(120) UNIQUE,
RegistrationDate date DEFAULT GETDATE(),
ContactNumber int DEFAULT('+994000000000'),
Age int CHECK(Age>18),
Adress varchar(250),
CONSTRAINT CHCKPERSON CHECK(RegistrationDate < GETDATE())
)


INSERT INTO User2(Name,Surname,Email,ContactNumber,Age,Adress)
VALUES('Konul','Huseynli','konlrh@code.edu.az','+994543212',19,'Bakixanov'),
('Gunay','Huseynov','gunei@gmail.com.','+994513298',22,'Yasamal'),
('Aysun','Huseynli','aysunvh@code.edu.az','+994552387',19,'Genclik')

CREATE TABLE Categories(
Categoryid int IDENTITY(1,1) PRIMARY KEY ,
Name varchar(50) NOT NULL,
Slug varchar(80) UNIQUE,
CreatedAt date CHECK(CreatedAt<GETDATE()) DEFAULT GETDATE(),
IsActive bit
)
INSERT INTO Categories(Name,Slug,CreatedAt,IsActive)
VALUES('Murad','1','2022-10-9',0),
('Aygun','2','2022-8-3',1),
('Filankes','3','2022-4-13',1)
SELECT Name,Surname, Email FROM User2;
SELECT Name,IsActive FROM Categories;