USE inlock_games_manha;
GO

INSERT INTO Estudio(nomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO


INSERT INTO Jogos(idEstudio,nomeJogo,descricao,dataLancamento,valor)
VALUES ('1','Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.','20120515','99.00'),
	   ('2','Red Dead Redemption II','Jogo eletr�nico de a��o-aventura western.','20181026','120.00');
GO

INSERT INTO TipoUsuario(titulo)
VALUES ('ADMINISTRADOR'),('CLIENTE');
GO

INSERT INTO Usuarios(idTipoUsuario,email,senha)
VALUES ('1','admin@admin.com','admin'),
	   ('2','cliente@cliente.com','cliente');
GO

SELECT * FROM Estudio;
SELECT * FROM Jogos;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuarios;