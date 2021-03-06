USE [master]
GO

CREATE DATABASE [BankAccounts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankAccounts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BankAccounts.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BankAccounts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BankAccounts_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BankAccounts] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankAccounts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankAccounts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankAccounts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankAccounts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankAccounts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankAccounts] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankAccounts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BankAccounts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankAccounts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankAccounts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankAccounts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankAccounts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankAccounts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankAccounts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankAccounts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankAccounts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BankAccounts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankAccounts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankAccounts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankAccounts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankAccounts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankAccounts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BankAccounts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankAccounts] SET RECOVERY FULL 
GO
ALTER DATABASE [BankAccounts] SET  MULTI_USER 
GO
ALTER DATABASE [BankAccounts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankAccounts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankAccounts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankAccounts] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BankAccounts] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BankAccounts', N'ON'
GO
ALTER DATABASE [BankAccounts] SET  READ_WRITE 
GO

--1.Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--Insert few records for testing.
--Write a stored procedure that selects the full names of all persons.

CREATE TABLE Persons 
(
	Id INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	SSN VARCHAR(10) NOT NULL
);

CREATE TABLE Accounts 
(
	Id INT PRIMARY KEY NOT NULL,
	PersonId INT NOT NULL,
	Balance VARCHAR(20) NOT NULL,
	CONSTRAINT FK_Accounts_PersonId FOREIGN KEY(PersonId)
		REFERENCES Persons(Id)
);

INSERT INTO Persons VALUES (1, 'Ivan', 'Ivanov', '780412405'), (2, 'Petar', 'Petrov', '560703303'), (3, 'Petko','Georgiev','680512207')

INSERT INTO Accounts VALUES (1, 2, '123123'), (2, 3, '13241345')
GO 

CREATE PROC usp_SelectNames
AS
BEGIN
	SELECT FirstName + ' ' + LastName [FullName]
	FROM Persons 
END
EXEC usp_SelectNames
GO

--2.Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_PersonsWithMoreMoney @Balance VARCHAR(100)
AS 
BEGIN
	SELECT p.FirstName + ' ' + p.LastName [Name], a.Balance
	FROM Persons p
	JOIN Accounts a
	ON a.PersonId = p.Id AND a.Balance > @Balance
END
EXEC usp_PersonsWithMoreMoney @Balance = 123
GO 

--3.Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.
CREATE FUNCTION fn_Sum (@initialSum MONEY, @interest DECIMAL, @months INT)
RETURNS MONEY 
AS
BEGIN
	SELECT @initialSum = @initialSum + @initialSum*((@interest/100)*(@months/12))
	RETURN @initialSum
END
GO

DECLARE @money MONEY = (SELECT Balance FROM Accounts WHERE Id=1)
PRINT dbo.fn_Sum(@money, 5, 5)
GO 

--4.Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--It should take the AccountId and the interest rate as parameters.
CREATE PROC usp_AccountInterest (@accountId INT, @interestRate DECIMAL)
AS
DECLARE @money MONEY = (SELECT Balance FROM Accounts WHERE Id=@accountId)
UPDATE Accounts
SET Balance = dbo.fn_Sum(@money, @interestRate, 1)
WHERE Id = @accountId
EXEC usp_AccountInterest @accountId=1, @interestRate=2.3
GO 

--5.Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROC usp_WithdrawMoney (@accountId INT, @money INT)
AS
DECLARE @balance MONEY = (SELECT Balance FROM Accounts WHERE Id=@accountId)
UPDATE Accounts
SET Balance -=@balance
WHERE Id = @accountId
EXEC usp_WithdrawMoney @accountId=2, @money = 333
GO

CREATE PROC usp_DepositMoney (@accountId INT, @money INT)
AS
DECLARE @balance MONEY = (SELECT Balance FROM Accounts WHERE Id=@accountId)
UPDATE Accounts
SET Balance +=@balance
WHERE Id = @accountId
EXEC usp_WithdrawMoney @accountId=2, @money = 333
GO  

--6.Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs
(
	LogID INT PRIMARY KEY IDENTITY,
	AccountID INT NOT NULL,
	OldSum INT NOT NULL,
	NewSum INT NOT NULL,
	CONSTRAINT FK_Logs_AccountID FOREIGN KEY (AccountID)
		REFERENCES Accounts(Id)		
);
GO 

CREATE TRIGGER AccountUpdate
ON Accounts
FOR UPDATE
AS
BEGIN 
	SET NOCOUNT ON 
	INSERT INTO Logs 
	SELECT i.Id, i.Balance, d.Balance
	FROM DELETED d, INSERTED i
END 
GO 

--8.Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
USE TelerikAcademy
DECLARE EmployessAndAddresses CURSOR READ_ONLY FOR
SELECT e.FirstName + ' ' + e.LastName [FullName], 
	(SELECT t.Name [Town]
	FROM TelerikAcademy.dbo.Towns t
	JOIN TelerikAcademy.dbo.Addresses a
	ON a.AddressID = e.AddressID AND a.TownID = t.TownID)
FROM TelerikAcademy.dbo.Employees e

OPEN EmployessAndAddresses
WHILE @@fetch_status= 0
FETCH NEXT FROM EmployessAndAddresses
GO 