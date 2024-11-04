CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    CreatedAt TIMESTAMP DEFAULT NOW()
);

CREATE TABLE Events (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    EventDateTime TIMESTAMP NOT NULL,
    Location VARCHAR(255),
    Category VARCHAR(100),
    MaxParticipants INT NOT NULL,
    ImageUrl VARCHAR(255)
);

CREATE TABLE Participants (
    Id SERIAL PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    RegistrationDate TIMESTAMP NOT NULL,
    Email VARCHAR(255) NOT NULL
);

CREATE TABLE EventParticipants (
    Id SERIAL PRIMARY KEY,
    EventId INT REFERENCES Events(Id),
    ParticipantId INT REFERENCES Participants(Id),
    UNIQUE(EventId, ParticipantId)  
);

drop table EventParticipants