USE SoftUni

-- Problem 01
SELECT FirstName, LastName 
  FROM Employees
 WHERE FirstName LIKE 'sa%'

-- Problem 02
SELECT FirstName, LastName 
  FROM Employees
 WHERE LastName LIKE '%ei%'

-- Problem 03
SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3, 10) 
   AND YEAR(HireDate) BETWEEN 1995 AND 2005

-- Problem 04
SELECT FirstName, LastName 
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

-- Problem 05
  SELECT [Name]
    FROM Towns
   WHERE (LEN ([Name])) IN (5, 6)
ORDER BY [Name]

-- Problem 06
  SELECT TownID, [Name]
    FROM Towns
   WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

-- Problem 07
  SELECT TownID, [Name]
    FROM Towns
   WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

-- Problem 08
CREATE VIEW V_EmployeesHiredAfter2000 AS
     SELECT FirstName, LastName 
       FROM Employees
      WHERE YEAR(HireDate) > 2000

-- Problem 09
SELECT FirstName, LastName 
  FROM Employees
 WHERE (LEN (LastName)) = 5

-- Problem 10
      SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER( 
PARTITION BY Salary
    ORDER BY EmployeeID) 
	      AS [Rank]  
        FROM Employees
       WHERE Salary BETWEEN 10000 AND 50000
    ORDER BY Salary DESC

-- Problem 11
      SELECT *
FROM (SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER( 
PARTITION BY Salary
    ORDER BY EmployeeID) 
	      AS [Rank]  
        FROM Employees
       WHERE Salary BETWEEN 10000 AND 50000)
	      AS temp
	   WHERE temp.[Rank] = 2		  
    ORDER BY Salary DESC

------------------------------
USE [Geography]

-- Problem 12
  SELECT CountryName, IsoCode
    FROM Countries
   WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- Problem 13
  SELECT p.PeakName, r.RiverName, 
   LOWER (CONCAT (p.PeakName, '', RIGHT(r.RiverName, LEN(r.RiverName) - 1))) 
      AS [Mix]
    FROM Peaks AS p, Rivers AS r
   WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix]

------------------------------------------
USE Diablo

-- Problem 14
SELECT TOP(50) [Name], 
        FORMAT ([Start], 'yyyy-MM-dd') 
            AS [Start]
          FROM Games
         WHERE YEAR([Start]) IN (2011, 2012)
      ORDER BY [Start], [Name]

-- Problem 15
   SELECT Username, 
SUBSTRING (Email, CHARINDEX('@', Email) + 1, LEN(Email))
       AS [Email Provider]
     FROM USERS
 ORDER BY [Email Provider], Username

-- Problem 16
  SELECT Username, IpAddress
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- Problem 17
   SELECT [Name] AS [Game],
CASE WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
     WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
     ELSE 'Evening'
   END AS [Part of the Day],
CASE WHEN [Duration] <= 3 THEN 'Extra Short'
     WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
     WHEN [Duration] > 6 THEN 'Long'
     ELSE 'Extra Long'
   END AS [Duration]
     FROM Games
 ORDER BY [Game], [Duration], [Part of the Day]

-----------------------------------------------------

USE Orders

-- Problem 18
 SELECT ProductName, OrderDate, 
DATEADD (DAY, 3, OrderDate) AS [Pay Due],
DATEADD (MONTH, 1, OrderDate) AS [Deliver Due]
   FROM Orders

-----------------------------------------------------

CREATE DATABASE Demo

USE Demo

-- Problem 19
CREATE TABLE People (
          Id INT PRIMARY KEY IDENTITY,
      [Name] VARCHAR(30) NOT NULL,
   Birthdate DATETIME NOT NULL);

 INSERT INTO People([Name], Birthdate)
      VALUES ('VICTOR', '1992-01-17')

      SELECT [Name],
    DATEDIFF (YEAR, Birthdate, GETDATE()) AS [Age in Years],
    DATEDIFF (MONTH, Birthdate, GETDATE()) AS [Age in Months],
    DATEDIFF (DAY, Birthdate, GETDATE()) AS	[Age in Days],
    DATEDIFF (MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
        FROM People