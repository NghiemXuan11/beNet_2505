create database BaiTapBuoi16
use BaiTapBuoi16
go
CREATE PROCEDURE sp_AddProduct
    @Name NVARCHAR(50),
    @Description NVARCHAR(200),
    @Price DECIMAL(18, 2),
    @IsActive BIT
AS
BEGIN
    INSERT INTO Products (Name, Description, Price, IsActive)
    VALUES (@Name, @Description, @Price, @IsActive)
END
GO

CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT Id, Name, Description, Price, IsActive
    FROM Products
END
GO

CREATE PROCEDURE sp_SearchProducts
    @Name NVARCHAR(50)
AS
BEGIN
    SELECT Id, Name, Description, Price, IsActive
    FROM Products
    WHERE Name LIKE '%' + @Name + '%'
END
GO