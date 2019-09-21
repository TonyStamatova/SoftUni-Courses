CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText VARCHAR(40) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(10) NOT NULL,
MiddleName VARCHAR(10),
LastName VARCHAR(10),
JobTitle VARCHAR(20) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATETIME,
Salary DECIMAL(15,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns([Name])
VALUES ('Sofia'),
       ('Plovdiv'),
       ('Varna'),
       ('Burgas')

INSERT INTO Departments([Name])
VALUES ('Engineering'),
       ('Sales'),
	   ('Marketing'),
       ('Software Development'),
       ('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, 01/02/2013, 3500.00),
       ('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, 02/03/2004, 4000.00),
	   ('Maria', 'Petrova', 'Ivanova', 'Intern', 5, 28/08/2016, 525.25),
       ('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, 09/12/2007, 3000.00),
       ('Peter', 'Pan', 'Pan', 'Intern', 3, 28/08/2016, 599.88)

SELECT * FROM Towns

SELECT * FROM Departments 

SELECT * FROM Employees 