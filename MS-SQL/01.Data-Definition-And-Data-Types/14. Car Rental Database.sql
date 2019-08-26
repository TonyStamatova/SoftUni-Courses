CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName VARCHAR(30) NOT NULL,
DailyRate MONEY,
WeeklyRate MONEY,
MonthlyRate MONEY,
WeekendRate MONEY
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY(1,1),
PlateNumber VARCHAR(10) CONSTRAINT CHK_Cars_PlateNumber_MinL CHECK (DATALENGTH(PlateNumber) >= 9) NOT NULL,
Manufacturer VARCHAR(15), 
Model VARCHAR(15),
CarYear INT,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT,
Picture VARBINARY(MAX),
Condition VARCHAR(MAX),
Available BIT NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(10) NOT NULL, 
LastName VARCHAR(20) NOT NULL,
Title VARCHAR(20),
Notes TEXT
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY(1,1),
DriverLicenceNumber VARCHAR(20) NOT NULL,
FullName VARCHAR(30) NOT NULL, 
[Address] VARCHAR(30),
City VARCHAR(15),
ZIPCode VARCHAR(10),
Notes TEXT
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
TankLevel FLOAT,
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage INT,
StartDate DATETIME2,
EndDate DATETIME2,
TotalDays INT,
RateApplied VARCHAR(10),
TaxRate MONEY,
OrderStatus VARCHAR(10),
Notes TEXT
)

INSERT INTO Categories (CategoryName)
VALUES ('SUV'),
       ('Sports car'),
	   ('Offroad')

INSERT INTO Cars (PlateNumber, Available)
VALUES ('CB 5020 CT', 0),
       ('CA 1234 BH', 1),
	   ('C 5678 CC', 1)

INSERT INTO Employees (FirstName, LastName)
VALUES ('John', 'Smith'),
       ('Keanu', 'Reeves'),
	   ('Marshall', 'Mathers')

INSERT INTO Customers (DriverLicenceNumber, FullName)
VALUES ('04155', 'John Smith'),
       ('665523', 'Keanu Reeves'),
	   ('12056512', 'Marshall Mathers')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId)
VALUES (1,1,1),
	   (2,2,2),
	   (3,3,3)	