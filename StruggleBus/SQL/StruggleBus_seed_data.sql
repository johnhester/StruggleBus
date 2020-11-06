USE [StruggleBus]
GO

set identity_insert [User] ON
insert into [User]
    (Id, FirebaseUserId, UserName, Email, FirstName, LastName, UserPhone)
Values
    (1, 't9p88AmJUZUSDQusCW366vjqNHd2', 'user', 'user@gmail.com', 'Dann', 'User', '+12567623851');
insert into [User]
    (Id, FirebaseUserId, UserName, Email, FirstName, LastName, UserPhone)
Values
    (2, 'FTGDXUXqjuhbe97WgNIl4LDETHu2', 'testy', 'testy@moody.net', 'Testy', 'McTest', '+16152748399');

set identity_insert [User] OFF


