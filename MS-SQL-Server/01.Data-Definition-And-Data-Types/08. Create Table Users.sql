CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY(1,1),
Username NVARCHAR(30) UNIQUE NOT NULL,
[Password] NVARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) CONSTRAINT CHK_Users_ProfilePicture_2MB CHECK (DATALENGTH(ProfilePicture) <= 900000),
LastLoginTime DATETIME2,
IsDeleted BIT
)

INSERT INTO Users(Username, [Password])
VALUES ('Ala', '2000-05-02'),
	   ('Bala', '2000-11-02'),
	   ('Tra', '1000-05-16'),
	   ('La', '2019-05-16'),
	   ('Laa', '2017-10-10')