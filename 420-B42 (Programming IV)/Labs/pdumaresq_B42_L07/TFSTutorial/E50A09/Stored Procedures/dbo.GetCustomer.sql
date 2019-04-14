SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetCustomer]
	(@Email varchar(25))
AS
	SELECT Email, LastName, FirstName, Address, 
		City, State, ZipCode, PhoneNumber
	FROM Customers
	WHERE Email = @Email

	RETURN
GO
