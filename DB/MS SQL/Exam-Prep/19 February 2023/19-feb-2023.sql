CREATE DATABASE [Boardgames]

GO

USE [Boardgames]

GO

-- 01. DLL

CREATE TABLE Categories
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
 Id INT PRIMARY KEY IDENTITY,
 StreetName NVARCHAR(100) NOT NULL,
 StreetNumber INT NOT NULL,
 Town VARCHAR(30) NOT NULL,
 Country VARCHAR(50) NOT NULL,
 ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(30) UNIQUE NOT NULL,
  AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL,
  Website NVARCHAR(40) NOT NULL,
  Phone NVARCHAR(20) NOT NULL
)

CREATE TABLE PlayersRanges
(
 Id INT PRIMARY KEY IDENTITY,
 PlayersMin INT NOT NULL,
 PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(30) NOT NULL,
  YearPublished INT NOT NULL,
  Rating DECIMAL(3,2) NOT NULL,
  CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
  PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
  PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
)

CREATE TABLE Creators
(
 Id INT PRIMARY KEY IDENTITY,
 FirstName NVARCHAR(30) NOT NULL,
 LastName NVARCHAR(30) NOT NULL,
 Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
 CreatorId INT FOREIGN KEY REFERENCES Creators(Id) NOT NULL,
 BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id) NOT NULL,
 PRIMARY KEY (CreatorId, BoardgameId)
)

--02. Insert

INSERT INTO Boardgames ([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId) VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers ([Name], AddressId, Website, Phone) VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

--03. Update

UPDATE PlayersRanges 
   SET PlayersMax +=1 
 WHERE Id=1 

UPDATE Boardgames 
   SET [Name]=[Name] + 'V2'
 WHERE YearPublished>=2020

--04. Delete

DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (1,16,31,47)
DELETE FROM Boardgames WHERE PublisherId IN (1,16)
DELETE FROM Publishers WHERE AddressId IN (5)
DELETE FROM Addresses WHERE LEFT(Town, 1) = 'L'

--05. Boardgames by Year of Publication

  SELECT [Name], [Rating]
    FROM Boardgames
ORDER BY YearPublished, [Name] DESC

--06. Boardgames by Category

SELECT
	b.Id,
	b.[Name],
	b.YearPublished,
	c.Name
FROM Boardgames AS b
JOIN Categories AS c
ON b.CategoryId = c.Id
WHERE c.[Name] = 'Strategy Games' OR c.[Name] = 'Wargames'
ORDER BY YearPublished DESC

--07. Creators without Boardgames

   SELECT 
	c.Id,
	CONCAT(c.FirstName, ' ', LastName) AS CreatorName,
	c.Email
	 FROM  Creators AS c
LEFT JOIN CreatorsBoardgames AS cb
	   ON c.Id = cb.CreatorId
    WHERE cb.CreatorId IS NULL
 ORDER BY CreatorName

--08. First 5 Boardgames

SELECT TOP(5)
	c.[Name],
	Rating,
	cat.[Name] AS CategoryName
FROM Boardgames AS c
LEFT JOIN Categories AS cat
	   ON c.CategoryId = cat.Id
LEFT JOIN PlayersRanges as r
	   ON c.PlayersRangeId = r.Id
    WHERE Rating > 7
	  AND c.[Name] LIKE '%a%'
	   OR Rating > 7.50
	  AND PlayersMin >= 2
	  AND PlayersMax <= 5
ORDER BY [Name], CategoryName DESC

--09. Creators with Emails

  SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	c.Email,
	MAX(b.Rating) AS Rating 
    FROM CreatorsBoardgames AS cb
    JOIN Creators AS c
	  ON cb.CreatorId=c.Id
    JOIN Boardgames AS b
	  ON cb.BoardgameId=b.Id
   WHERE Email LIKE '%.com'
GROUP BY CONCAT(c.FirstName, ' ', c.LastName), Email
ORDER BY CONCAT(c.FirstName, ' ', c.LastName)