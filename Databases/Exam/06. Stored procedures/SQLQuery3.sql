USE Computers
GO

CREATE PROC dbo.usp_GetGpusForComputerType @ComputerType NCHAR
AS
	SELECT g.Id, g.Vendor, g.Model
	FROM GPU g
	INNER JOIN Computer c
	ON g.Id = c.GPUId
	INNER JOIN ComputerType ct
	ON ct.Name=@ComputerType AND c.ComputerTypeId = ct.Id
GO

EXEC usp_GetGpusForComputerType @ComputerType = "ultrabook"