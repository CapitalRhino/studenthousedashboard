USE dbi509645
GO

INSERT INTO UserRole ([Role])
VALUES
	('TENANT'),
	('MANAGER'),
	('ADMIN')
GO

INSERT INTO Users ([Name], [Password], [Role])
VALUES
	('Admin', '1234', 2),
	('Manager', '1234', 1),
	('Room1', '1234', 0)
GO

SELECT * FROM Users u JOIN UserRole r ON u.[Role] = r.ID