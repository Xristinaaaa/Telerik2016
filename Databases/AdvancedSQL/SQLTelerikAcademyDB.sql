USE TelerikAcademy

--1.Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName, LastName, Salary
FROM Employees 
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees )

--2.Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary
FROM Employees 
WHERE Salary <
	(SELECT MIN(Salary) FROM Employees) + (SELECT MIN(Salary) FROM Employees)/10

--3.Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
SELECT e.FirstName + ' ' + e.LastName AS [FullName], e.Salary, d.Name [Department]
FROM Employees e
JOIN Departments d
ON Salary = 
	(SELECT MIN(Salary) FROM Employees) AND e.DepartmentID=d.DepartmentID

--4.Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) [AverageSalaryInEngineering]
FROM Employees 
WHERE DepartmentID = 1

--5.Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary) [AverageSalaryInEngineering]
FROM Employees 
WHERE DepartmentID = 3

--6.Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.EmployeeID) 
FROM Employees e
WHERE e.DepartmentID = 3

--7.Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(e.EmployeeID) 
FROM Employees e
WHERE e.ManagerID IS NOT NULL

--8.Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(e.EmployeeID) 
FROM Employees e
WHERE e.ManagerID IS NULL

--9.Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name [Department], AVG(Salary) [AverageSalary]
FROM Employees e
JOIN Departments d
ON d.DepartmentID = e.DepartmentID 
GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT COUNT(e.EmployeeID) [EmployeesCount]
FROM Employees e, Departments d, Towns t, Addresses a
WHERE e.DepartmentID = d.DepartmentID AND e.AddressID = a.AddressID AND a.TownID = t.TownID

--11.Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName, m.LastName 
FROM Employees e, Employees m
WHERE e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

--12.Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName [Employee], ISNULL((m.FirstName + ' ' + m.LastName), 'no manager') [Manager]
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT e.FirstName + ' ' + e.LastName [EmployeeName]
FROM Employees e
WHERE LEN(e.LastName) = 5

--14.Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT CONVERT(VARCHAR(24),GETDATE(),104) + ' '+ CONVERT(VARCHAR(24),GETDATE(),114) [DateTimeNow]

--15.Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username NCHAR(15) UNIQUE NOT NULL,
	Password NVARCHAR(15) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	LastLogin DATETIME NOT NULL
);

ALTER TABLE Users
ADD CONSTRAINT ValidatePassword CHECK (LEN(Users.Password) >= 5 );

--16.Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
CREATE VIEW [Users Today] 
AS
SELECT FullName
FROM Users r
WHERE CONVERT(DATE, LastLogin) = CONVERT(DATE, GETDATE())


--17.Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
CREATE TABLE Groups
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NCHAR(15) NOT NULL
	UNIQUE(Name)
);

--18.Write a SQL statement to add a column GroupID to the table Users.
ALTER TABLE Users
ADD GroupID INT UNIQUE

INSERT INTO Groups VALUES (1), (2)
INSERT INTO Users VALUES ('Ivcho', '1234124', 'Ivan Ivanov', GETDATE(), 1)

ALTER TABLE Users
ADD GroupID INT FOREIGN KEY REFERENCES Groups(Id)

--19.Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups VALUES (11231), (212313)
INSERT INTO Users VALUES ('Hrisi', 'HEfrgsst', 'Hrisi Petrova', GETDATE(), 1)

--20.Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users 
SET Password = 'asdasfa'
WHERE Username = 'Ivcho'

UPDATE Groups 
SET Name = 21321
WHERE Id = 1

--21.Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE Users
WHERE Username = 'Hrisi'

DELETE Groups
WHERE Name = 11231

--22.Write SQL statements to insert in the Users table the names of all employees from the Employees table.
INSERT INTO  Users ([Username], [Password], [FullName], [LastLogin], [GroupID])
SELECT e.FirstName + LEFT(e.LastName, 1) + CONVERT(VARCHAR, e.HireDate), e.LastName + 'ova', e.FirstName + e.LastName, GETDATE(), 1
FROM Employees e

--23.Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET Password = NULL
WHERE DATEDIFF(DAY, LastLogin, '10.03.2010') > 0

--24.Write a SQL statement that deletes all users without passwords (NULL password).
DELETE Users
WHERE Password = NULL

--25.Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(e.Salary) [AverageSalary]
FROM Employees e	
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

--26.Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT e.FirstName + ' ' + e.LastName [Name], MIN(e.Salary) [MinimalSalary]
FROM Employees e	
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName


--27.Write a SQL query to display the town where maximal number of employees work.

--28.Write a SQL query to display the number of managers from each town.

--29.Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--Don't forget to define identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Date DATETIME NOT NULL,
	Task NCHAR(20) NOT NULL,
	Hours INT NOT NULL,
	Comments VARCHAR(50)
);

ALTER TABLE WorkHours
ADD EmployeeId INT FOREIGN KEY REFERENCES Employees(EmployeeID)

--30.Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--At the end rollback the transaction.

--31.Start a database transaction and drop the table EmployeesProjects.
--Now how you could restore back the lost table data?

--32.Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.