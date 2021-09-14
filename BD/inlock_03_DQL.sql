USE inlock_games_manha;
GO

--Listar todos os usu�rios;
SELECT * FROM Usuarios;

--Listar todos os est�dios;
SELECT * FROM Estudio;

--Listar todos os jogos;
SELECT * FROM Jogos;

--Listar todos os jogos e seus respectivos est�dios;
SELECT nomeJogo 'Jogos', nomeEstudio 'Estudio'
FROM Jogos J
RIGHT JOIN Estudio E
ON J.idEstudio = E.idEstudio;
GO

--Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listar todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia;
SELECT nomeEstudio 'Estudio', nomeJogo 'Jogos'
FROM Estudio E
LEFT JOIN Jogos J
ON E.idEstudio = J.idEstudio;
GO
--Buscar um usu�rio por e-mail e senha (login);
SELECT idUsuario,email
FROM Usuarios
WHERE email = 'cliente@cliente.com' and senha = 'cliente';
GO
--Buscar um jogo por idJogo;
SELECT idJogo,nomeJogo,descricao,dataLancamento,valor
FROM Jogos
WHERE idJogo = '1';
GO
--Buscar um est�dio por idEstudio;
SELECT idEstudio,NomeEstudio
FROM Estudio
WHERE idEstudio = '1';
GO

SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM Jogos WHERE idEstudio = 1
