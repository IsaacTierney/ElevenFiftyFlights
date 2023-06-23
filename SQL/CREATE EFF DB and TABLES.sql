CREATE DATABASE ElevenFiftyFlights
GO
USE ElevenFiftyFlights
-- Users - Isaac
CREATE TABLE Users
(
[Id] INT PRIMARY KEY IDENTITY(1,1),
[FullName] NVARCHAR(100),
[Email] NVARCHAR(100) NOT NULL,
[Phone#] INT NOT NULL,
)
GO
-- Airlines - Shelby
CREATE TABLE Airlines
(
    [Id] INT PRIMARY KEY IDENTITY (1,1),
    [Name] NVARCHAR,
    [BaseTicketPrice] FLOAT,
)
GO
-- Airports - Edwin
CREATE TABLE Airports
(
    [Id] INT PRIMARY KEY IDENTITY (1,1),
    [City] NCHAR,
    [State] NVARCHAR,
    [Name] NVARCHAR
)
GO
-- Flights
CREATE TABLE Flights
(
    [Id] INT PRIMARY KEY IDENTITY (1,1),
    [AirlineId] INT FOREIGN KEY (AirlineId) REFERENCES Airlines(Id),
    [OriginId] INT FOREIGN KEY (OriginId) REFERENCES Airports(Id),
    [DestinationId] INT FOREIGN KEY (DestinationId) REFERENCES Airports(Id),
    [DepartureTime] DATETIME,
    [TicketPrice] FLOAT,
    [Gate] NVARCHAR,
)
GO
-- Passenger Id - Brianne
CREATE TABLE PassengerId
(
    [Id] INT PRIMARY KEY IDENTITY (1,1),
    [UserId] INT FOREIGN KEY (UserId) REFERENCES Users(Id),
    [ConfirmationNumber] INT,
    [FlightId] INT FOREIGN KEY (FlightId) REFERENCES Flights(Id),
)
GO