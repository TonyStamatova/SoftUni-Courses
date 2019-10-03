USE Gringotts

-- Problem 01
SELECT COUNT(Id)
  FROM WizzardDeposits  
    AS [Count]

-- Problem 02
SELECT MAX(w.MagicWandSize) AS LongestMagicWand
  FROM WizzardDeposits AS w

-- Problem 03
  SELECT w.DepositGroup, MAX(w.MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

-- Problem 04
SELECT TOP(2) w.DepositGroup
  FROM WizzardDeposits AS w
 GROUP BY w.DepositGroup
 ORDER BY AVG(w.MagicWandSize)

-- Problem 05
  SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
    FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

-- Problem 06
  SELECT w.DepositGroup, 
     SUM (w.DepositAmount) AS TotalSum
    FROM WizzardDeposits AS w
   WHERE w.MagicWandCreator = 'Ollivander family' 
GROUP BY w.DepositGroup

-- Problem 07
  SELECT w.DepositGroup, 
     SUM (w.DepositAmount) AS TotalSum
    FROM WizzardDeposits AS w
   WHERE w.MagicWandCreator = 'Ollivander family' 
GROUP BY w.DepositGroup
  HAVING SUM (w.DepositAmount) < 150000
ORDER BY TotalSum DESC

-- Problem 08
  SELECT w.DepositGroup, w.MagicWandCreator,
     MIN (w.DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits AS w 
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup

-- Problem 09
   SELECT temp.AgeGroup,
    COUNT (temp.AgeGroup) AS WizardCount
     FROM (
   SELECT w.Age, 
CASE WHEN w.Age <= 10 THEN '[0-10]'
     WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
     WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
     WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
     WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
     WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
     WHEN w.Age > 60 THEN '[61+]'
   END AS AgeGroup
     FROM WizzardDeposits AS w) AS temp
 GROUP BY temp.AgeGroup

-- Problem 10
  SELECT LEFT(w.FirstName, 1) AS FirstLetter
    FROM WizzardDeposits AS w
   WHERE W.DepositGroup = 'Troll Chest'
GROUP BY LEFT(w.FirstName, 1)
ORDER BY FirstLetter

-- Problem 11
  SELECT w.DepositGroup, w.IsDepositExpired,
     AVG (w.DepositInterest) AS AverageInterest
    FROM WizzardDeposits AS w 
   WHERE w.DepositStartDate >= '1985-01-01'
GROUP BY w.DepositGroup, w.IsDepositExpired
ORDER BY w.DepositGroup DESC, w.IsDepositExpired

-- Problem 12
    SELECT SUM(d.[Difference])
      FROM (
    SELECT f.DepositAmount - s.DepositAmount  AS [Difference]
      FROM WizzardDeposits AS f
INNER JOIN WizzardDeposits AS s
        ON s.Id = f.Id + 1) AS d

-------------------------------------------------------

USE SoftUni
 
-- Problem 13
  SELECT DepartmentID, 
     SUM (Salary) AS TotalSalary
    FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- Problem 14
  SELECT e.DepartmentID,
     MIN (e.Salary) AS MinimumSalary
    FROM Employees AS e
GROUP BY e.DepartmentID
  HAVING e.DepartmentID IN (2,5,7)

-- Problem 15
  SELECT *
    INTO Temp 
    FROM Employees AS e
   WHERE e.Salary > 30000 

  DELETE 
    FROM Temp
   WHERE ManagerID = 42

  UPDATE Temp 
     SET Salary += 5000
   WHERE DepartmentID = 1

  SELECT t.DepartmentID,
     AVG (t.Salary) AS AverageSalary
    FROM Temp AS t
GROUP BY t.DepartmentID

-- Problem 16
  SELECT temp.DepartmentID, temp.MaxSalary
    FROM (
  SELECT e.DepartmentID,
     MAX (e.Salary) AS MaxSalary
    FROM Employees AS e
GROUP BY e.DepartmentID) AS temp
   WHERE temp.MaxSalary NOT BETWEEN 30000 AND 70000

-- Problem 17
  SELECT COUNT(e.Salary) AS [Count]
    FROM Employees AS e
GROUP BY e.ManagerID
  HAVING e.ManagerID IS NULL

-- Problem 18
      SELECT temp.DepartmentID, temp.Salary AS ThirdHighestSalary
        FROM (
      SELECT e.DepartmentID, e.Salary,
DENSE_RANK() OVER(
PARTITION BY e.DepartmentId  
    ORDER BY e.Salary DESC) AS [Rank]
        FROM Employees AS e) AS temp
    GROUP BY temp.DepartmentID, temp.Salary, temp.[Rank]
      HAVING temp.[Rank] = 3

-- Problem 19
    SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
      FROM Employees AS e
INNER JOIN (
    SELECT t.DepartmentID,
       AVG (t.Salary) AS AverageSalary
      FROM Employees AS t
  GROUP BY t.DepartmentID) AS n
        ON e.DepartmentID = n.DepartmentID AND e.Salary > n.AverageSalary
  ORDER BY e.DepartmentID