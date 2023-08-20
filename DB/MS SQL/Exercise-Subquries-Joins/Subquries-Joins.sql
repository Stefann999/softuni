GO

USE [SoftUni]

GO

-- 01. Employee Address

SELECT TOP (5) [EmployeeID], [JobTitle], [e].[AddressID], [a].[AddressText]
		  FROM [Employees] AS [e]
	 LEFT JOIN [Addresses] AS [a]
	        ON [e].AddressID = [a].AddressID
	  ORDER BY [a].[AddressID]


-- 02. Addresses with Towns 

SELECT TOP (50) [e].[FirstName], [e].[LastName],[t].[Name], [a].[AddressText]
			  FROM [Employees] AS [e]
		 LEFT JOIN [Addresses] AS [a]
	        ON [e].AddressID = [a].AddressID
		 LEFT JOIN [Towns] AS [t]
				ON [a].TownID = [t].TownID
		  ORDER BY [e].[FirstName], [e].[LastName]


-- 03. Sales Employee

   SELECT [e].[EmployeeID], [e].[FirstName], [e].[LastName], [d].[Name]
     FROM [Employees] AS [e]
LEFT JOIN [Departments] AS [d]
	   ON [e].[DepartmentID] = [d].[DepartmentID]
	WHERE [d].[Name] = 'Sales'
 ORDER BY [e].[EmployeeID]


-- 04. Employee Departments

SELECT TOP (5) [e].[EmployeeID], [e].[FirstName], [e].[Salary], [d].[Name]
		  FROM [Employees] AS [e]
	 LEFT JOIN [Departments] AS [d]
			ON [e].DepartmentID = [d].[DepartmentID]
		 WHERE [e].Salary > 15000 AND [d].[Name] = 'Engineering'
	  ORDER BY [d].[DepartmentID]


-- 05. Employees Without Project

SELECT TOP (3) [e].[EmployeeID], [e].[FirstName]
		  FROM [Employees] AS [e]
	 LEFT JOIN [EmployeesProjects] AS [ep]
			ON [e].[EmployeeID] = [ep].[EmployeeID]
		 WHERE [ep].[ProjectID] IS NULL
	  ORDER BY e.[EmployeeID]


-- 06. Employees Hired After

   SELECT [e].[FirstName], [e].[LastName],[e].[HireDate], [d].[Name]
	 FROM [Employees] AS [e]
LEFT JOIN [Departments] AS [d]
	   ON [e].[DepartmentID] = [d].[DepartmentID]
	WHERE [e].[HireDate] > '1999-01-01' AND [d].[Name] IN ('Sales', 'Finance')
 ORDER BY [e].[HireDate]


-- 07. Employees with Project

SELECT TOP (5) [e].[EmployeeID], [e].[FirstName], [p].[Name]
		  FROM [Employees] AS [e]
	 LEFT JOIN [EmployeesProjects] AS [ep]
			ON [e].[EmployeeID] = [ep].[EmployeeID]
	 LEFT JOIN [Projects] AS [p]
			ON [ep].[ProjectID] = [p].[ProjectID]
		 WHERE [p].[StartDate] > '2002-08-13' AND [p].[EndDate] IS NULL
	  ORDER BY [e].[EmployeeID]


--08. Employee 24

   SELECT [e].[EmployeeID], [e].[FirstName],
	 CASE 
		 WHEN [p].[StartDate] >= '2005-01-01' THEN NULL
		 ELSE [p].[Name]
   END AS [ProjectName]
     FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] AS [ep]
	   ON [e].[EmployeeID] = [ep].[EmployeeID]
LEFT JOIN [Projects] AS [p]
	   ON [ep].[ProjectID] = [p].[ProjectID]
	WHERE [e].[EmployeeID] = 24


