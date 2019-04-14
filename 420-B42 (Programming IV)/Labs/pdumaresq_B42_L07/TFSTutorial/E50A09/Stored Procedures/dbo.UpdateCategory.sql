SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[UpdateCategory] 
	@CategoryID varchar(10),
	@ShortName varchar(15),
	@LongName varchar(50),
	@original_CategoryID varchar(10),
	@original_ShortName varchar(15),
	@original_LongName varchar(50)
AS
	UPDATE Categories 
		SET CategoryID = @CategoryID,
            ShortName = @ShortName,
            LongName = @LongName
        WHERE CategoryID = @original_CategoryID
          AND ShortName = @original_ShortName
          AND LongName = @original_LongName
	RETURN @@ROWCOUNT
GO
