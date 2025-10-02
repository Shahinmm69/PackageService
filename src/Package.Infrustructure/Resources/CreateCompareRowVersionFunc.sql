CREATE FUNCTION CompareRowVersions(@a VARBINARY(8), @b VARBINARY(8))
RETURNS INT
AS
BEGIN
    RETURN CASE 
        WHEN @a = @b THEN 0
        WHEN @a > @b THEN 1
        ELSE -1
    END
END
GO