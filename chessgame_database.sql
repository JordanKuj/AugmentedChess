CREATE TABLE Games
(
    GameId  INT(8) NOT NULL PRIMARY KEY,
    StartTime  DATETIME NOT NULL,
    EndTime DATETIME,
);

CREATE TABLE Boardstates
(
    GameId  INT(8) NOT NULL FOREIGN KEY REFERENCES Game(GameId),
    StateId INT NOT NULL PRIMARY KEY,
    Timestamp DATETIME,
    State CHAR(80),
);