CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY,
[Name] VARCHAR,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] VARCHAR
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

ALTER TABLE Towns 
ALTER COLUMN [Name] VARCHAR (30)

ALTER TABLE Minions 
ALTER COLUMN [Name] VARCHAR (30)

INSERT INTO Towns(Id, [Name])
VALUES  (1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES(1, 'Kevin', 22, 1),
      (2, 'Bob', 15, 3),
      (3, 'Steward', NULL, 2)

TRUNCATE TABLE Minions

DROP TABLE Minions, Towns
