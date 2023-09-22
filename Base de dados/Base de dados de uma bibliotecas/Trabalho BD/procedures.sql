USE ProjetoBD;


--verificar permissões de bibliotecario
CREATE PROC Permissions (@email VARCHAR(50)) 
AS
	DECLARE @cc INT
	DECLARE @exists INT
	DECLARE @return INT
	SET @return = 1
	SELECT @cc = Pessoa.num_cc
	FROM Biblioteca.Pessoa
	WHERE Pessoa.email = @email;

	SELECT @exists = COUNT(*)
	FROM Biblioteca.Bibliotecario
	WHERE Bibliotecario.num_cc = @cc;
	IF @exists = 1
		RETURN @return
	ELSE
		SET @return = 0
		RETURN @return


--verificar se é aluno
CREATE PROC checkAluno (@email VARCHAR(50)) 
AS
	DECLARE @cc INT
	DECLARE @exists INT
	DECLARE @return INT
	SET @return = 1
	SELECT @cc = Pessoa.num_cc
	FROM Biblioteca.Pessoa
	WHERE Pessoa.email = @email;

	SELECT @exists = COUNT(*)
	FROM Biblioteca.Aluno
	WHERE Aluno.num_cc = @cc;
	IF @exists = 1
		RETURN @return
	ELSE
		SET @return = 0
		RETURN @return


--obter o cc do aluno
CREATE PROC getAlunoCC (@email VARCHAR(50), @num_cc INT OUTPUT)
AS
	DECLARE @temp INT
	SELECT @temp = num_cc
	FROM Biblioteca.Pessoa
	WHERE Pessoa.email = @email;
	SET @num_cc = @temp

DECLARE @num_cc INT
EXEC GetAlunoCC 'alber.ferreira@ua.pt', @num_cc OUTPUT
print @num_cc
--obter o nome do utilizador
CREATE PROC GetUserName (@email VARCHAR(50),@nome VARCHAR(40) OUTPUT)
AS
	DECLARE @pnome VARCHAR(20)
	DECLARE @unome VARCHAR(20)
	SELECT @pnome = PNome, @unome = UNome
	FROM Biblioteca.Pessoa
	WHERE Pessoa.email = @email;
	SET @nome = CONCAT(@pnome,' ',@unome)
	SELECT @nome


--obter lista de livros requisitados
CREATE PROC getLivrosRequisitados
AS
BEGIN
	DECLARE @livros_req_table TABLE(titulo VARCHAR(50), num_req INT, cod VARCHAR(20), periodo INT, id VARCHAR(10), data_req DATE, num_cc INT, codigo INT)
	INSERT INTO @livros_req_table
	SELECT titulo, ProjetoBD.Biblioteca.contem.num_req, cod, periodo, id, ProjetoBD.Biblioteca.reqLivro.data_req, num_cc, ProjetoBD.Biblioteca.Livro.codigo
	FROM (((ProjetoBD.Biblioteca.Livro JOIN ProjetoBD.Biblioteca.contem ON ProjetoBD.Biblioteca.Livro.codigo = ProjetoBD.Biblioteca.contem.codigo)
	JOIN ProjetoBD.Biblioteca.reqLivro ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.contem.num_req)
	JOIN ProjetoBD.Biblioteca.efetua ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.efetua.num_req)
	SELECT * FROM @livros_req_table

END
GO


--obter as requsições de um titulo
CREATE PROC getLivrosRequisitadosByTitle (@titulo VARCHAR(50))
AS
BEGIN
	DECLARE @livros_req_table TABLE(titulo VARCHAR(50), num_req INT, cod VARCHAR(20), periodo INT, id VARCHAR(10), data_req DATE, num_cc INT, codigo INT)
	INSERT INTO @livros_req_table
	SELECT titulo, ProjetoBD.Biblioteca.contem.num_req, cod, periodo, id, ProjetoBD.Biblioteca.reqLivro.data_req, num_cc, ProjetoBD.Biblioteca.Livro.codigo
	FROM (((ProjetoBD.Biblioteca.Livro JOIN ProjetoBD.Biblioteca.contem ON ProjetoBD.Biblioteca.Livro.codigo = ProjetoBD.Biblioteca.contem.codigo)
	JOIN ProjetoBD.Biblioteca.reqLivro ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.contem.num_req)
	JOIN ProjetoBD.Biblioteca.efetua ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.efetua.num_req)
	WHERE titulo = @titulo;
	SELECT * FROM @livros_req_table