--09. Employee Manager

  SELECT [e].[EmployeeID], [e].[FirstName], [e].[ManagerID],
		 [e2].[FirstName] AS [ManagerName]
	FROM [Employees] AS [e]
	JOIN [Employees] AS [e2] 
	  ON [e].[ManagerID] = [e2].[EmployeeID]
   WHERE [e].[ManagerID] IN (3, 7)
ORDER BY [e].[EmployeeID]


--10. Employees Summary

SELECT TOP(50) e.[EmployeeID]
     , CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName]
     , CONCAT(ee.[FirstName], ' ', ee.[LastName]) AS [ManagerName]
     , d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS ee on e.[ManagerID] = ee.[EmployeeID]
JOIN Departments d on d.DepartmentID = e.DepartmentID
ORDER BY e.[EmployeeID]


--11. Min Average Salary

SELECT MIN(a.[AverageSalary]) AS [MinAverageSalary]
FROM (SELECT AVG(e.[Salary]) AS [AverageSalary]
      FROM Employees AS e
      GROUP BY e.[DepartmentID]) AS a

-- Part II - Queries for Geography Database

USE Geography
GO


--12. Highest Peaks in Bulgaria

SELECT mc.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation]
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.[MountainId] = m.Id
JOIN Peaks p on m.Id = p.MountainId
WHERE p.[Elevation] > 2835 AND
      mc.[CountryCode] = 'BG'
ORDER BY p.[Elevation] DESC


--13. Count Mountain Ranges

SELECT mc.[CountryCode], COUNT(m.[MountainRange]) AS [MountainRanges]
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.[MountainId] = m.[Id]
WHERE mc.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY mc.[CountryCode]

--14. Countries With or Without Rivers

SELECT TOP(5) c.[CountryName], r.[RiverName]
FROM Countries AS c
LEFT JOIN CountriesRivers cr on cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON cr.[RiverId] = r.[Id]
WHERE c.[ContinentCode] = 'AF'
ORDER BY c.[CountryName]


--15. Continents and Currencies

SELECT cont.ContinentCode, cont.CurrencyCode, cont.CounterCurrency
FROM
 (
SELECT
    c.ContinentCode
    , c.CurrencyCode
    , COUNT(c.CurrencyCode) AS [CounterCurrency]
    , DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode HAVING COUNT(c.CurrencyCode) > 1
) AS [cont]
WHERE [cont].[Rank] = 1
ORDER BY [cont].ContinentCode

--16. Countries Without Any Mountains

SELECT COUNT(c.[CountryCode]) AS Count
FROM Countries AS c
LEFT JOIN MountainsCountries mc ON mc.[CountryCode] = c.[CountryCode]
WHERE mc.[MountainId] IS NULL

--17. Highest Peak and Longest River by Country

SELECT TOP(5) c.[CountryName], MAX(p.[Elevation]) AS [HighestPeakElevation] , MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
JOIN Rivers r ON r.Id = cr.RiverId
JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
JOIN Peaks p on p.MountainId = mc.MountainId
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC , c.[CountryName]

--18. Highest Peak Name and Elevation by Country

SELECT
    [CountryName] AS [Country]
    , CASE
        WHEN [PeakName] IS NULL THEN '(no highest peak)'
        ELSE [PeakName]
    END AS [Highest Peak Name]
    , CASE
        WHEN [Elevation] IS NULL THEN 0
        ELSE [Elevation]
    END AS [Highest Peak Evelation]
    , CASE
        WHEN [MountainRange] IS NULL THEN '(no mountain)'
        ELSE [MountainRange]
    END AS [Mountain]
FROM
(
    SELECT TOP(5) c.[CountryName]
    , m.[MountainRange]
    , p.[PeakName]
    , p.[Elevation]
    , DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
FROM Countries AS c
LEFT JOIN MountainsCountries mc on c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m on m.Id = mc.MountainId
LEFT JOIN Peaks p on m.Id = p.MountainId
) AS [Ranking]
WHERE Rank = 1
ORDER BY Country, [Highest Peak Name]