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
  [ImageUrl] nvarchar(255),
  [UserPhone] nvarchar NOT NULL

  Constraint UQ_firebaseUserId UNIQUE(firebaseUserId)
)
GO

CREATE TABLE [Contact]
(
  [Id] int PRIMARY KEY IDENTITY,
  [UserId] int NOT NULL,
  [Name] nvarchar(50) NOT NULL,
  [ContactPhone] int NOT NULL

    CONSTRAINT [FK_Contact_User] FOREIGN KEY ([userId]) REFERENCES [User]([id])

)
GO

CREATE TABLE [FriendJoin]
(
  [Id] int PRIMARY KEY IDENTITY,
  [User1Id] int NOT NULL,
  [User2Id] int NOT NULL

    CONSTRAINT [FK_FriendJoin_User] FOREIGN KEY ([user1Id]) REFERENCES [User]([id]),
     FOREIGN KEY ([user2Id]) REFERENCES [User]([id])
)
GO

CREATE TABLE [UserMessage]
(
  [Id] int PRIMARY KEY IDENTITY,
  [UserId] int NOT NULL,
  [ContactId] int NOT NULL,
  [InputMessage] nvarchar(25) NOT NULL,
  [OutputMessage] nvarchar(500) NOT NULL

    CONSTRAINT [FK_UserMessage_User] FOREIGN KEY ([userId]) REFERENCES [User]([id]),
    CONSTRAINT [FK_UserMessage_Contact] FOREIGN KEY ([contactId]) REFERENCES [Contact]([id])

)
GO

CREATE TABLE [DefaultMessage]
(
  [Id] int PRIMARY KEY IDENTITY,
  [InputMessage] nvarchar(25) NOT NULL,
  [OutputMessage] nvarchar(500) NOT NULL
)
GO



CREATE TABLE [DefaultActive]
(
  [Id] int PRIMARY KEY IDENTITY,
  [MessageId] int NOT NULL,
  [UserId] int NOT NULL,
  [Active] bit NOt Null

    CONSTRAINT [FK_DefaultActive_User] FOREIGN KEY ([userId]) REFERENCES [User] ([id]),
    CONSTRAINT [FK_DefaultActive_DefaultMessage] FOREIGN KEY ([messageId]) REFERENCES [DefaultMessage] ([id])

)
GO

