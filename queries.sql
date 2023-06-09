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
	('admin', 'admin', 2),
	('manager', 'manager', 1),
	('room1', 'room1', 0)
GO

INSERT INTO ComplaintStatus ([Status])
VALUES
	('FILED'),
	('UNDER_REVIEW'),
	('SOLVED'),
	('ARCHIVED')
GO

INSERT INTO ComplaintSeverity ([Severity])
VALUES
	('LOW'),
	('NORMAL'),
	('HIGH'),
	('URGENT')
GO

SELECT * FROM Users u JOIN UserRole r ON u.[Role] = r.ID