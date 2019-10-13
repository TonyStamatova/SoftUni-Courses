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
CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT) 
AS
BEGIN
  DELETE 
  FROM EmployeesProjects
  WHERE EmployeeID IN(
    SELECT EmployeeID 
 	FROM Employees AS e	 
	WHERE e.DepartmentID = @departmentId)

  UPDATE Employees
  SET ManagerID = NULL
  WHERE ManagerID IN(
	SELECT EmployeeID 
 	FROM Employees AS e	 
	WHERE e.DepartmentID = @departmentId)

  ALTER TABLE Departments
  ALTER COLUMN ManagerID INT

  UPDATE Departments
  SET ManagerID = NULL
  WHERE DepartmentID = @departmentId

  DELETE FROM Employees
  WHERE DepartmentID = @departmentId

  DELETE FROM Departments
  WHERE DepartmentID = @departmentId

  SELECT COUNT(*)
  FROM Employees
  WHERE DepartmentID = @departmentId
END

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
  JOIN (
    SELECT a.AccountHolderId, SUM(a.Balance) AS s
    FROM Accounts AS a
    GROUP BY a.AccountHolderId
    HAVING SUM(a.Balance) > @number) AS sa
  ON ah.Id = sa.AccountHolderId
  ORDER BY ah.FirstName, ah.LastName

-- Problem 11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15,4), @rate FLOAT, @years INT)
RETURNS DECIMAL(15,4) AS
BEGIN
  DECLARE @result DECIMAL(15,4)
  SET @result = @sum * POWER(1 + @rate, @years)
  RETURN @result
END

-- Problem 12
CREATE PROC usp_CalculateFutureValueForAccount(@id INT, @rate FLOAT)
AS
  SELECT a.Id AS [Account Id],
    ah.FirstName AS [First Name], 
    ah.LastName AS [Last Name], 
    a.Balance AS [Current Balance],
    dbo.ufn_CalculateFutureValue(a.Balance, @rate, 5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a
  ON ah.Id = a.AccountHolderId
  WHERE a.Id = @id

-------------------------------------------------------------------

USE Diablo

-- Problem 13
CREATE FUNCTION ufn_CashInUsersGames(@name NVARCHAR(50))
RETURNS TABLE AS
RETURN (
  SELECT SUM(temp.Cash) AS SumCash
  FROM (
    SELECT ug.Cash, 
      ROW_NUMBER() OVER(
        PARTITION BY g.[Name]
        ORDER BY ug.Cash DESC) AS [row]
    FROM Games AS g
    JOIN UsersGames AS ug
    ON g.Id = ug.GameId
    WHERE g.[Name] = @name) AS temp
  WHERE temp.[row] % 2 <> 0)

--------------------------------------------------

USE Bank

-- Problem 14
CREATE TABLE Logs(
  LogId INT PRIMARY KEY IDENTITY(1,1),
  AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL, 
  OldSum MONEY, 
  NewSum MONEY)

CREATE TRIGGER tr_AccountsUpdate ON Accounts INSTEAD OF UPDATE
AS
  BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT inserted.Id, a.Balance, inserted.Balance
	FROM inserted
	LEFT JOIN Accounts AS a
	ON inserted.Id = a.Id

	UPDATE a
	SET a.Balance = i.Balance
	FROM Accounts AS a 
	RIGHT JOIN inserted AS i
	ON i.Id = a.Id
  END

-- Problem 15
CREATE TABLE NotificationEmails(
  Id INT PRIMARY KEY IDENTITY(1,1), 
  Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL, 
  [Subject] NVARCHAR(MAX) NOT NULL, 
  Body NVARCHAR(MAX) NOT NULL)

CREATE TRIGGER tr_AccountsUpdateEmail ON Accounts INSTEAD OF UPDATE
AS
  BEGIN
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT inserted.Id, 
	  CONCAT('Balance change for account: ', 
	    inserted.Id),
	  CONCAT('On ', 
	    CONVERT(VARCHAR, GETDATE(), 100), 
	    ' your balance was changed from ', 
	    a.Balance, 
	    ' to ', 
	    inserted.Balance, 
	    '.')
	FROM inserted
	LEFT JOIN Accounts AS a
	ON inserted.Id = a.Id

	UPDATE a
	SET a.Balance = i.Balance
	FROM Accounts AS a
	RIGHT JOIN inserted AS i
	ON i.Id = a.Id
  END

-- Problem 16
CREATE PROC usp_DepositMoney(@accountId INT, @moneyAmount MONEY)
AS
  BEGIN TRANSACTION
    IF (@moneyAmount > 0)
      BEGIN
        UPDATE a 
	    SET a.Balance = a.Balance + @moneyAmount
		FROM Accounts AS a
        WHERE a.Id = @accountId 
      END    
COMMIT

-- Problem 17
CREATE PROC usp_WithdrawMoney(@accountId INT, @moneyAmount MONEY)
AS
  BEGIN TRANSACTION
    IF (@moneyAmount > 0)
      BEGIN
        UPDATE a
	    SET a.Balance = a.Balance - @moneyAmount
		FROM Accounts AS a 
        WHERE a.Id = @accountId 
      END    
COMMIT

-- Problem 18
CREATE PROC usp_TransferMoney(@SenderId INT, @receiverId INT, @moneyAmount MONEY)
AS
  BEGIN TRANSACTION
    IF (@moneyAmount > 0)
      BEGIN
        EXEC dbo.usp_WithdrawMoney @SenderId, @moneyAmount
		EXEC dbo.usp_DepositMoney @receiverId, @moneyAmount
      END    
COMMIT

------------------------------------------------------------------

USE Diablo

-- Problem 19
--CREATE TRIGGER tr_UsertItemsToUserGames ON UserGameItems FOR UPDATE
--AS
--  IF (EXISTS(
--        SELECT * 
--		FROM inserted AS ins
--		JOIN Items AS it
--		ON ins.ItemId = it.Id
--		JOIN UsersGames AS ug
--		ON ins.UserGameId = ug.Id
--        WHERE it.MinLevel > ug.Level))
--  BEGIN
--    ROLLBACK
--    RETURN
--  END

--UPDATE ug
--SET ug.Cash += 50000 
--FROM UsersGames AS ug
--JOIN Games AS g
--ON g.Id = ug.GameId
--JOIN Users AS u
--ON u.Id = ug.UserId
--WHERE g.Name = 'Bali' 
--AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')


--  select * from items
--  select * from usergameitems
--  SELECT * FROM UsersGames
--  select * from games
--  where Games.Name = 'Bali'
--  SELECT * FROM USERS

SELECT u.Username
FROM Users AS u
JOIN (
  SELECT *
  FROM Items AS i
  FULL JOIN UsersGames AS ug
  ON ug.GameId IN (
       SELECT g.Id, g.[Name]
       FROM Games AS g
       WHERE g.[Name] = 'Bali')
  AND ug.UserId IN (
       SELECT u.Id
       FROM Users AS u
       WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))
  WHERE i.Id BETWEEN 251 AND 299
  OR i.Id BETWEEN 501 AND 539) AS temp
ON u.Id = temp.UserId