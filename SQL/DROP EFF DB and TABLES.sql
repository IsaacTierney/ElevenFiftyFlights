USE master;
GO
ALTER DATABASE ElevenFiftyFlights SET single_user with ROLLBACK IMMEDIATE;
GO
-- Users - Isaac
DROP TABLE ElevenFiftyFlights.Users
GO
DROP TABLE ElevenFiftyFlights.PassengerId
GO
DROP TABLE ElevenFiftyFlights.Airlines
GO
DROP TABLE ElevenFiftyFlights.Airports
GO
DROP TABLE ElevenFiftyFlights.Flights
GO
DROP DATABASE ElevenFiftyFlights
GO