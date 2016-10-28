--TelerikAcademy Database
USE TelerikAcademy

--4.
--SELECT * FROM Departments

--5.
--SELECT DepartmentID FROM Departments

--6
--SELECT FirstName, Salary FROM Employees

--7
--SELECT  FirstName + ' ' + LastName AS FullName FROM Employees

--8
--SELECT FirstName + '.' + LastName + '@telerik.com' AS FullEmailAddresses FROM Employees

--9
--SELECT DISTINCT Salary FROM Employees

--10
--SELECT *
--FROM Employees
--WHERE JobTitle = 'Sales Representative'

--11
--SELECT FirstName + ' ' + LastName AS Name 
--FROM Employees 
--WHERE FirstName LIKE 'SA%'
--ORDER BY Name

--12
--SELECT FirstName + ' ' + LastName AS Name 
--FROM Employees 
--WHERE LastName LIKE '%ei%'
--ORDER BY Name

--13
--SELECT Salary
--FROM Employees
--WHERE Salary > 20000 AND Salary < 30000
--ORDER BY Salary

--14
--SELECT FirstName + ' ' + LastName AS Name
--FROM Employees
--WHERE Salary = 25000 
--	OR Salary = 14000 
--	OR Salary = 12500 
--	OR Salary = 23600
--ORDER BY Name

--15
--SELECT FirstName + ' ' + LastName AS Name
--FROM Employees
--WHERE ManagerID IS NULL
--ORDER BY Name

--16
--SELECT FirstName + ' ' + LastName AS Name
--FROM Employees
--WHERE Salary > 50000
--ORDER BY Salary DESC

--17
--SELECT TOP 5 * FROM Employees ORDER BY Salary DESC

--18
--SELECT e.FirstName, e.LastName, a.AddressText
--FROM Employees e
--INNER JOIN Addresses a
--ON e.AddressID = a.AddressID

--19
--SELECT e.FirstName, e.LastName, a.AddressText
--FROM Employees e, Addresses a 
--WHERE e.AddressID = a.AddressID

--20
--SELECT e.FirstName + ' ' +  e.LastName AS EmployeeName, m.FirstName + ' ' + m.LastName AS ManagerName
--FROM Employees e
--INNER JOIN Employees m
--ON e.ManagerID = m.EmployeeID

--21
--SELECT e.FirstName + ' ' +  e.LastName AS EmployeeName, m.FirstName + ' ' + m.LastName AS ManagerName, a.AddressText
--FROM Employees e
--INNER JOIN Employees m
--ON e.ManagerID = m.EmployeeID
--INNER JOIN Addresses a
--ON e.AddressID = a.AddressID

--22
--SELECT Name
--	FROM Departments
--UNION
--SELECT Name
--	FROM Towns 

--23
--SELECT e.FirstName + ' ' +  e.LastName AS EmployeeName, m.FirstName + ' ' + m.LastName AS ManagerName, e.ManagerID
--FROM Employees e
--RIGHT OUTER JOIN Employees m
--ON e.ManagerID = m.EmployeeID OR e.ManagerID IS NULL
--ORDER BY e.ManagerID

--24
--SELECT FirstName + ' '+ LastName AS Name
--FROM Employees 
--WHERE (DepartmentID = 3 OR DepartmentID=10) AND (year(HireDate) > '1995' AND year(HireDate) < '2005')
--ORDER BY Name