END


--livros requisitados por um utilizador procurados por titulo
CREATE PROC getUserLivrosRequisitadosByTitle (@titulo VARCHAR(50), @num_cc INT)
AS
BEGIN
	DECLARE @livros_req_table TABLE(titulo VARCHAR(50), num_req INT, cod VARCHAR(20), periodo INT, id VARCHAR(10), data_req DATE, num_cc INT, codigo INT)
	INSERT INTO @livros_req_table
	SELECT titulo, ProjetoBD.Biblioteca.contem.num_req, cod, periodo, id, ProjetoBD.Biblioteca.reqLivro.data_req, num_cc, ProjetoBD.Biblioteca.Livro.codigo
	FROM (((ProjetoBD.Biblioteca.Livro JOIN ProjetoBD.Biblioteca.contem ON ProjetoBD.Biblioteca.Livro.codigo = ProjetoBD.Biblioteca.contem.codigo)
	JOIN ProjetoBD.Biblioteca.reqLivro ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.contem.num_req)
	JOIN ProjetoBD.Biblioteca.efetua ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.efetua.num_req)
	WHERE titulo = @titulo and num_cc = @num_cc;
	SELECT * FROM @livros_req_table

END

--procurar livros por ID de requisição
CREATE PROC getLivrosRequisitadosByID (@num_req int)
AS
BEGIN
	DECLARE @livros_req_table TABLE(titulo VARCHAR(50), num_req INT, cod VARCHAR(20), periodo INT, id VARCHAR(10), data_req DATE, num_cc INT, codigo INT)
	INSERT INTO @livros_req_table
	SELECT titulo, ProjetoBD.Biblioteca.contem.num_req, cod, periodo, id, ProjetoBD.Biblioteca.reqLivro.data_req, num_cc, ProjetoBD.Biblioteca.Livro.codigo
	FROM (((ProjetoBD.Biblioteca.Livro JOIN ProjetoBD.Biblioteca.contem ON ProjetoBD.Biblioteca.Livro.codigo = ProjetoBD.Biblioteca.contem.codigo)
	JOIN ProjetoBD.Biblioteca.reqLivro ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.contem.num_req)
	JOIN ProjetoBD.Biblioteca.efetua ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.efetua.num_req)
	WHERE ProjetoBD.Biblioteca.contem.num_req = @num_req;
	SELECT * FROM @livros_req_table

END


--livros requisitados por um utilizador com um num_req
CREATE PROC getUserLivrosRequisitadosByID (@num_req int, @num_cc INT)
AS
BEGIN
	DECLARE @livros_req_table TABLE(titulo VARCHAR(50), num_req INT, cod VARCHAR(20), periodo INT, id VARCHAR(10), data_req DATE, num_cc INT, codigo INT)
	INSERT INTO @livros_req_table
	SELECT titulo, ProjetoBD.Biblioteca.contem.num_req, cod, periodo, id, ProjetoBD.Biblioteca.reqLivro.data_req, num_cc, ProjetoBD.Biblioteca.Livro.codigo
	FROM (((ProjetoBD.Biblioteca.Livro JOIN ProjetoBD.Biblioteca.contem ON ProjetoBD.Biblioteca.Livro.codigo = ProjetoBD.Biblioteca.contem.codigo)
	JOIN ProjetoBD.Biblioteca.reqLivro ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.contem.num_req)
	JOIN ProjetoBD.Biblioteca.efetua ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.efetua.num_req)
	WHERE ProjetoBD.Biblioteca.contem.num_req = @num_req and num_cc = @num_cc;
	SELECT * FROM @livros_req_table
END

