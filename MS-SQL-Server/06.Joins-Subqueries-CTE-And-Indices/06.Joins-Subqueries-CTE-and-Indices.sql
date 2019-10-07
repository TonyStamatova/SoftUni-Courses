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
SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
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
WHERE  c.ContinentCode = 'AF'
ORDER BY c.CountryName