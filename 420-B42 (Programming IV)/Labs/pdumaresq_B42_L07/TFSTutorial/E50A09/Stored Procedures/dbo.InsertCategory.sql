SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[InsertCategory]
	@CategoryID varchar(10), 
	@ShortName varchar(15), 
	@LongName varchar(50)
AS
	INSERT INTO Categories 
    (CategoryID, ShortName, LongName) 
    VALUES(@CategoryID, @ShortName, @LongName)
	RETURN
GO
