--CREATE DATABASE Cinema
--USE Cinema

CREATE TABLE Genres(
	Id int identity(1,1) PRIMARY KEY,
	Name nvarchar(255)
)

INSERT INTO Genres(Name)
	VALUES('Comedy'),
	      ('Drama'),
		  ('Action'),
		  ('Fantasy'),
		  ('Historical'),
		  ('Horror')

CREATE TABLE Films(
	Id int identity(1,1) PRIMARY KEY,
	Name nvarchar(255),
	RelaseDate DATE
)

INSERT INTO Films (Name,RelaseDate)
	VALUES ('Trading Places','2022-04-13'),
	       ('Boydood','2019-07-19'),
		   ('Black Panther','2010-11-02'),
		   ('The Purple Rose Of Cairo','2008-01-23'),
		   ('Blood Diamond','2016-03-30'),
		   ('Dabbe','2020-09-15')

CREATE TABLE FilmsGenres(
	Id int identity(1,1) PRIMARY KEY,
	FilmsId int references Films(Id),
	GenresId int references Genres(Id)
)

INSERT INTO FilmsGenres(FilmsId,GenresId)
	VALUES (1,1),
		   (2,2),
		   (3,3),
		   (4,4),
		   (5,5),
		   (6,6)

CREATE TABLE Actors(
	Id int identity(1,1) PRIMARY KEY,
	Name nvarchar(255),
	Surname nvarchar(255),
	Age int
)

SELECT * FROM FilmsGenres

INSERT INTO Actors(Name,Surname,Age)
	VALUES ('Anar','Qandayev',21),
	       ('Semseddin','Amanov',20),
		   ('Zulfiyye','Huseynova',19),
		   ('Sebine','Novruzova',22),
		   ('Guler','Resulova',23),
		   ('Aysu','Memmedova',19)

CREATE TABLE FilmsActors(
	Id int identity(1,1) PRIMARY KEY,
	FilmsId int references Films(Id),
	ActorsId int references Actors(Id),
)

INSERT INTO FilmsActors(FilmsId,ActorsId)
	VALUES (1,1),
		   (2,2),
		   (3,3),
		   (4,4),
		   (5,5),
		   (6,6)

CREATE TABLE Halls(
	Id int identity(1,1) PRIMARY KEY,
	Name nvarchar(255),
	SeatCount int
)

INSERT INTO Halls(Name,SeatCount)
	VALUES ('Zal 1',60), 
		   ('Zal 2',40),
		   ('Zal 3',56),
		   ('Zal 4',39),
		   ('Zal 5',47),
		   ('Zal 6',29)

CREATE TABLE Customers(
	Id int identity(1,1) PRIMARY KEY,
	Name nvarchar(255),
	Surname nvarchar(255),
	Age int
)

INSERT INTO Customers(Name,Surname,Age)
	VALUES ('Ali','Aliyev',19),
	       ('Vusal','Abdurahmanov',20),
		   ('Dunyamali','Abdullayev',21),
		   ('Esger','Babayev',21),
		   ('Sadiq','Qasimzade',22),
		   ('Nicat','Memmedova',23)

CREATE TABLE [Sessions](
	Id int identity(1,1) PRIMARY KEY,
	Time TIME
)

INSERT INTO [Sessions](Time)
	VALUES ('23:59:59'),
		   ('18:45:59'),
		   ('20:29:59'),
		   ('17:40:59'),
		   ('11:25:59'),
		   ('15:34:59')

CREATE TABLE Tickest(
	Id int identity(1,1) PRIMARY KEY,
	SoldDate DATETIME,
	Price DECIMAL,
	Place int,
	CustomersId int references Customers(Id),
	HallId int references Halls(Id),
	FilmId int references Films(Id),
	SessionsId int references [Sessions](Id)
)

INSERT INTO Tickest(SoldDate,Price,Place,CustomersId,HallId,FilmId,SessionsId)
	VALUES ('2022-04-12 13:20:00',10.50,4,1,1,1,1),
	       ('2022-01-06 23:40:00',8,3,2,2,2,2),
		   ('2021-04-12 12:25:00',5.70,16,3,3,3,3),
		   ('2021-11-23 10:50:00',7.20,20,4,4,4,4),
		   ('2020-07-30 17:30:00',12,40,5,5,5,5),
		   ('2019-10-04 21:15:00',18.20,28,6,6,6,6)


CREATE TABLE InsertTickets(
	Id int identity(1,1) PRIMARY KEY,
	CustomersId int references Customers(Id),
	HallId int references Halls(Id),
	FilmId int references Films(Id),
	SessionsId int references [Sessions](Id)
)



CREATE PROCEDURE usp_BuyTicket
  (@HallId  INTEGER,
   @SessionsId INTEGER,
   @FilmId  INTEGER,
   @CustomerId INTEGER
   
   )

--Query 1
CREATE PROCEDURE usp_BuyTicket (@HallId int , @SessionId int , @FilmId int, @CustomerId int )
AS
IF EXISTS (SELECT * FROM InsertTickets WHERE HallId =@HallId AND SessionsId=@SessionId AND FilmId= @FilmId AND CustomersId=@CustomerId)
BEGIN 
PRINT 'Yer doludur'
END
ELSE 
INSERT INTO InsertTickets(HallId,SessionsId,FilmId,CustomersId)
VALUES (@HallId, @SessionId, @FilmId, @CustomerId)

EXEC usp_BuyTicket 1,1,1,1

SELECT * FROM InsertTickets



--Query 2

CREATE FUNCTION dbo.GetEmptySeat (@HallId int, @SessionsId int)
RETURNS int
AS
BEGIN
DECLARE @SeatCount int
SELECT @SeatCount=Halls.SeatCount - COUNT ([Sessions].Id) FROM InsertTickets
JOIN Halls
ON InsertTickets.HallId=Halls.Id
JOIN [Sessions]
ON InsertTickets.SessionsId=[Sessions].Id
GROUP BY Halls.SeatCount, [Sessions].Id
RETURN @SeatCount
END


SELECT dbo.GetEmptySeat (1,1)





