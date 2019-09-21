CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) CONSTRAINT CHK_People_Picture_2MB CHECK (DATALENGTH(Picture) <= 2097152), 
Height NUMERIC(10,2),
[Weight] NUMERIC(10,2),
Gender CHAR(1) NOT NULL CONSTRAINT chk_val CHECK (Gender in ('m','f')),
Birthdate DATETIME2 NOT NULL,
Biography TEXT
)

INSERT INTO People([Name], Gender, Birthdate)
VALUES ('Ala', 'f', '2000-05-02'),
	   ('Bala', 'm', '2000-11-02'),
	   ('Tra', 'm', '1000-05-16'),
	   ('La', 'f', '2019-05-16'),
	   ('La', 'm', '2017-10-10')