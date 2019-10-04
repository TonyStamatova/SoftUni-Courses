CREATE DATABASE Demo

USE Demo

-- Problem 01
  CREATE TABLE Passports(
    PassportID INT PRIMARY KEY IDENTITY(101, 1),
PassportNumber CHAR(8) NOT NULL)

  CREATE TABLE Persons(
      PersonID INT PRIMARY KEY IDENTITY(1, 1),
     FirstName NVARCHAR(50) NOT NULL,
        Salary MONEY,
    PassportID INT UNIQUE,
    CONSTRAINT FK_Persons_Passports 
   FOREIGN KEY (PassportID)  
    REFERENCES Passports(PassportID))
   
   INSERT INTO Passports (PassportNumber) 
        VALUES ('N34FG21B'),
               ('K65LO4R7'),
               ('ZE657QP2')
   
   INSERT INTO Persons (FirstName,	Salary,	PassportID) 
        VALUES ('Roberto', 43300.00, 102),
               ('Tom', 56100.00, 103),
               ('Yana', 60200.00, 101)
 
-- Problem 02
  CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY(1, 1),
        [Name] NVARCHAR(20) NOT NULL,
 EstablishedOn DATETIME)

  CREATE TABLE Models(
       ModelID INT PRIMARY KEY IDENTITY(101, 1),
        [Name] NVARCHAR(20) NOT NULL,
ManufacturerID INT,
    CONSTRAINT FK_Persons_Passports 
   FOREIGN KEY (ManufacturerID)  
    REFERENCES Manufacturers(ManufacturerID))

   INSERT INTO Manufacturers ([Name], EstablishedOn) 
        VALUES ('BMW', '07/03/1916'),
               ('Tesla', '01/01/2003'),
               ('Lada', '01/05/1966')
   
   INSERT INTO Models ([Name], ManufacturerID) 
        VALUES ('X1', 1),
               ('i6', 1),
               ('Model S', 2),
               ('Model X', 2),
               ('Model 3', 2),
               ('Nova', 3)

-- Problem 03
CREATE TABLE Students(
   StudentID INT PRIMARY KEY IDENTITY(1, 1),
      [Name] NVARCHAR(20) NOT NULL)

CREATE TABLE Exams(
      ExamID INT PRIMARY KEY IDENTITY(101, 1),
      [Name] NVARCHAR(20) NOT NULL)

CREATE TABLE StudentsExams(
   StudentID INT,  
      ExamID INT,
  CONSTRAINT PK_Students_Exams
 PRIMARY KEY (StudentID, ExamID),
  CONSTRAINT FK_StudentsExams_Students
 FOREIGN KEY (StudentID)
  REFERENCES Students(StudentID),
  CONSTRAINT FK_StudentsExams_Exams
 FOREIGN KEY (ExamID)
  REFERENCES Exams(ExamID))

-- Problem 04
CREATE TABLE Teachers(
   TeacherID INT PRIMARY KEY IDENTITY(101, 1),
      [Name] NVARCHAR(20) NOT NULL,
   ManagerID INT,
  CONSTRAINT FK_Teacher_Manager
 FOREIGN KEY (ManagerID)  
  REFERENCES Teachers(TeacherID))

-- Problem 05
CREATE TABLE Cities(
      CityID INT PRIMARY KEY IDENTITY(1, 1),
      [Name] VARCHAR(50))

CREATE TABLE Customers(
  CustomerID INT PRIMARY KEY IDENTITY(1, 1),
      [Name] VARCHAR(50),
    Birthday DATE,
      CityID INT,
  CONSTRAINT FK_Customers_Cities
 FOREIGN KEY (CityID)  
  REFERENCES Cities(CityID))

CREATE TABLE Orders(
     OrderID INT PRIMARY KEY IDENTITY(1, 1),
  CustomerID INT,
  CONSTRAINT FK_Orders_Customers
 FOREIGN KEY (CustomerID)  
  REFERENCES Customers(CustomerID))

CREATE TABLE ItemTypes(
  ItemTypeID INT PRIMARY KEY IDENTITY(1, 1),
      [Name] VARCHAR(50))

CREATE TABLE Items(
      ItemID INT PRIMARY KEY IDENTITY(1, 1),
      [Name] VARCHAR(50),
  ItemTypeID INT,
  CONSTRAINT FK_Items_ItemTypes
 FOREIGN KEY (ItemTypeID)  
  REFERENCES ItemTypes(ItemTypeID))

CREATE TABLE OrderItems(
     OrderID INT,
      ItemID INT,
  CONSTRAINT PK_Orders_Items
 PRIMARY KEY (OrderID, ItemID),
  CONSTRAINT FK_OrderItems_Orders
 FOREIGN KEY (OrderID)
  REFERENCES Orders(OrderID),
  CONSTRAINT FK_OrderItems_Items
 FOREIGN KEY (ItemID)
  REFERENCES Items(ItemID))

-- Problem 06
 CREATE TABLE Majors(
      MajorID INT PRIMARY KEY IDENTITY(1, 1),
       [Name] VARCHAR(50))

 CREATE TABLE Students(
    StudentID INT PRIMARY KEY IDENTITY(1, 1),
StudentNumber INT UNIQUE,
  StudentName VARCHAR(50),
      MajorID INT,
   CONSTRAINT FK_Students_Majors
  FOREIGN KEY (MajorID)  
   REFERENCES Majors(MajorID))

 CREATE TABLE Payments(
    PaymentID INT PRIMARY KEY IDENTITY(1, 1),
  PaymentDate DATE,
PaymentAmount MONEY,
    StudentID INT,
   CONSTRAINT FK_Payments_Students
  FOREIGN KEY (StudentID)  
   REFERENCES Students(StudentID))

 CREATE TABLE Subjects(
    SubjectID INT PRIMARY KEY IDENTITY(1, 1),
  SubjectName VARCHAR(50))
 
 CREATE TABLE Agenda(
    StudentID INT,
    SubjectID INT,
   CONSTRAINT PK_Students_Subjects 
  PRIMARY KEY (StudentID, SubjectID),
   CONSTRAINT FK_StudentsSubjects_Students
  FOREIGN KEY (StudentID)
   REFERENCES Students(StudentID),
   CONSTRAINT FK_StudentsSubjects_Subjects
  FOREIGN KEY (SubjectID)
   REFERENCES Subjects(SubjectID))

----------------------------------

USE [Geography]

-- Problem 09
  SELECT m.MountainRange, p.PeakName, p.Elevation
    FROM Peaks AS p
    JOIN Mountains AS m
      ON p.MountainId = m.Id
   WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC