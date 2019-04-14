SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[AddOrUpdateCustomer]
	( @Email varchar(25),
	  @LastName varchar(20),
	  @FirstName varchar(20),
	  @Address varchar(40),
	  @City varchar(30),
	  @State char(2),
	  @ZipCode varchar(9),
	  @PhoneNumber varchar(20) )
AS
	BEGIN TRAN
	DELETE FROM Customers WHERE Email = @Email
	IF @@ERROR = 0
	    BEGIN
	        INSERT INTO Customers
	            (Email, LastName, FirstName, Address, 
	             City, State, ZipCode, PhoneNumber)
	        VALUES (@Email, @LastName, @FirstName, @Address,
	                @City, @State, @ZipCode, @PhoneNumber)
	        IF @@ERROR = 0
	            COMMIT TRAN
	        ELSE
	            ROLLBACK TRAN
	    END
	ELSE
	    ROLLBACK TRAN

	RETURN
GO
