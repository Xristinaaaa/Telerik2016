--1
--CREATE TABLE Cities 
--(
--	CityId INT PRIMARY KEY IDENTITY,
--	NAME NVARCHAR(15)
--);

--2
--INSERT INTO Cities
--SELECT City
--	FROM Employees
--	WHERE City IS NOT NULL
--UNION
--SELECT City
--	FROM Customers 
--	WHERE City IS NOT NULL
--UNION
--SELECT City
--	FROM Suppliers 
--	WHERE City IS NOT NULL

--3
--ALTER TABLE Employees
--ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)
--ALTER TABLE Customers
--ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)
--ALTER TABLE Suppliers
--ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)


--4
--UPDATE Employees
--SET CityId = (SELECT CityId FROM Cities WHERE Cities.NAME = Employees.City)

--UPDATE Customers
--SET CityId = (SELECT CityId FROM Cities WHERE Cities.NAME = Customers.City)

--UPDATE Suppliers
--SET CityId = (SELECT CityId FROM Cities WHERE Cities.NAME = Suppliers.City)


--5
--ALTER TABLE Cities
--ADD CONSTRAINT UniqueName UNIQUE(NAME)

--6
--INSERT INTO Cities
--SELECT DISTINCT ShipCity
--	FROM Orders 
--WHERE NOT EXISTS (SELECT NAME FROM Cities WHERE NAME = ShipCity)


----7
--ALTER TABLE Orders
--ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

--8
--EXEC sp_rename 'Orders.CityId', 'ShipCityId', 'COLUMN'

----9
--UPDATE Orders
--SET ShipCityId = (SELECT CityId FROM Cities WHERE Cities.NAME = Orders.ShipCity)

--10
--ALTER TABLE Orders
--DROP COLUMN ShipCity

--11
--CREATE TABLE Countries 
--(
--	CountryId INT PRIMARY KEY IDENTITY,
--	CountryName NVARCHAR(15)
--	UNIQUE(CountryName)
--);

--12
--ALTER TABLE Cities
--ADD CountryId INT FOREIGN KEY REFERENCES Countries(CountryId)

--13
--INSERT INTO Countries
--SELECT Country
--	FROM Employees
--	WHERE Country IS NOT NULL
--UNION
--SELECT Country
--	FROM Customers 
--	WHERE Country IS NOT NULL
--UNION
--SELECT Country
--	FROM Suppliers 
--	WHERE Country IS NOT NULL
--UNION
--SELECT ShipCountry
--	FROM Orders  
--	WHERE ShipCountry IS NOT NULL

--14