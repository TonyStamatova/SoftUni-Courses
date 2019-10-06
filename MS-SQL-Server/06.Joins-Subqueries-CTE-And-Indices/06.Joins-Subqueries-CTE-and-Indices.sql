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