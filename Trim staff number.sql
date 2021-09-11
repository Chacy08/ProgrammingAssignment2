/*
--declare @src varchar(20) = 'T1582501';
--declare @src varchar(20) = 'XAR099580';
declare @src varchar(20) = 'CT1582501';

SELECT dbo.fn_StripCharacters(@src)
*/

drop function if exists [dbo].[fn_StripCharacters];
go

CREATE FUNCTION [dbo].[fn_StripCharacters]
(
    @String NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    
	if LEFT(@String,1) = 'T'
		BEGIN
			WHILE PatIndex('%[^0-9]%', @String) > 0
				SET @String = Stuff(@String, PatIndex('%[^0-9]%', @String), 1, '')
    
			SET @String = CAST(CAST(@String AS INT) AS VARCHAR(20))
		END
	if LEFT(@String,2) = 'CT'
		BEGIN
			SET @String = 'X' + @String
		END

	RETURN @String
    
END