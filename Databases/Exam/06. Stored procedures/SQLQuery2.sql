USE Computers
GO

CREATE PROC dbo.usp_GetComputersWithGpuAndRamBetween @Id INT, @MinMemory NCHAR, @MaxMemory NCHAR
AS
	SELECT c.Id, c.Vendor, c.Model
	FROM Computer c
	WHERE c.GPUId = @Id AND c.Memory > @MinMemory AND c.Memory < @MaxMemory
GO

EXEC usp_GetComputersWithGpuAndRamBetween @Id=2, @MinMemory="8GB", @MaxMemory="16GB"