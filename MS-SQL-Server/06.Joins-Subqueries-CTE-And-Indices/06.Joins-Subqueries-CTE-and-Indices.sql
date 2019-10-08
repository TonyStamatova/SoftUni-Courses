USE SoftUni

-- Problem 01
  SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a
      ON e.AddressID = a.AddressID
ORDER BY a.AddressID

-- Problem 02
  SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
    FROM Employees AS e
    JOIN Addresses AS a
      ON e.AddressID = a.AddressID
    JOIN Towns AS t
      ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- Problem 03
  SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d
      ON d.[Name] = 'Sales' AND e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- Problem 04
  SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName
    FROM Employees AS e
    JOIN Departments AS d
      ON e.DepartmentID = d.DepartmentID
   WHERE e.Salary > 15000
ORDER BY d.DepartmentID

-- Problem 05
   SELECT TOP(3) e.EmployeeID, e.FirstName
     FROM Employees AS e
LEFT JOIN EMPLOYEESPROJECTS AS ep
       ON e.EmployeeID = ep.EmployeeID 
    WHERE ep.EmployeeID IS NULL
 ORDER BY e.EmployeeID

-- Problem 06
  SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
    FROM Employees AS e
    JOIN Departments AS d
      ON e.DepartmentID = d.DepartmentID
   WHERE d.[Name] IN ('Sales', 'Finance')
     AND e.HireDate > 1/1/1999
ORDER BY e.HireDate

-- Problem 07
   SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
     FROM Projects AS P
LEFT JOIN EmployeesProjects AS ep
       ON p.ProjectID = ep.ProjectID
     JOIN Employees AS e
       ON e.EmployeeID = ep.EmployeeID
    WHERE p.StartDate > 13/08/2002
      AND EndDate IS NULL
 ORDER BY e.EmployeeID

-- Problem 08
   SELECT e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
     FROM Employees AS e
     JOIN EmployeesProjects AS ep
       ON e.EmployeeID = ep.EmployeeID 
      AND e.EmployeeID = 24
LEFT JOIN Projects AS p
       ON ep.ProjectID = p.ProjectID 
      AND YEAR(p.StartDate) < 2005

-- Problem 09
  SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
    FROM Employees AS e
    JOIN Employees AS m
      ON e.ManagerID = m.EmployeeID AND m.EmployeeID IN (3,7)
ORDER BY e.EmployeeID

-- Problem 10
  SELECT TOP(50) e.EmployeeID, 
         e.FirstName + ' ' + e.LastName AS EmployeeName, 
         m.FirstName + ' ' + m.LastName AS ManagerName,
         d.[Name] AS DepartmentName
    FROM Employees AS e
    JOIN Employees AS m
      ON e.ManagerID = m.EmployeeID
    JOIN Departments AS d
      ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- Problem 11
  SELECT MIN(temp.AvgSalary) AS MinAverageSalary
   FROM(
  SELECT AVG(e.Salary) AS AvgSalary
    FROM Employees AS e
GROUP BY e.DepartmentID) AS temp

---------------------------------------------------------
USE [Geography]

-- Problem 12
  SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
    FROM Peaks AS p
    JOIN Mountains AS m
      ON p.Elevation > 2835
     AND p.MountainId = m.Id
    JOIN MountainsCountries AS mc
      ON mc.CountryCode = 'BG'
     AND m.Id = mc.MountainId
ORDER BY p.Elevation DESC

-- Problem 13
  SELECT mc.CountryCode, 
   COUNT (m.MountainRange) AS MountainRanges
    FROM MountainsCountries AS mc
    JOIN Mountains AS m
      ON mc.CountryCode IN ('BG', 'RU', 'US')
     AND mc.MountainId = m.Id
GROUP BY mc.CountryCode

-- Problem 14
   SELECT TOP(5) c.CountryName, r.RiverName
     FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
       ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
       ON cr.RiverId = r.Id
    WHERE c.ContinentCode = 'AF'
 ORDER BY c.CountryName

-- Problem 15
      SELECT r.ContinentCode, r.CurrencyCode, r.CurrencyUsage
        FROM (
      SELECT c.ContinentCode, 
	         c.CurrencyCode,
       COUNT (c.CurrencyCode) AS CurrencyUsage,
DENSE_RANK() OVER (
PARTITION BY c.ContinentCode
    ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
        FROM Countries AS c
    GROUP BY c.ContinentCode, c.CurrencyCode
      HAVING COUNT(c.CurrencyCode) > 1) 
	      AS r
       WHERE r.[Rank] = 1
    ORDER BY r.ContinentCode

-- Problem 16
   SELECT COUNT(c.CountryCode) AS [Count]
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
       ON c.CountryCode = mc.CountryCode
    WHERE mc.MountainId IS NULL

-- Problem 17
   SELECT TOP(5) c.CountryName, 
      MAX (p.Elevation) AS HighestPeakElevation, 
      MAX (r.[Length]) AS LongestRiverLength
     FROM COUNTRIES AS c
LEFT JOIN MountainsCountries AS mc
       ON c.CountryCode = mc.CountryCode
LEFT JOIN Peaks AS p
       ON mc.MountainId = p.MountainId
LEFT JOIN CountriesRivers AS cr
       ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
       ON cr.RiverId = r.Id
 GROUP BY c.CountryName
 ORDER BY MAX(p.Elevation) DESC, MAX(r.[Length]) DESC

-- Problem 18
      SELECT TOP(5) r.CountryName, 
   CASE WHEN r.PeakName IS NULL THEN '(no highest peak)'
        WHEN r.PeakName IS NOT NULL THEN r.PeakName
      END AS [Highest Peak Name],
   CASE WHEN r.PeakName IS NULL THEN 0
        WHEN r.PeakName IS NOT NULL THEN r.Elevation
      END AS [Highest Peak Elevation],
   CASE WHEN r.PeakName IS NULL THEN '(no mountain)'
        WHEN r.PeakName IS NOT NULL THEN r.MountainRange
      END AS Mountain
        FROM (
      SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange,
DENSE_RANK() OVER (
PARTITION BY c.CountryCode
    ORDER BY p.Elevation DESC) AS [Rank]
        FROM COUNTRIES AS c
   LEFT JOIN MountainsCountries AS mc
          ON c.CountryCode = mc.CountryCode
   LEFT JOIN Peaks AS p
          ON mc.MountainId = p.MountainId
   LEFT JOIN Mountains AS m
          ON mc.MountainId = m.Id) AS r
       WHERE r.[Rank] = 1
    ORDER BY CountryName, [Highest Peak Name]