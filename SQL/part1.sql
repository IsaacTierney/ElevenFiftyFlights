-- Flights
CREATE TABLE Flights
(
    [Id] INT,
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
    [FlightId] NVARCHAR FOREIGN KEY (UserId) REFERENCES Flights(Id),
)
GO