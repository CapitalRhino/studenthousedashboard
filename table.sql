USE dbi509645
GO

CREATE TABLE UserRole (
	ID INT PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Role] NVARCHAR(255)
)
GO

CREATE TABLE Users (
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,
	[Password] NVARCHAR(4000) NOT NULL,
	[Role] INT FOREIGN KEY REFERENCES UserRole(ID) NOT NULL
)
GO

CREATE TABLE ContactForm (
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,
	Email NVARCHAR(255) NOT NULL
)
GO

CREATE TABLE Announcements (
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	[Author] INT FOREIGN KEY REFERENCES Users(ID) NOT NULL,
	[Description] NVARCHAR(MAX),
	[Title] NVARCHAR(255) NOT NULL,
	[PublishDate] DATETIME NOT NULL,
	[IsImportant] BIT NOT NULL,
	[IsSticky] BIT NOT NULL,
)
GO

CREATE TABLE Comments (
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	[Author] INT FOREIGN KEY REFERENCES Users(ID) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[Title] NVARCHAR(255) NOT NULL,
	[PublishDate] DATETIME NOT NULL
)
GO

CREATE TABLE AnnouncementsComments (
	AnnouncementID INT FOREIGN KEY REFERENCES Announcements(ID) NOT NULL,
	CommentID INT FOREIGN KEY REFERENCES Comments(ID) NOT NULL
)
GO

CREATE TABLE CommentsResponses (
	CommentID INT FOREIGN KEY REFERENCES Comments(ID) NOT NULL,
	ResponseID INT FOREIGN KEY REFERENCES Comments(ID) NOT NULL
)
GO

CREATE TABLE ComplaintStatus (
	ID INT PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Status] NVARCHAR(255)
)
GO

CREATE TABLE ComplaintSeverity (
	ID INT PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Severity] NVARCHAR(255)
)
GO

CREATE TABLE Complaints (
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	[Author] INT FOREIGN KEY REFERENCES Users(ID) NOT NULL,
	[Description] NVARCHAR(MAX),
	[Title] NVARCHAR(255) NOT NULL,
	[PublishDate] DATETIME NOT NULL,
	[Status] INT FOREIGN KEY REFERENCES ComplaintStatus(ID) NOT NULL
	[Severity] INT FOREIGN KEY REFERENCES ComplaintSeverity(ID) NOT NULL
)
GO

CREATE TABLE ComplaintsComments (
	ComplaintID INT FOREIGN KEY REFERENCES Complaints(ID) NOT NULL,
	CommentID INT FOREIGN KEY REFERENCES Comments(ID) NOT NULL
)
GO

CREATE TABLE Events (
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	[Author] INT FOREIGN KEY REFERENCES Users(ID) NOT NULL,
	[Description] NVARCHAR(MAX),
	[Title] NVARCHAR(255) NOT NULL,
	[PublishDate] DATETIME NOT NULL,
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NOT NULL
)
GO