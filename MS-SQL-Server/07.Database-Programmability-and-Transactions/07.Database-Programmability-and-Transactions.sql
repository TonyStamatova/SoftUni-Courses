USE SoftUni

-- Problem 01
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
  SELECT e.FirstName, e.LastName
  FROM Employees AS e
  WHERE e.Salary > 35000

-- Problem 02
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18,4))
AS
SELECT e.FirstName, e.LastName
  FROM Employees AS e
  WHERE e.Salary >= @number

-- Problem 03
CREATE PROC usp_GetTownsStartingWith(@str NVARCHAR(20))
AS
SELECT t.[Name] AS Town
 FROM Towns AS t
 WHERE t.[Name] LIKE @str + '%'

-- Problem 04
CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(20))
AS
SELECT e.FirstName, e.LastName
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON t.[Name] = @townName
AND a.TownID = t.TownID

-- Problem 05
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10) AS
BEGIN
DECLARE @salaryLevel VARCHAR(10)
IF (@salary < 30000)
  SET @salaryLevel = 'Low'
ELSE IF(@salary BETWEEN 30000 AND 50000)
  SET @salaryLevel = 'Average'
ELSE
  SET @salaryLevel = 'High'
  RETURN @salaryLevel
 END

-- Problem 06
CREATE PROC usp_EmployeesBySalaryLevel(@level NVARCHAR(10))
AS
SELECT e.FirstName, e.LastName
FROM Employees AS e
WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @level

-- Problem 07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT AS
BEGIN
DECLARE @Iteration INT
SET @Iteration = 1
WHILE @Iteration <= LEN(@word)
BEGIN
    IF (@setOfLetters LIKE '%' + SUBSTRING(@word, @Iteration, 1) + '%')
    SET @Iteration = @Iteration + 1
	ELSE
	RETURN 0
END
RETURN 1
END

-- Problem 08


-------------------------------------------
USE Bank

-- Problem 09
CREATE PROC usp_GetHoldersFullName
AS
SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
FROM AccountHolders AS ah

-- Problem 10
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number MONEY)
AS
SELECT ah.FirstName, ah.LastName
FROM AccountHolders AS ah
JOIN 
(SELECT a.AccountHolderId, SUM(a.Balance) AS s
FROM Accounts AS a
GROUP BY a.AccountHolderId
HAVING SUM(a.Balance) > @number) AS sa
ON ah.Id = sa.AccountHolderId
ORDER BY ah.FirstName, ah.LastName