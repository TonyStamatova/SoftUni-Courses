CREATE DATABASE [Service]

USE [Service]

-- Problem 01
CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Username NVARCHAR(30) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK (AGE BETWEEN 14 AND 110),
	Email NVARCHAR(50) NOT NULL)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK (AGE BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(ID))

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(ID) NOT NULL)

CREATE TABLE [Status] (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Label NVARCHAR(30) NOT NULL)

CREATE TABLE Reports (
	Id INT PRIMARY KEY IDENTITY(1,1),
	CategoryId INT FOREIGN KEY REFERENCES Categories(ID) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(ID) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(ID) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(ID)) 

-- Problem 02
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES ('Marlo', 'O''Malley', '1958-9-21', 1),
	   ('Niki', 'Stanaghan', '1969-11-26', 4),
	   ('Ayrton', 'Senna', '1960-03-21', 9),
	   ('Ronnie', 'Peterson', '1944-02-14', 9),
	   ('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate,	[Description], UserId, EmployeeId)
VALUES (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	   (6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	   (14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	   (4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

-- Problem 03
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-- Problem 04
DELETE FROM Reports
WHERE StatusId = 4

-- Problem 05
SELECT [Description], FORMAT(R.OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, [Description]

-- Problem 06
SELECT r.[Description], c.[Name] AS CategoryName
FROM Reports AS r
JOIN Categories AS c
ON c.Id =  r.CategoryId
ORDER BY r.[Description], c.[Name] 

-- Problem 07
SELECT TOP (5) c.[Name] AS CategoryName, temp.ReportsNumber
FROM Categories AS c
JOIN (
	SELECT COUNT(*) AS ReportsNumber, r.CategoryId
	FROM Reports AS r
	GROUP BY CategoryId) AS temp
ON c.Id = temp.CategoryId
ORDER BY ReportsNumber DESC, CategoryName

-- Problem 08
SELECT u.Username, c.[Name] AS CategoryName
FROM Reports AS r
JOIN Users AS u
ON r.UserId = u.Id
LEFT JOIN Categories AS c
ON r.CategoryId = c.Id
WHERE DAY(r.OpenDate) = DAY(u.Birthdate)
AND MONTH(r.OpenDate) = MONTH(u.Birthdate)
ORDER BY u.Username

-- Problem 09
SELECT temp.FullName, COUNT(temp.Id) AS UsersCount
FROM (
	SELECT DISTINCT e.FirstName + ' ' + e.LastName AS FullName, u.Id
	FROM Employees AS e
	LEFT JOIN Reports AS r
	ON e.Id = r.EmployeeId
	LEFT JOIN Users AS u
	ON u.Id = r.UserId) AS temp
GROUP BY temp.FullName
ORDER BY UsersCount DESC, temp.FullName

-- Problem 10
SELECT 
	CASE WHEN e.Id IS NULL THEN 'None'
		 ELSE e.FirstName + ' ' + e.LastName
			END AS Employee,
	CASE WHEN d.[Name] IS NULL THEN 'None'
		 ELSE d.[Name] 
			END AS Department,
	c.[Name] AS Category,
	r.[Description],
	FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	s.Label AS [Status],
	u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e
ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d
ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c
ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s
ON r.StatusId = s.Id
LEFT JOIN Users AS u
ON u.Id = r.UserId
ORDER BY e.FirstName DESC, 
	e.LastName DESC, 
	Department,
	Category,
	r.Description, 
	OpenDate, 
	[Status],
	[User]

-- Problem 11
CREATE FUNCTION udf_HoursToComplete (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @Hours INT;

	IF (@StartDate IS NULL OR @EndDate IS NULL)
		RETURN 0
	
	SET @Hours = DATEDIFF (HOUR, @StartDate, @EndDate)
	RETURN @Hours;
END

-- Problem 12
CREATE PROC usp_AssignEmployeeToReport (@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @EmployeeDept INT = (
		SELECT e.DepartmentId
		FROM Employees e
		WHERE e.Id = @EmployeeId)
	DECLARE @ReportDept INT = (
		SELECT c.DepartmentId
		FROM Reports r
		JOIN Categories AS c
		ON c.Id = r.CategoryId
		WHERE r.Id = @ReportId)
	
	IF (@EmployeeDept <> @ReportDept)
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;	
	ELSE
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId	
END