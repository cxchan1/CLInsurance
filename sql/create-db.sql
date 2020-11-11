USE master
GO

CREATE DATABASE NudeDB;
GO

USE NudeDB
GO

CREATE TABLE Category
(
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Active bit NOT NULL DEFAULT (1),
);
GO

CREATE TABLE Item(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Price Decimal(19,4) NOT NULL,
	DateCreated DATETIME NOT NULL DEFAULT (GETDATE()),
	Active bit NOT NULL DEFAULT (1),
    	CONSTRAINT FK_Item_ToCategory FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);
GO

INSERT INTO Category(Name) VALUES ('Electronic');
INSERT INTO Category(Name) VALUES ('Clothing');
INSERT INTO Category(Name) VALUES ('Kitchen');
INSERT INTO Item(CategoryId,Name,Price) VALUES (2, 'Jeans', 1100);
INSERT INTO Item(CategoryId,Name,Price) VALUES (1, 'Computer', 2000);
