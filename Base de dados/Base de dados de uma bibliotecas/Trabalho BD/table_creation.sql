--CREATE DATABASE ProjetoBD
--GO
--CREATE SCHEMA Biblioteca;
--GO

DROP TABLE ProjetoBD.Biblioteca.AppLogIn;
DROP TABLE ProjetoBD.Biblioteca.Verifica;
DROP TABLE ProjetoBD.Biblioteca.reqSala;
DROP TABLE ProjetoBD.Biblioteca.Sala;
DROP TABLE ProjetoBD.Biblioteca.Aluno;
DROP TABLE ProjetoBD.Biblioteca.contem;
DROP TABLE ProjetoBD.Biblioteca.Livro
DROP TABLE ProjetoBD.Biblioteca.efetua;
DROP TABLE ProjetoBD.Biblioteca.reqLivro;
DROP TABLE ProjetoBD.Biblioteca.Bibliotecario;
DROP TABLE ProjetoBD.Biblioteca.Seguranca;
DROP TABLE ProjetoBD.Biblioteca.Pessoa;
DROP TABLE ProjetoBD.Biblioteca.Horario;
DROP TABLE ProjetoBD.Biblioteca.Tipo;


CREATE TABLE ProjetoBD.Biblioteca.Tipo (
	qualificador VARCHAR(20) NOT NULL,
	PRIMARY KEY (qualificador));


CREATE TABLE ProjetoBD.Biblioteca.Horario(
	hora_ini VARCHAR(10) NOT NULL,
	hora_fim VARCHAR(10) NOT NULL,
	hora_abert VARCHAR(10) NOT NULL,
	hora_fech VARCHAR(10) NOT NULL,
	qualificador VARCHAR(20) NOT NULL,
	PRIMARY KEY (qualificador),
	FOREIGN KEY (qualificador) REFERENCES ProjetoBD.Biblioteca.Tipo(qualificador)
	ON DELETE NO ACTION ON UPDATE CASCADE);

CREATE TABLE ProjetoBD.Biblioteca.Pessoa (
	num_cc INT NOT NULL CHECK (num_cc > 0),
	endereco VARCHAR(20),
	email VARCHAR(50) UNIQUE NOT NULL,
	PNome VARCHAR(20) NOT NULL,
	UNome VARCHAR(20) NOT NULL,
	qualificador VARCHAR(20),
	PRIMARY KEY (num_cc),
	FOREIGN KEY (qualificador) REFERENCES ProjetoBD.Biblioteca.Tipo(qualificador));

CREATE TABLE ProjetoBD.Biblioteca.Seguranca(
	num_cc INT,
	id VARCHAR(10) NOT NULL,
	horario_inicio TIME,
	horario_fim TIME,
	PRIMARY KEY (id),
	FOREIGN KEY (num_cc) REFERENCES ProjetoBD.Biblioteca.Pessoa(num_cc)
	ON DELETE NO ACTION ON UPDATE CASCADE);


CREATE TABLE ProjetoBD.Biblioteca.Verifica(
	qualificador VARCHAR(20),
	id VARCHAR(10),
	PRIMARY KEY (qualificador, id),
	FOREIGN KEY (qualificador) REFERENCES ProjetoBD.Biblioteca.Tipo(qualificador),
	FOREIGN KEY (id) REFERENCES ProjetoBD.Biblioteca.Seguranca(id));

CREATE TABLE ProjetoBD.Biblioteca.Bibliotecario(
	num_cc INT,
	id VARCHAR(10) NOT NULL,
	horario_inicio VARCHAR(10),
	horario_fim VARCHAR(10),
	PRIMARY KEY (id),
	FOREIGN KEY (num_cc) REFERENCES ProjetoBD.Biblioteca.Pessoa(num_cc)
	ON DELETE SET NULL ON UPDATE CASCADE);

CREATE TABLE ProjetoBD.Biblioteca.reqLivro(
	periodo INT NOT NULL,
	cod VARCHAR(20) NOT NULL,
	data_req DATE NOT NULL,
	num_req INT NOT NULL CHECK (num_req > 0),
	id VARCHAR(10),
	PRIMARY KEY (num_req),
	FOREIGN KEY (id) REFERENCES ProjetoBD.Biblioteca.Bibliotecario(id)
	ON DELETE NO ACTION ON UPDATE CASCADE);

CREATE TABLE ProjetoBD.Biblioteca.efetua(
	num_req INT,
	num_cc INT,
	PRIMARY KEY (num_req,num_cc),
	FOREIGN KEY (num_req) REFERENCES ProjetoBD.Biblioteca.reqLivro(num_req),
	FOREIGN KEY (num_cc) REFERENCES ProjetoBD.Biblioteca.Pessoa(num_cc)
	ON DELETE NO ACTION ON UPDATE CASCADE);

CREATE TABLE ProjetoBD.Biblioteca.Livro(
	nome VARCHAR(50),
	piso INT NOT NULL CHECK(piso >= 0),
	codigo INT NOT NULL CHECK(codigo > 0),
	quantidade INT CHECK(quantidade >= 0),
	autor VARCHAR(50) NOT NULL,
	titulo VARCHAR(50) NOT NULL,
	editora VARCHAR(50) NOT NULL,
	PRIMARY KEY (codigo));

CREATE TABLE ProjetoBD.Biblioteca.contem(
	num_req INT,
	codigo INT,
	PRIMARY KEY (num_req, codigo),
	FOREIGN KEY (num_req) REFERENCES ProjetoBD.Biblioteca.reqLivro(num_req)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	FOREIGN KEY (codigo) REFERENCES ProjetoBD.Biblioteca.Livro(codigo)
	ON DELETE NO ACTION ON UPDATE CASCADE);

	
CREATE TABLE ProjetoBD.Biblioteca.Aluno(
	num_cc INT,
	n_mec int NOT NULL CHECK (n_mec > 0),
	matricula INT CHECK (matricula > 0),
	curso VARCHAR(50),
	PRIMARY KEY (n_mec),
	FOREIGN KEY (num_cc) REFERENCES ProjetoBD.Biblioteca.Pessoa(num_cc)
	ON UPDATE CASCADE);	

CREATE TABLE ProjetoBD.Biblioteca.Sala(
	num_edificio INT NOT NULL CHECK(num_edificio > 0),
	piso INT NOT NULL CHECK(piso >= 0),
	id_no_piso INT NOT NULL CHECK(id_no_piso >= 0),
	chave VARCHAR(5),
	PRIMARY KEY(num_edificio, piso, id_no_piso));

CREATE TABLE ProjetoBD.Biblioteca.reqSala(
	data_req DATE,
	num_edificio INT,
	piso INT,
	id_no_piso INT,
	n_mec INT,
	id VARCHAR(10),
	cod_req INT,
	processo VARCHAR(20),
	PRIMARY KEY (cod_req),
	FOREIGN KEY (id) REFERENCES ProjetoBD.Biblioteca.Bibliotecario(id)
	ON DELETE NO ACTION ON UPDATE CASCADE,
	FOREIGN KEY (n_mec) REFERENCES ProjetoBD.Biblioteca.Aluno(n_mec),
	FOREIGN KEY (num_edificio,piso,id_no_piso) REFERENCES ProjetoBD.Biblioteca.Sala(num_edificio,piso,id_no_piso)
	ON DELETE NO ACTION ON UPDATE CASCADE);

CREATE TABLE ProjetoBD.Biblioteca.AppLogIn(
	email VARCHAR(50),
	pass VARCHAR(50),
	PRIMARY KEY(email),
	FOREIGN KEY (email) REFERENCES ProjetoBD.Biblioteca.Pessoa(email));
