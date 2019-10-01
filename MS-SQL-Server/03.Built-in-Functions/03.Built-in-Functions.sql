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

