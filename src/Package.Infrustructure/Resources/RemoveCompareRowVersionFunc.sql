IF EXISTS (SELECT * FROM sys.objects WHERE type = 'FN' AND name = 'CompareRowVersions')
	BEGIN
	    DROP FUNCTION CompareRowVersions
	END
GO