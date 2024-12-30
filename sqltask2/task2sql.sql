use DrugstoreApp
CREATE TABLE Drugs(
Id INT PRIMARY KEY IDENTITY,
Name varchar(50),
Price float,
Count int,
DrugStoreId int FOREIGN KEY REFERENCES DrugStores
)
CREATE TABLE Druggists(
Id int PRIMARY KEY IDENTITY,
Name varchar(50),
Surname varchar(50),
Age int,
Experience varchar(100),
DrugStoreId int FOREIGN KEY REFERENCES DrugStores
)
 CREATE TABLE DrugStores(
 Id int PRIMARY KEY IDENTITY,
 Name varchar(50),
 Adress varchar(80),
 Contactnumber varchar(40),
 Creationdate date,
OwnerId int FOREIGN KEY REFERENCES Owners
 )

 CREATE TABLE Owners(
 Id int PRIMARY KEY IDENTITY,
 Name varchar(50),
 Surname varchar(50),
 )
  SELECT*FROM Druggists
  SElECT*FROM Drugs
  SELECT*FROM Owners
  SELECT*FROM DrugStores

  INSERT INTO Drugs
  VALUES('nimesil',0.50,4,1),
  ('Spazmalqon',1.20,8,2);

  INSERT INTO Druggists
  VALUES('Gunay','Huseynli',22,'Zeferan aptekde',1),
  ('Aysun','Huseynli',19,'yoxdur',2);

  INSERT INTO DrugStores
  VALUES('Canon','Bakixanov','+99455432132','2001-12-03',1),
        ('Zefer','Genclik','+994517544354','1987-7-04',2);


INSERT INTO Owners
VALUES('Konul','Huseynli')