--procurar livros requisitados de um utilizador
CREATE PROC getLivrosRequisitadosByUser (@num_cc int)
AS
BEGIN
	DECLARE @livros_req_table TABLE(titulo VARCHAR(50), num_req INT, cod VARCHAR(20), periodo INT, id VARCHAR(10), data_req DATE, num_cc INT, codigo INT)
	INSERT INTO @livros_req_table
	SELECT titulo, ProjetoBD.Biblioteca.contem.num_req, cod, periodo, id, ProjetoBD.Biblioteca.reqLivro.data_req, num_cc, ProjetoBD.Biblioteca.Livro.codigo
	FROM (((ProjetoBD.Biblioteca.Livro JOIN ProjetoBD.Biblioteca.contem ON ProjetoBD.Biblioteca.Livro.codigo = ProjetoBD.Biblioteca.contem.codigo)
	JOIN ProjetoBD.Biblioteca.reqLivro ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.contem.num_req)
	JOIN ProjetoBD.Biblioteca.efetua ON ProjetoBD.Biblioteca.reqLivro.num_req = ProjetoBD.Biblioteca.efetua.num_req)
	WHERE num_cc = @num_cc;
	SELECT * FROM @livros_req_table

END


--obter lista das salas requisitadas
CREATE PROC getSalasRequisitadas
AS
BEGIN
	DECLARE @salas_req_table TABLE (cod_req int, num_edificio INT,piso INT, id_no_piso INT, id VARCHAR(10), n_mec INT, data_req DATE, processo VARCHAR(20))
	INSERT INTO @salas_req_table
	SELECT cod_req, num_edificio, piso, id_no_piso, id, n_mec, data_req, processo
	FROM ProjetoBD.Biblioteca.reqSala
	SELECT * FROM @salas_req_table
END


--procurar as salas requisitadas por nome
CREATE PROC searchSalaByName (@num_edificio INT, @piso INT, @id_no_piso INT)
AS
BEGIN
	DECLARE @salas_req_table TABLE (cod_req int, num_edificio INT,piso INT, id_no_piso INT, id VARCHAR(10), n_mec INT, data_req DATE, processo VARCHAR(20))
	INSERT INTO @salas_req_table
	SELECT cod_req, num_edificio, piso, id_no_piso, id, n_mec, data_req, processo
	FROM ProjetoBD.Biblioteca.reqSala
	WHERE num_edificio = @num_edificio and piso = @piso and id_no_piso = @id_no_piso 
	SELECT * FROM @salas_req_table
END


--procurar salas requisitadas por utilizador por nome
CREATE PROC searchUserSalaByName (@num_edificio INT, @piso INT, @id_no_piso INT, @num_cc INT)
AS
BEGIN
	DECLARE @n_mec INT
	DECLARE @salas_req_table TABLE (cod_req int, num_edificio INT,piso INT, id_no_piso INT, id VARCHAR(10), n_mec INT, data_req DATE, processo VARCHAR(20))
	SELECT @n_mec = n_mec
	FROM ProjetoBD.Biblioteca.Aluno
	WHERE num_cc = @num_cc;
	
	INSERT INTO @salas_req_table
	SELECT cod_req, num_edificio, piso, id_no_piso, id, n_mec, data_req, processo
	FROM ProjetoBD.Biblioteca.reqSala
	WHERE num_edificio = @num_edificio and piso = @piso and id_no_piso = @id_no_piso and n_mec = @n_mec
	SELECT * FROM @salas_req_table
END


--procurar as salas por id de requisição
CREATE PROC searchSalaByID (@cod_req INT)
AS
BEGIN
	DECLARE @salas_req_table TABLE (cod_req int, num_edificio INT,piso INT, id_no_piso INT, id VARCHAR(10), n_mec INT, data_req DATE, processo VARCHAR(20))
	INSERT INTO @salas_req_table
	SELECT cod_req, num_edificio, piso, id_no_piso, id, n_mec, data_req, processo
	FROM ProjetoBD.Biblioteca.reqSala
	WHERE cod_req = @cod_req 
	SELECT * FROM @salas_req_table
END


