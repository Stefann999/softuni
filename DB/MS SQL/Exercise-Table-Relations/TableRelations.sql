CREATE DATABASE [TableRelations]

GO

USE [TableRelations]

GO

--01. One-To-One Relationship

CREATE TABLE [Passports]
(
	PassportID INT NOT NULL IDENTITY(101,1),
	PassportNumber NVARCHAR(20) NOT NULL
)

ALTER TABLE [Passports]
ADD CONSTRAINT PK_PassportID
PRIMARY KEY (PassportID)

INSERT INTO [Passports] VALUES
    ('N34FG21B'),
    ('K65LO4R7'),
    ('ZE657QP2')

CREATE TABLE [Persons]
(
	PersonID INT NOT NULL IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(8,2) NOT NULL,
	PassportID INT NOT NULL
)

ALTER TABLE [Persons]
ADD CONSTRAINT PK_PersonID
PRIMARY KEY (PersonID)

ALTER TABLE [Persons]
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportID)
REFERENCES [Passports](PassportID)

INSERT INTO [Persons] VALUES
('Roberto', 43300.00,102),
('Tom', 56100.00,103),
('Yana', 60200.00,101)



-- 02. One-To-Many Relationship

CREATE TABLE [Manufacturers]
(
[ManufacturerID] INT NOT NULL IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
[EstablishedOn] DATE NOT NULL
CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerID)
)

INSERT INTO Manufacturers VALUES
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')

CREATE TABLE [Models]
(ModelID INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(50) NOT NULL,
[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers](ManufacturerID),
)
INSERT INTO [Models] VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)



-- 03. Many-To-Many Relationship

CREATE TABLE [Students]
(	
	[StudentID] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
)

INSERT INTO [Students] VALUES
	('Mila'),
	('Toni'),
	('Ron')


CREATE TABLE [Exams]
(
	[ExamID] INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
)

INSERT INTO [Exams] VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')


CREATE TABLE [StudentsExams]
(
	[StudentID] INT NOT NULL
		FOREIGN KEY REFERENCES [Students](StudentID),
	[ExamID] INT NOT NULL
		FOREIGN KEY REFERENCES [Exams](ExamID),
	CONSTRAINT PK_StudentsExams 
		PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO [StudentsExams] VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)



-- 04. Self-Referencing 

CREATE TABLE [Teachers]
(	
	[TeacherID] INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT
		FOREIGN KEY REFERENCES [Teachers](TeacherID)
)

INSERT INTO [Teachers] VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

-- 05. Online Store Database

CREATE TABLE [Cities]
(
	[CityID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers]
(
	[CustomerID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE NOT NULL,
	[CityID] INT NOT NULL 
		FOREIGN KEY REFERENCES [Cities](CityID)
)

CREATE TABLE [Orders]
(
	[OrderID] INT PRIMARY KEY NOT NULL,
	[CustomerID] INT NOT NULL
		FOREIGN KEY REFERENCES [Customers](CustomerID)
)

CREATE TABLE [ItemTypes]
(
	[ItemTypeID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items]
(
	[ItemID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT NOT NULL
		FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID)
)

CREATE TABLE [OrderItems]
(
	[OrderID] INT NOT NULL 
		FOREIGN KEY REFERENCES [Orders](OrderID),
	[ItemID] INT NOT NULL
		FOREIGN KEY REFERENCES [Items](ItemID)
	CONSTRAINT PK_OrderItems
		PRIMARY KEY (OrderID, ItemID)
)


CREATE DATABASE [TableRelations2]

GO

USE [TableRelations2]

GO

-- 06. University Database

CREATE TABLE [Majors]
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Subjects]
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SujbectName NVARCHAR(50) NOT NULL
)

CREATE TABLE [Students]
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumeber INT NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES [Majors](MajorID)
)
CREATE TABLE [Agenda]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students] (StudentID),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects] (SubjectID),
	CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE [Payments]
(
	[PaymentID] INT NOT NULL PRIMARY KEY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(6, 2),
	[StudentID] INT NOT NULL FOREIGN KEY REFERENCES [Students] (StudentID)
)