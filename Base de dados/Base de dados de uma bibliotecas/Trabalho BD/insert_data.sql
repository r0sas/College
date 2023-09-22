INSERT INTO ProjetoBD.Biblioteca.Livro(titulo,autor,editora,piso,nome,codigo,quantidade)
VALUES
('A Trama','Jean Hanff Korelitz','Editorial Presença',1,'Policial e Thriller',0015,7),
('Corrente de Ouro','Cassandra Clare','Planeta',2,'Literatura Fantástica',0014,4),
('Coisas que (Me) Aconteceram','João Cordeiro','Edições Almedina',2,'Biografias',0013,1),
('Como Se Fôssemos Vilões','M. L. Rio','Edições Asa',1,'Policial e Thriller',0011,2),
('As Sete Marias que Matavam Franceses','Domingos Amaral','Casa das Letras',2,'Romance',0010,4),
('Rei do Bluff','Afonso Noite-Luar','Manuscrito Editora',3,'Literatura Erótica',0009,4),
('A Rapariga no Abismo','Charlie Gallagher','Alma dos Livros',1,'Policial e Thriller',0008,4),
('Oh, William!','Elizabeth Strout','Alfaguara Portugal',2,'Romance',0007,6),
('A Mais Breve História da China','Linda Jaivin','Dom Quixote',3,'História da Ásia',0006,3),
('Não é Loucura, é Ansiedade','Sophie Seromenho','Contraponto Editores',2,'Psicologia',0005,5),
('Cozinha Vegetariana para Ganhar Tempo','Gabriela Oliveira','Arte Plural Edições',3,'Cozinha Vegetariana',0004,3),
('Elizabeth Finch','Julian Barnes','Quetzal Editores',2,'Romance',0003,10),
('Zoobiquidade','Drª Barbara Natterson-Horowitz e Kathryn Bowers','Pergaminho',2,'Biologia',0012,5),
('Baiôa sem Data Para Morrer','Rui Couceiro ','Porto Editora',2,'Romance',0002,0),
('O Caso Alaska Sanders', 'Joel Dicker','Alfaguara Portugal',1,'Policial e Thriller',0001,10);


INSERT INTO ProjetoBD.Biblioteca.Sala(num_edificio,piso,id_no_piso,chave)
VALUES
(17,1,01,'Sim'),
(17,1,02,'Sim'),
(17,1,03,'Sim'),
(17,1,04,'Sim'),
(17,1,05,'Não'),
(17,2,01,'Sim'),
(17,2,02,'Sim'),
(17,2,03,'Sim'),
(17,2,04,'Não'),
(17,2,05,'Sim'),
(17,2,06,'Não'),
(17,2,07,'Não'),
(17,3,01,'Não'),
(17,3,02,'Sim'),
(17,3,03,'Não'),
(17,3,04,'Sim'),
(17,3,05,'Não'),
(17,3,06,'Sim'),
(17,3,07,'Não');


INSERT INTO ProjetoBD.Biblioteca.Tipo(qualificador)
VALUES
(1),
(2);

INSERT INTO ProjetoBD.Biblioteca.Horario(qualificador,hora_ini,hora_fim,hora_abert,hora_fech)
VALUES
(1,'00:00','24:00','00:00','24:00'),
(2,'09:00','24:00','10:00','18:00');

INSERT INTO ProjetoBD.Biblioteca.Pessoa(num_cc,PNome,UNome,endereco,email,qualificador)
VALUES
(39476022,'Alberto','Ferreira','Braga','alber.ferreira@ua.pt',1),
(38199617,'José','Costa','Porto','jose.c@gmail.com',2),
(18259254,'António','Pereira','Porto','antonio.pereira@ua.pt',1),
(12303278,'Mariana','Ferreira','Lisboa','mariana.ferreira@ua.pt',1),
(35025066,'Tatiana','Peixoto','Évora','sa.tatiana@gmail.com',2),
(14537631,'Tiago','Vieira','Viana do Castelo','vieira.tiago@gmail.com',2),
(13779457,'Catarina','Rodrigues','Lisboa','catarina.ro@ua.pt',1),
(12448515,'Rita','Sendim','Algarve','rita.s@gmail.com',2),
(16601570,'Ana','Alheira','Beja','ana.eira@ua.pt',1);

INSERT INTO ProjetoBD.Biblioteca.Bibliotecario(num_cc,horario_inicio,horario_fim,id)
VALUES
(18259254,'00:00:00','15:00','B001'),
(13779457,'15:00:00','23:00','B002');

INSERT INTO ProjetoBD.Biblioteca.Seguranca(num_cc,horario_inicio,horario_fim,id)
VALUES
(18259254,'23:00:00','07:00:00','S001');

INSERT INTO ProjetoBD.Biblioteca.AppLogIn(email,pass)
VALUES
('mariana.ferreira@ua.pt','1234'),
('vieira.tiago@gmail.com','1234'),
('antonio.pereira@ua.pt','4321');

INSERT INTO ProjetoBD.Biblioteca.reqLivro(num_req,id,data_req,cod,periodo)
VALUES
(0000001,'B001',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000002,'B001',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000003,'B001',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000004,'B002',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000005,'B002',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000006,'B002',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000007,'B002',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000008,'B002',CAST( GETDATE() AS Date ),'Requisitado','14'),
(0000009,'B002',CAST( GETDATE() AS Date ),'Requisitado','14');


INSERT INTO ProjetoBD.Biblioteca.efetua(num_req,num_cc)
VALUES
(0000001,16601570),
(0000002,16601570),
(0000003,39476022),
(0000004,38199617),
(0000005,14537631),
(0000006,12448515),
(0000007,12303278),
(0000008,12303278),
(0000009,12303278);


INSERT INTO ProjetoBD.Biblioteca.contem(num_req, codigo)
VALUES
(0000001,0002),
(0000002,0009),
(0000003,0005),
(0000004,0007),
(0000005,0003),
(0000006,0010),
(0000007,0001),
(0000008,0005),
(0000009,0002);

INSERT INTO ProjetoBD.Biblioteca.Aluno(num_cc, n_mec, matricula, curso)
VALUES
(39476022,93458,3,'Biologia'),
(12303278,87142,4,'Engenharia Física'),
(16601570,101245,1,'Engenharia Mecânica');

INSERT INTO ProjetoBD.Biblioteca.reqSala(data_req, num_edificio, piso, id_no_piso, n_mec, id, cod_req, processo)
VALUES
(GETDATE(),17,1,05,93458,'B001',1,'Requisitada'),
(GETDATE(),17,2,04,87142,'B001',2,'Requisitada'),
(GETDATE(),17,2,06,101245,'B001',3,'Requisitada');