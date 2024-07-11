CREATE DATABASE BaiTapBuoi13
use BaiTapBuoi13
-- Tạo bảng Category
CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(255) NOT NULL
);

-- Tạo bảng Product
CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryID INT NOT NULL,
    ProductName NVARCHAR(255) NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID)
);

-- Tạo bảng ProductVariant
CREATE TABLE ProductVariant (
    VariantID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    Configuration NVARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
go
-- Stored Procedure thêm sản phẩm
CREATE PROCEDURE AddProduct
    @CategoryID INT,
    @ProductName NVARCHAR(255)
AS
BEGIN
    INSERT INTO Product (CategoryID, ProductName)
    VALUES (@CategoryID, @ProductName)
END
go
-- Stored Procedure sửa sản phẩm
CREATE PROCEDURE UpdateProduct
    @ProductID INT,
    @ProductName NVARCHAR(255)
AS
BEGIN
    UPDATE Product
    SET ProductName = @ProductName
    WHERE ProductID = @ProductID
END
go
-- Stored Procedure xóa sản phẩm
CREATE PROCEDURE DeleteProduct
    @ProductID INT
AS
BEGIN
    DELETE FROM Product
    WHERE ProductID = @ProductID
END
go
-- Stored Procedure thêm biến thể sản phẩm
CREATE PROCEDURE AddProductVariant
    @ProductID INT,
    @Configuration NVARCHAR(255),
    @Price DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO ProductVariant (ProductID, Configuration, Price)
    VALUES (@ProductID, @Configuration, @Price)
END
go
-- Stored Procedure sửa biến thể sản phẩm
CREATE PROCEDURE UpdateProductVariant
    @VariantID INT,
    @Configuration NVARCHAR(255),
    @Price DECIMAL(18, 2)
AS
BEGIN
    UPDATE ProductVariant
    SET Configuration = @Configuration, Price = @Price
    WHERE VariantID = @VariantID
END
go
-- Stored Procedure xóa biến thể sản phẩm
CREATE PROCEDURE DeleteProductVariant
    @VariantID INT
AS
BEGIN
    DELETE FROM ProductVariant
    WHERE VariantID = @VariantID
END

-- Thêm danh mục
INSERT INTO Category (CategoryName)
VALUES ('Laptops'), ('Desktops'), ('Accessories');

-- Thêm sản phẩm
INSERT INTO Product (CategoryID, ProductName)
VALUES 
(1, 'DELL X1'),
(1, 'HP Spectre'),
(2, 'Lenovo ThinkCentre');

-- Thêm biến thể sản phẩm
INSERT INTO ProductVariant (ProductID, Configuration, Price)
VALUES 
(1, 'core i5 - 15inch - 8GB RAM', 10000000),
(1, 'core i7 - 15inch - 16GB RAM', 15000000),
(1, 'core i9 - 15inch - 32GB RAM', 20000000),
(2, 'core i5 - 14inch - 8GB RAM', 12000000),
(2, 'core i7 - 14inch - 16GB RAM', 17000000),
(3, 'core i3 - 21inch - 4GB RAM', 9000000),
(3, 'core i5 - 21inch - 8GB RAM', 13000000);
go
-- Stored Procedure lấy tất cả sản phẩm
CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT ProductID, CategoryID, ProductName FROM Product
END
go
-- Stored Procedure lấy tất cả biến thể sản phẩm
CREATE PROCEDURE GetAllProductVariants
AS
BEGIN
    SELECT VariantID, ProductID, Configuration, Price FROM ProductVariant
END


