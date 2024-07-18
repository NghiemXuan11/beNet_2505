CREATE DATABASE BaiTapBuoi15
USE BaiTapBuoi15
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2) NOT NULL,
    IsActive BIT NOT NULL
);

drop table Products