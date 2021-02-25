CREATE FUNCTION dbo.FuzzyMatchString (@s1 varchar(max), @s2 varchar(max))
RETURNS int
AS
BEGIN
    DECLARE @i int, @j int;
    SET @i = 1;
    SET @j = 0;
    WHILE @i < LEN(@s1)
    BEGIN
        IF CHARINDEX(SUBSTRING(@s1,@i,2), @s2) > 0 SET @j=@j+1;
        SET @i=@i+1;
    END
    RETURN @j;
END
GO