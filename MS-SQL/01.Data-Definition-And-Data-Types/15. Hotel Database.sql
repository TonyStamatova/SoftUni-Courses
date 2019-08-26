CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(10) NOT NULL, 
LastName VARCHAR(20) NOT NULL,
Title VARCHAR(20),
Notes TEXT
)

CREATE TABLE Customers(
AccountNumber VARCHAR(15) PRIMARY KEY NOT NULL,
FirstName VARCHAR(10) NOT NULL, 
LastName VARCHAR(20) NOT NULL,
PhoneNumber VARCHAR(20),
EmergencyName VARCHAR(30),
EmergencyNumber VARCHAR(20),
Notes TEXT
)

CREATE TABLE RoomStatus(
RoomStatus VARCHAR(10) PRIMARY KEY NOT NULL,
Notes TEXT
)

CREATE TABLE RoomTypes(
RoomType VARCHAR(10) PRIMARY KEY NOT NULL,
Notes TEXT
)

CREATE TABLE BedTypes(
BedType VARCHAR(10) PRIMARY KEY NOT NULL,
Notes TEXT
)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY IDENTITY(1,1),
RoomType VARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType VARCHAR(10) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate FLOAT,
RoomStatus VARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes TEXT
)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATETIME2,
AccountNumber VARCHAR(15) FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
FirstDateOccupied DATETIME2,
LastDateOccupied DATETIME2,
TotalDays INT,
AmountCharged MONEY,
TaxRate VARCHAR(10),
TaxAmount MONEY,
PaymentTotal MONEY NOT NULL,
Notes TEXT
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATETIME2,
AccountNumber VARCHAR(15) FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied VARCHAR(10),
PhoneCharge MONEY,
Notes TEXT
)

INSERT INTO Employees (FirstName, LastName)
VALUES ('John', 'Smith'),
       ('Keanu', 'Reeves'),
	   ('Marshall', 'Mathers')

INSERT INTO Customers(AccountNumber, FirstName, LastName)
VALUES ('ASS65645SXS5', 'John', 'Smith'),
       ('ASS65645SXS3', 'Keanu', 'Reeves'),
	   ('ASSDD645SXS4', 'Marshall', 'Mathers')

INSERT INTO RoomStatus(RoomStatus)
VALUES ('Occupied'),
       ('Vacant'),
	   ('Ready')

INSERT INTO RoomTypes(RoomType)
VALUES ('Suite'),
       ('Single'),
	   ('Double')

INSERT INTO BedTypes(BedType)
VALUES ('Couch'),
       ('Single'),
	   ('Double')

INSERT INTO Rooms(RoomType)
VALUES ('Suite'),
       ('Single'),
	   ('Suite')

INSERT INTO Payments(EmployeeId, AccountNumber, PaymentTotal)
VALUES (3, 'ASS65645SXS3', 16650.60),
       (1, 'ASSDD645SXS4', 19020.60),
	   (2, 'ASS65645SXS5', 17000.60)

INSERT INTO Occupancies(EmployeeId, AccountNumber, RoomNumber)
VALUES (3, 'ASS65645SXS3', 2),
       (1, 'ASSDD645SXS4', 1),
	   (2, 'ASS65645SXS5', 3)