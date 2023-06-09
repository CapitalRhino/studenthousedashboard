USE dbi509645
GO

-- User roles
INSERT INTO UserRole ([Role])
VALUES
	('TENANT'),
	('MANAGER'),
	('ADMIN')
GO

-- Default users
INSERT INTO Users ([Name], [Password], [Role])
VALUES
	('admin', 'admin', 2),
	('manager', 'manager', 1),
	('room1', 'room1', 0)
GO

-- Complaint status
INSERT INTO ComplaintStatus ([Status])
VALUES
	('FILED'),
	('UNDER_REVIEW'),
	('SOLVED'),
	('ARCHIVED')
GO

-- Complaint severity
INSERT INTO ComplaintSeverity ([Severity])
VALUES
	('LOW'),
	('NORMAL'),
	('HIGH'),
	('URGENT')
GO