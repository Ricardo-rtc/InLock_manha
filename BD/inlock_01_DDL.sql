create database inlock_games_manha;
GO

USE inlock_games_manha
GO

CREATE TABLE Estudio(
idEstudio INT PRIMARY KEY IDENTITY,
nomeEstudio VARCHAR(100),
);
GO

CREATE TABLE Jogos(
idJogo INT PRIMARY KEY IDENTITY,
idEstudio INT FOREIGN KEY REFERENCES Estudio(idEstudio),
nomeJogo VARCHAR(100),
descricao VARCHAR(500),
dataLancamento Date,
valor Float,
);
GO

CREATE TABLE TipoUsuario(
idTipoUsuario INT PRIMARY KEY IDENTITY,
titulo VARCHAR(200),
);
GO

CREATE TABLE Usuarios(
idUsuario INT PRIMARY  KEY IDENTITY,
idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
email VARCHAR(100),
senha VARCHAR(100),
);
GO
