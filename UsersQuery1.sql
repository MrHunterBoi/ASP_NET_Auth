DROP TABLE IF EXISTS dbo.Users;

CREATE TABLE Users(
	Uid int not null IDENTITY(1,1),
	UserName nvarchar(256) not null,
	Password nvarchar(256) not null,
);

INSERT INTO Users VALUES
	(N'Користувач1','1234'),
	(N'Користувач2','1234'),
	(N'Користувач3','1234'),
	(N'Користувач4','1234'),
	(N'Marus','mypass');