--procurar salas requisitadas de um utilizador por id do requisito
CREATE PROC searchUserSalaByID (@cod_req INT, @num_cc INT)
AS
BEGIN
	DECLARE @n_mec INT
	DECLARE @salas_req_table TABLE (cod_req int, num_edificio INT,piso INT, id_no_piso INT, id VARCHAR(10), n_mec INT, data_req DATE, processo VARCHAR(20))
	SELECT @n_mec = n_mec
	FROM ProjetoBD.Biblioteca.Aluno
	WHERE num_cc = @num_cc;

	INSERT INTO @salas_req_table
	SELECT cod_req, num_edificio, piso, id_no_piso, id, n_mec, data_req, processo
	FROM ProjetoBD.Biblioteca.reqSala
	WHERE cod_req = @cod_req and n_mec = @n_mec
	SELECT * FROM @salas_req_table
END

--obter as salas requisitadas feitas por um utilizador
CREATE PROC searchSalaByUser (@n_mec INT)
AS
BEGIN
	DECLARE @salas_req_table TABLE (cod_req int, num_edificio INT,piso INT, id_no_piso INT, id VARCHAR(10), n_mec INT, data_req DATE, processo VARCHAR(20))
	INSERT INTO @salas_req_table
	SELECT cod_req, num_edificio, piso, id_no_piso, id, n_mec, data_req, processo
	FROM ProjetoBD.Biblioteca.reqSala
	WHERE n_mec = @n_mec
	SELECT * FROM @salas_req_table
END


--Salas requisitas de um utilizador usando num_CC
CREATE PROC searchUserSalas (@num_cc INT)
AS
BEGIN
	DECLARE @n_mec INT
	DECLARE @salas_req_table TABLE (cod_req int, num_edificio INT,piso INT, id_no_piso INT, id VARCHAR(10), n_mec INT, data_req DATE, processo VARCHAR(20))
	SELECT @n_mec = n_mec
	FROM ProjetoBD.Biblioteca.Aluno
	WHERE num_cc = @num_cc;

	INSERT INTO @salas_req_table
	SELECT cod_req, num_edificio, piso, id_no_piso, id, n_mec, data_req, processo
	FROM ProjetoBD.Biblioteca.reqSala
	WHERE n_mec = @n_mec
	SELECT * FROM @salas_req_table
END


--requisitar livros
CREATE PROC requisitarLivro (@codigo INT, @num_cc INT, @quantidade INT)
AS
	DECLARE @bibliotecario VARCHAR(10)
	DECLARE @num_req INT

	SELECT @bibliotecario = id
	FROM ProjetoBD.Biblioteca.Bibliotecario
	WHERE CONVERT(TIME, GETDATE()) > horario_inicio and CONVERT(TIME, GETDATE()) < horario_fim

	SELECT @num_req = MAX(num_req)
	FROM ProjetoBD.Biblioteca.reqLivro
	SET @num_req = @num_req + 1
	
	INSERT INTO ProjetoBD.Biblioteca.reqLivro(num_req, cod, data_req, id, periodo)
	VALUES
	(@num_req,'Requisitado',CAST( GETDATE() AS Date ),@bibliotecario,14);

	INSERT INTO ProjetoBD.Biblioteca.contem(num_req, codigo)
	VALUES
	(@num_req,@codigo)

	INSERT INTO ProjetoBD.Biblioteca.efetua(num_req,num_cc)
	VALUES
	(@num_req,@num_cc)

	UPDATE ProjetoBD.Biblioteca.Livro
	SET quantidade = @quantidade
	WHERE codigo = @codigo


--renovar livro como utilizador
CREATE PROC renovarLivroByUser (@codigo INT, @num_cc INT)
AS
	DECLARE @bibliotecario VARCHAR(10)
	DECLARE @num_req INT

	SELECT @bibliotecario = id
	FROM ProjetoBD.Biblioteca.Bibliotecario
	WHERE CONVERT(TIME, GETDATE()) > horario_inicio and CONVERT(TIME, GETDATE()) < horario_fim

	SELECT @num_req = MAX(num_req)
	FROM ProjetoBD.Biblioteca.reqLivro
	SET @num_req = @num_req + 1
	
	INSERT INTO ProjetoBD.Biblioteca.reqLivro(num_req, cod, data_req, id, periodo)
	VALUES
	(@num_req,'Renovado',CAST( GETDATE() AS Date ),@bibliotecario,14);

	INSERT INTO ProjetoBD.Biblioteca.contem(num_req, codigo)
	VALUES
	(@num_req,@codigo)

	INSERT INTO ProjetoBD.Biblioteca.efetua(num_req,num_cc)
	VALUES
	(@num_req,@num_cc)


