

USE AttendanceDB;
GO

-- DELETE ATTENDANCE FIRST
IF OBJECT_ID('Attendance', 'U') IS NOT NULL
DROP TABLE Attendance;
GO

-- DELETE EMPLOYEES
IF OBJECT_ID('Employees', 'U') IS NOT NULL
DROP TABLE Employees;
GO



CREATE TABLE Employees (
    EmpID VARCHAR(50) PRIMARY KEY,
    FullName VARCHAR(100)
);
GO



CREATE TABLE Attendance (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    EmpID VARCHAR(50),
    TimeIn DATETIME,
    TimeOut DATETIME,
    Status VARCHAR(20),

    FOREIGN KEY (EmpID)
    REFERENCES Employees(EmpID)
);
GO

-- =====================================
-- INSERT EMPLOYEES
-- =====================================

INSERT INTO Employees (EmpID, FullName)
VALUES
('101', 'Steven'),
('102', 'Luke'),
('103', 'Xander'),
('104', 'Love'),
('105', 'Allen'),
('106', 'Meljohn'),
('107', 'Karl');

-- =====================================
-- VIEW DATA
-- =====================================

SELECT * FROM Employees;
SELECT * FROM Attendance;