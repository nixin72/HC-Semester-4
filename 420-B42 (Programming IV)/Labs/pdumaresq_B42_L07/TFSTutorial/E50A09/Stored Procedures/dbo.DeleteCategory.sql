SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
	@CategoryID varchar(10),
	@original_ShortName varchar(15),
	@original_LongName varchar(50)
AS
	DELETE FROM Categories 
        WHERE CategoryID = @CategoryID
		AND ShortName = @original_ShortName
        AND LongName = @original_LongName
	RETURN @@ROWCOUNT
GO
