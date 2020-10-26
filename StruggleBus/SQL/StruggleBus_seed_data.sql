USE [StruggleBus]
GO

set identity_insert [User] ON
insert into [User]
    (id, firebaseId, userName, email, firstName, lastName, imageUrl, userPhone)
Values
    (1, 't9p88AmJUZUSDQusCW366vjqNHd2', 'user', 'user@gmail.com', 'User', 'Dan', 'https://img.icons8.com/cute-clipart/2x/user-male.png', '12567623851');
insert into [User]
    (id, firebaseId, userName, email, firstName, lastName, imageUrl, userPhone)
Values
    (1, 'FTGDXUXqjuhbe97WgNIl4LDETHu2', 'testy', 'testy@moody.net', 'Testy', 'McTest', 'https://img.icons8.com/dusk/2x/user-male.png', '12567623851');

set identity_insert [User] OFF


set identity_insert [Contact] ON
set IDENTITY_INSERT [Contact] OFF