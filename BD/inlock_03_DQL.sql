USE inlock_games_manha;
GO

--Listar todos os usuários;
SELECT * FROM Usuarios;

--Listar todos os estúdios;
SELECT * FROM Estudio;

--Listar todos os jogos;
SELECT * FROM Jogos;

--Listar todos os jogos e seus respectivos estúdios;
SELECT nomeJogo 'Jogos', nomeEstudio 'Estudio'
FROM Jogos J
RIGHT JOIN Estudio E
ON J.idEstudio = E.idEstudio;
GO

--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT nomeEstudio 'Estudio', nomeJogo 'Jogos'
FROM Estudio E
LEFT JOIN Jogos J
ON E.idEstudio = J.idEstudio;
GO
--Buscar um usuário por e-mail e senha (login);
SELECT idUsuario,email
FROM Usuarios
WHERE email = 'cliente@cliente.com' and senha = 'cliente';
GO
--Buscar um jogo por idJogo;
SELECT idJogo,nomeJogo,descricao,dataLancamento,valor
FROM Jogos
WHERE idJogo = '1';
GO
--Buscar um estúdio por idEstudio;
SELECT idEstudio,NomeEstudio
FROM Estudio
WHERE idEstudio = '1';
GO

SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM Jogos WHERE idEstudio = 1