--entregar sala como utilizador
CREATE PROC entregarLivroByUser (@codigo INT, @num_cc INT)
AS
	DECLARE @bibliotecario VARCHAR(10)
	DECLARE @num_req INT

	SELECT @bibliotecario = id
	FROM ProjetoBD.Biblioteca.Bibliotecario
	WHERE CONVERT(TIME, GETDATE()) > horario_inicio and CONVERT(TIME, GETDATE()) < horario_fim

	SELECT @num_req = MAX(num_req)
	FROM ProjetoBD.Biblioteca.reqLivro
	SET @num_req = @num_req + 1
	
	INSERT INTO ProjetoBD.Biblioteca.reqLivro(num_req, cod, data_req, id, periodo)
	VALUES
	(@num_req,'Entregado',CAST( GETDATE() AS Date ),@bibliotecario,14);

	INSERT INTO ProjetoBD.Biblioteca.contem(num_req, codigo)
	VALUES
	(@num_req,@codigo)

	INSERT INTO ProjetoBD.Biblioteca.efetua(num_req,num_cc)
	VALUES
	(@num_req,@num_cc)

	UPDATE ProjetoBD.Biblioteca.Livro
	SET quantidade = quantidade + 1
	WHERE codigo = @codigo

--renovar livro como bibliotecario
CREATE PROC entregarLivroByBibliotecario (@codigo INT, @num_cc INT, @bibliotecario varchar(10))
AS
	DECLARE @num_req INT

	SELECT @num_req = MAX(num_req)
	FROM ProjetoBD.Biblioteca.reqLivro
	SET @num_req = @num_req + 1
	
	INSERT INTO ProjetoBD.Biblioteca.reqLivro(num_req, cod, data_req, id, periodo)
	VALUES
	(@num_req,'Entregado',CAST( GETDATE() AS Date ),@bibliotecario,14);

	INSERT INTO ProjetoBD.Biblioteca.contem(num_req, codigo)
	VALUES
	(@num_req,@codigo)

	INSERT INTO ProjetoBD.Biblioteca.efetua(num_req,num_cc)
	VALUES
	(@num_req,@num_cc)

	UPDATE ProjetoBD.Biblioteca.Livro
	SET quantidade = quantidade + 1
	WHERE codigo = @codigo


--renovar livro como bibliotecario
CREATE PROC renovarLivroByBibliotecario (@codigo INT, @num_cc INT, @bibliotecario VARCHAR(10))
AS
	DECLARE @num_req INT

	SELECT @num_req = MAX(num_req)
	FROM ProjetoBD.Biblioteca.reqLivro
	SET @num_req = @num_req + 1
	
	INSERT INTO ProjetoBD.Biblioteca.reqLivro(num_req, cod, data_req, id, periodo)
	VALUES
	(@num_req,'Renovado',CAST( GETDATE() AS Date ),@bibliotecario,14);

	INSERT INTO ProjetoBD.Biblioteca.contem(num_req, codigo)
	VALUES
	(@num_req,@codigo)

	INSERT INTO ProjetoBD.Biblioteca.efetua(num_req,num_cc)
	VALUES
	(@num_req,@num_cc)

--requisitar salas
CREATE PROC requisitarSala (@num_cc INT, @num_edificio INT, @piso INT, @id_no_piso INT)
AS
	DECLARE @num_req INT
	DECLARE @bibliotecario VARCHAR(10)
	DECLARE @n_mec INT

	SELECT @n_mec = n_mec
	FROM ProjetoBD.Biblioteca.Aluno
	WHERE num_cc = @num_cc

	SELECT @bibliotecario = id
	FROM ProjetoBD.Biblioteca.Bibliotecario
	WHERE CONVERT(TIME, GETDATE()) > horario_inicio and CONVERT(TIME, GETDATE()) < horario_fim

	SELECT @num_req = MAX(cod_req)
	FROM ProjetoBD.Biblioteca.reqSala
	SET @num_req = @num_req + 1

	INSERT INTO ProjetoBD.Biblioteca.reqSala(cod_req,id,n_mec,num_edificio,piso,id_no_piso,data_req,processo)
	VALUES
	(@num_req,@bibliotecario,@n_mec,@num_edificio,@piso,@id_no_piso,CAST( GETDATE() AS Date ),'Requisitada')

	UPDATE ProjetoBD.Biblioteca.Sala
	SET chave = 'Não'
	WHERE num_edificio = @num_edificio and piso = @piso and id_no_piso = @id_no_piso


