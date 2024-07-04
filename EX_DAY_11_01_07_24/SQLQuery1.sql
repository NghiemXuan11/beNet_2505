CREATE DATABASE BaitapBuoi11
USE BaitapBuoi11
--Bảng Student
CREATE TABLE dbo.Students (
    StudentID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);
GO
-- Bảng Classes
CREATE TABLE dbo.Classes (
    ClassID INT PRIMARY KEY,
    ClassName VARCHAR(100) NOT NULL
);
GO
-- Bảng trung gian Including để thể hiện mối quan hệ nhiều-nhiều
CREATE TABLE dbo.Including (
    StudentID INT,
    ClassID INT,
    PRIMARY KEY (StudentID, ClassID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)
);
GO
--Thêm dữ liệu vào các bảng
-- Chèn dữ liệu vào bảng Students
INSERT INTO dbo.Students (StudentID, Name) VALUES 
(1, 'Nguyen Van A'),
(2, 'Tran Thi B'),
(3, 'Le Van C');
GO
-- Chèn dữ liệu vào bảng Classes
INSERT INTO dbo.Classes (ClassID, ClassName) VALUES 
(100, 'Math'),
(101, 'Physics'),
(102, 'Chemistry');
GO
-- Chèn dữ liệu vào bảng StudentClasses
INSERT INTO dbo.Including(StudentID, ClassID) VALUES 
(1, 100), -- Nguyen Van A học lớp Math
(1, 101), -- Nguyen Van A học lớp Physics
(2, 100), -- Tran Thi B học lớp Math
(2, 102), -- Tran Thi B học lớp Chemistry
(3, 101); -- Le Van C học lớp Physics
GO
--Lấy thông tin chi tiết của 1 sinh viên
--Lấy thông tin chi tiết của sinh viên có id là 1
SELECT * FROM dbo.Students
WHERE StudentID = 1;

--Lấy danh sách lớp học của 1 sinh viên
SELECT dbo.Classes.ClassID, dbo.Classes.ClassName 
FROM dbo.Classes
INNER JOIN dbo.Including ON dbo.Classes.ClassID = dbo.Including.ClassID
WHERE dbo.Including.StudentID = 1;
