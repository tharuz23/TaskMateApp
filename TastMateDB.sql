CREATE DATABASE TMS_DB;
GO
USE TMS_DB;
GO

CREATE TABLE Roles
(
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO Roles(RoleName) VALUES (N'OIC'),(N'CO'),(N'User');
GO

CREATE TABLE Users
(
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleID INT NOT NULL FOREIGN KEY REFERENCES Roles(RoleID),
    CreatedAt DATETIME2 DEFAULT SYSDATETIME()
);
GO

INSERT INTO Users(FullName,Username,PasswordHash,RoleID)
SELECT N'A OIC',N'aoic',N'pass123',(SELECT RoleID FROM Roles WHERE RoleName=N'OIC')
UNION ALL
SELECT N'B CO',N'bco',N'pass123',(SELECT RoleID FROM Roles WHERE RoleName=N'CO')
UNION ALL
SELECT N'C User',N'cuser',N'pass123',(SELECT RoleID FROM Roles WHERE RoleName=N'User')
UNION ALL
SELECT N'D User',N'duser',N'pass123',(SELECT RoleID FROM Roles WHERE RoleName=N'User');
GO

CREATE TABLE ActivityStatuses
(
    StatusID INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50) NOT NULL UNIQUE
);
GO

INSERT INTO ActivityStatuses(StatusName)
VALUES (N'To Do'),(N'In Progress'),(N'Done');
GO

CREATE TABLE Tasks
(
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    SupervisorUserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
    DueAt DATETIME2 NULL,
    CreatedAt DATETIME2 DEFAULT SYSDATETIME()
);
GO

INSERT INTO Tasks(Title,Description,SupervisorUserID,DueAt)
SELECT N'Check Equipment',N'Inspect all storage equipment',UserID,'2025-09-25'
FROM Users WHERE Username=N'aoic';
GO

INSERT INTO Tasks(Title,Description,SupervisorUserID,DueAt)
SELECT N'Prepare Report',N'Daily status report',UserID,'2025-09-28'
FROM Users WHERE Username=N'bco';
GO

CREATE TABLE UserActivities
(
    ActivityID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL FOREIGN KEY REFERENCES Users(UserID),
    TaskID INT NOT NULL FOREIGN KEY REFERENCES Tasks(TaskID),
    StatusID INT NOT NULL FOREIGN KEY REFERENCES ActivityStatuses(StatusID),
    SubmittedAt DATETIME2 DEFAULT SYSDATETIME(),
    CONSTRAINT UQ_User_Task UNIQUE(UserID,TaskID)
);
GO

INSERT INTO UserActivities(UserID,TaskID,StatusID)
SELECT u.UserID,1,(SELECT StatusID FROM ActivityStatuses WHERE StatusName=N'To Do')
FROM Users u WHERE u.Username=N'cuser';
GO

INSERT INTO UserActivities(UserID,TaskID,StatusID)
SELECT u.UserID,2,(SELECT StatusID FROM ActivityStatuses WHERE StatusName=N'In Progress')
FROM Users u WHERE u.Username=N'duser';
GO

CREATE VIEW v_AdminTasks
AS
SELECT t.TaskID AS TaskNo,
       t.Title,
       t.Description,
       (u.FullName+N' ('+r.RoleName+N')') AS Supervisor,
       t.DueAt
FROM Tasks t
JOIN Users u ON u.UserID=t.SupervisorUserID
JOIN Roles r ON r.RoleID=u.RoleID;
GO

CREATE PROCEDURE sp_UserActivity_Upsert
    @Username NVARCHAR(50),
    @TaskID INT,
    @StatusName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @UserID INT=(SELECT UserID FROM Users WHERE Username=@Username);
    DECLARE @StatusID INT=(SELECT StatusID FROM ActivityStatuses WHERE StatusName=@StatusName);
    IF EXISTS(SELECT 1 FROM UserActivities WHERE UserID=@UserID AND TaskID=@TaskID)
        UPDATE UserActivities
        SET StatusID=@StatusID,SubmittedAt=SYSDATETIME()
        WHERE UserID=@UserID AND TaskID=@TaskID;
    ELSE
        INSERT INTO UserActivities(UserID,TaskID,StatusID)
        VALUES(@UserID,@TaskID,@StatusID);
END;
GO

SELECT * FROM Roles;
SELECT * FROM Users;
SELECT * FROM Tasks;
SELECT * FROM ActivityStatuses;
SELECT * FROM UserActivities;

ALTER TABLE Tasks
ADD IsLocked BIT DEFAULT 0,
    CreatedBy NVARCHAR(50) NULL;
GO

UPDATE Tasks
SET CreatedBy = 'aoic'
WHERE SupervisorUserID = (SELECT UserID FROM Users WHERE Username='aoic');

UPDATE Tasks
SET CreatedBy = 'bco'
WHERE SupervisorUserID = (SELECT UserID FROM Users WHERE Username='bco');
GO

DROP VIEW v_AdminTasks;
GO

CREATE VIEW v_AdminTasks
AS
SELECT 
    t.TaskID AS TaskNo,
    t.Title,
    t.Description,
    (u.FullName + N' (' + r.RoleName + N')') AS Supervisor,
    t.DueAt,
    t.IsLocked,
    t.CreatedBy
FROM Tasks t
JOIN Users u ON u.UserID = t.SupervisorUserID
JOIN Roles r ON r.RoleID = u.RoleID;
GO