--entregar sala como utilizador
CREATE PROC entregarSalaByUser (@num_cc INT, @num_edificio INT, @piso INT, @id_no_piso INT)
AS
	DECLARE @num_req INT
	DECLARE @bibliotecario VARCHAR(10)
	DECLARE @n_mec INT

	SELECT @n_mec = n_mec
	FROM ProjetoBD.Biblioteca.Aluno
	WHERE num_cc = @num_cc

	SELECT @bibliotecario = id
	FROM ProjetoBD.Biblioteca.Bibliotecario
	WHERE CONVERT(TIME, GETDATE()) > horario_inicio and CONVERT(TIME, GETDATE()) < horario_fim

	SELECT @num_req = MAX(cod_req)
	FROM ProjetoBD.Biblioteca.reqSala
	SET @num_req = @num_req + 1

	INSERT INTO ProjetoBD.Biblioteca.reqSala(cod_req,id,n_mec,num_edificio,piso,id_no_piso,data_req,processo)
	VALUES
	(@num_req,@bibliotecario,@n_mec,@num_edificio,@piso,@id_no_piso,CAST( GETDATE() AS Date ),'Entregue')

	UPDATE ProjetoBD.Biblioteca.Sala
	SET chave = 'Sim'
	WHERE num_edificio = @num_edificio and piso = @piso and id_no_piso = @id_no_piso


--entregar sala como bibliotecario
CREATE PROC entregarSalaByBibliotecario (@num_cc INT, @num_edificio INT, @piso INT, @id_no_piso INT, @bibliotecario VARCHAR(10))
AS
	DECLARE @num_req INT
	DECLARE @n_mec INT

	SELECT @n_mec = n_mec
	FROM ProjetoBD.Biblioteca.Aluno
	WHERE num_cc = @num_cc

	SELECT @num_req = MAX(cod_req)
	FROM ProjetoBD.Biblioteca.reqSala
	SET @num_req = @num_req + 1

	INSERT INTO ProjetoBD.Biblioteca.reqSala(cod_req,id,n_mec,num_edificio,piso,id_no_piso,data_req, processo)
	VALUES
	(@num_req,@bibliotecario,@n_mec,@num_edificio,@piso,@id_no_piso,CAST( GETDATE() AS Date ),'Entregue')

	UPDATE ProjetoBD.Biblioteca.Sala
	SET chave = 'Sim'
	WHERE num_edificio = @num_edificio and piso = @piso and id_no_piso = @id_no_piso


--obter o ID do bibliotecario
CREATE PROC getBibliotecarioID (@num_cc INT, @id VARCHAR(10) OUTPUT)
AS
	SELECT @id = id
	FROM ProjetoBD.Biblioteca.Bibliotecario
	WHERE @num_cc = num_cc


CREATE PROC getHorarioInstituicao
AS
	DECLARE @horario TABLE (hora_ini VARCHAR(10),hora_fim VARCHAR(10),hora_abert VARCHAR(10),hora_fech VARCHAR(10))
	INSERT INTO @horario
	SELECT hora_ini,hora_fim,hora_abert,hora_fech
	FROM ProjetoBD.Biblioteca.Horario
	WHERE qualificador = 1

	SELECT * FROM @horario

CREATE PROC getHorarioNInstituicao
AS
	DECLARE @horario TABLE (hora_ini VARCHAR(10),hora_fim VARCHAR(10),hora_abert VARCHAR(10),hora_fech VARCHAR(10))
	INSERT INTO @horario
	SELECT hora_ini,hora_fim,hora_abert,hora_fech
	FROM ProjetoBD.Biblioteca.Horario
	WHERE qualificador = 2

	SELECT * FROM @horario