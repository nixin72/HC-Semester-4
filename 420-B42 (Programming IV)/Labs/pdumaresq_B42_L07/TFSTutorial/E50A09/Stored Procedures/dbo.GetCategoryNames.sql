SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetCategoryNames] 
AS
	/* SET NOCOUNT ON */ 
	SELECT CategoryID, ShortName
	FROM Categories
	ORDER BY ShortName
	
	RETURN
GO
