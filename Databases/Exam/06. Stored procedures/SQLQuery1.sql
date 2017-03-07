USE Computers
GO

CREATE PROC dbo.usp_GetComputersWithRamBetween @MinMemory NCHAR, @MaxMemory NCHAR
AS
	SELECT c.Id, c.Vendor, c.Model
	FROM Computer c
	WHERE c.Memory > @MinMemory AND c.Memory < @MaxMemory
GO

EXEC usp_GetComputersWithRamBetween @MinMemory="1GB", @MaxMemory="8GB"