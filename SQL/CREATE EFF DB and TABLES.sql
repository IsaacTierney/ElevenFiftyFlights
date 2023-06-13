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
-- Passenger Id - Brianne
CREATE TABLE PassengerId
(
    [Id] INT PRIMARY KEY IDENTITY (1,1),
    [UserId] NVARCHAR FOREIGN KEY (UserId) REFERENCES ElevenFiftyFlights.Users(Id),
    [ConfirmationNumber] INT IDENTITY (1000, 1),
    [FlightId] NVARCHAR FOREIGN KEY (UserId) REFERENCES ElevenFiftyFlights.Flights(Id),
)
GO
-- Airlines - Shelby
CREATE TABLE Airlines
(
    [Id] INT,
    [Name] NVARCHAR,
    [BaseTicketPrice] FLOAT,
)
GO
-- Airports - Edwin
CREATE TABLE Airports
(
    [Id] INT,
    [City] NCHAR,
    [State] NVARCHAR,
    [Name] NVARCHAR,
)
GO
-- Flights
CREATE TABLE Flights
(
    [Id] INT,
    [AirlineId] INT FOREIGN KEY (AirlineId) REFERENCES ElevenFiftyFlights.Airlines(Id),
    [OriginId] INT FOREIGN KEY (OriginId) REFERENCES ElevenFiftyFlights.Origin(Id),
    [DestinationId] INT FOREIGN KEY (DestinationId) REFERENCES ElevenFiftyFlights.Destination(Id),
    [DepartureTime] DATETIME,
    [TicketPrice] FLOAT,
    [Gate] NVARCHAR,
)
GO