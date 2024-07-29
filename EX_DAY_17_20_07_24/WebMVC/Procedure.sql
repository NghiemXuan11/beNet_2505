CREATE PROCEDURE sp_AuthenticateUser
    @Username NVARCHAR(256),
    @Password NVARCHAR(256)
AS
BEGIN
    SELECT Id FROM Users WHERE Email = @Username AND Password = @Password
END
