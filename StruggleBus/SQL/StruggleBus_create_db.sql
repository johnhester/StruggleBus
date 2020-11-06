USE [master]

IF db_id('StruggleBus') IS NULL 
  CREATE DATABASE [StruggleBus]
GO

USE [StruggleBus]
GO

DROP TABLE IF EXISTS [DefaultActive];
DROP TABLE IF EXISTS [UserMessage];
DROP TABLE IF EXISTS [DefaultMessage];
DROP TABLE IF EXISTS [FriendJoin];
DROP TABLE IF EXISTS [Contact];
DROP TABLE IF EXISTS [User];
GO

CREATE TABLE [User]
(
  [Id] int PRIMARY KEY IDENTITY,
  [FirebaseUserId] nvarchar(28) NOT NULL,
  [UserName] nvarchar(50) UNIQUE NOT NULL,
  [Email] nvarchar(255) UNIQUE NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [UserPhone] nvarchar(15) NOT NULL

  Constraint UQ_firebaseUserId UNIQUE(firebaseUserId)
)
GO


CREATE TABLE [UserMessage]
(
  [Id] int PRIMARY KEY IDENTITY,
  [UserId] int NOT NULL,
  [Message] nvarchar(500) NOT NULL

    CONSTRAINT [FK_UserMessage_User] FOREIGN KEY ([userId]) REFERENCES [User]([id])
                                    

)
GO



