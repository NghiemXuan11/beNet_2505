create database BaiTapBuoi14
use BaiTapBuoi14
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name NVARCHAR(100) NOT NULL
);

CREATE TABLE GroupAttribute(
    group_id INT PRIMARY KEY,
	group_name NVARCHAR(100) NOT NULL,
	price NVARCHAR(100) NOT NULL,
);
CREATE TABLE attribute (
    attribute_id INT PRIMARY KEY,
    attribute_name NVARCHAR(100) NOT NULL,
	attribute_value NVARCHAR(100) NOT NULL,
	group_id INT, 
	FOREIGN KEY (group_id) REFERENCES GroupAttribute(group_id) 
);

CREATE TABLE ProductAttribute(
    product_id INT,
	attribute_id INT,
	PRIMARY KEY (product_id, attribute_id),
	FOREIGN KEY (product_id) REFERENCES products(product_id),
	FOREIGN KEY (attribute_id) REFERENCES attribute(attribute_id)
);
go


--Tạo Store Procedure

-- Store Procedure để thêm sản phẩm
CREATE PROCEDURE AddProduct
    @product_id INT,
    @product_name NVARCHAR(100)
AS
BEGIN
    INSERT INTO products (product_id, product_name)
    VALUES (@product_id, @product_name)
END
go
-- Store Procedure để sửa sản phẩm
CREATE PROCEDURE UpdateProduct
    @product_id INT,
    @product_name NVARCHAR(100)
AS
BEGIN
    UPDATE products
    SET product_name = @product_name
    WHERE product_id = @product_id
END
go
-- Store Procedure để xóa sản phẩm
CREATE PROCEDURE DeleteProduct
    @product_id INT
AS
BEGIN
    DELETE FROM products
    WHERE product_id = @product_id
END
go
-- Tương tự tạo Store Procedure cho GroupAttribute và Attribute
-- Store Procedure để thêm GroupAttribute
CREATE PROCEDURE AddGroupAttribute
    @group_id INT,
    @group_name NVARCHAR(100),
    @price NVARCHAR(100)
AS
BEGIN
    INSERT INTO GroupAttribute (group_id, group_name, price)
    VALUES (@group_id, @group_name, @price)
END
go
-- Store Procedure để sửa GroupAttribute
CREATE PROCEDURE UpdateGroupAttribute
    @group_id INT,
    @group_name NVARCHAR(100),
    @price NVARCHAR(100)
AS
BEGIN
    UPDATE GroupAttribute
    SET group_name = @group_name,
        price = @price
    WHERE group_id = @group_id
END
go
-- Store Procedure để xóa GroupAttribute
CREATE PROCEDURE DeleteGroupAttribute
    @group_id INT
AS
BEGIN
    DELETE FROM GroupAttribute
    WHERE group_id = @group_id
END
go
-- Store Procedure để thêm Attribute
CREATE PROCEDURE AddAttribute
    @attribute_id INT,
    @attribute_name NVARCHAR(100),
    @attribute_value NVARCHAR(100),
    @group_id INT
AS
BEGIN
    INSERT INTO attribute (attribute_id, attribute_name, attribute_value, group_id)
    VALUES (@attribute_id, @attribute_name, @attribute_value, @group_id)
END
go
-- Store Procedure để sửa Attribute
CREATE PROCEDURE UpdateAttribute
    @attribute_id INT,
    @attribute_name NVARCHAR(100),
    @attribute_value NVARCHAR(100),
    @group_id INT
AS
BEGIN
    UPDATE attribute
    SET attribute_name = @attribute_name,
        attribute_value = @attribute_value,
        group_id = @group_id
    WHERE attribute_id = @attribute_id
END
go
-- Store Procedure để xóa Attribute
CREATE PROCEDURE DeleteAttribute
    @attribute_id INT
AS
BEGIN
    DELETE FROM attribute
    WHERE attribute_id = @attribute_id
END

