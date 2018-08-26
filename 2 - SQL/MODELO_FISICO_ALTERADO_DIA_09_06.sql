CREATE DATABASE SOS_DENTES
USE SOS_DENTES
--DROP DATABASE SOS_DENTES
USE master

CREATE TABLE Funcionario (
id_funcionario INTEGER NOT NULL IDENTITY(1,1)PRIMARY KEY,
Nome VARCHAR(100) NOT NULL,
Dt_Nasc VARCHAR(12) NOT NULL,
RG VARCHAR(15) NOT NULL,
CPF VARCHAR(15)NULL,
Genero CHAR(15)NOT NULL,
Email VARCHAR(150)NULL,
Tel_fixo VARCHAR(15) NOT NULL,
Celular VARCHAR(15) NOT NULL,
Endereco VARCHAR(100) NOT NULL,
numero VARCHAR(20) NOT NULL,
Bairro VARCHAR(100) NOT NULL,
Complemento VARCHAR(150) NULL,
Cidade VARCHAR(100) NOT NULL,
Cep VARCHAR(8) NOT NULL,
CARGO VARCHAR(150) NOT NULL,
UF VARCHAR(2) NOT NULL,
 Ativo INT NOT NULL
)
INSERT INTO Funcionario VALUES ('ADRIAN GONÇALVES','03/03/2001','547161979','50321748824','MASCULINO','adrianamazonas2015@gmail.com',
'123456789','11982138584','Rua Alfa','257', 'Vila Gióia', 'apt 322B apto 3B', 'Itapevi', '06680103', 'Dentista', 'SP',1)
INSERT INTO Funcionario VALUES ('JOAO','03/03/2001','547161979','50321748824','MASCULINO','adrianamazonas2015@gmail.com',
'123456789','11982138584','Rua Alfa','257', 'Vila Gióia', 'apt 322B apto 3B', 'Itapevi', '06680103', 'Dentista', 'SP',1)
INSERT INTO Funcionario VALUES ('JOSÉ','03/03/2001','547161979','50321748824','MASCULINO','adrianamazonas2015@gmail.com',
'123456789','11982138584','Rua Alfa','257', 'Vila Gióia', 'apt 322B apto 3B', 'Itapevi', '06680103', 'Dentista', 'SP',1)

select * from Tratamento
CREATE TABLE Tratamento (
id_tratamento INTEGER NOT NULL IDENTITY (1,1) PRIMARY KEY,
id_paciente int not null,
id_servico_FK INTEGER NOT NULL,
data VARCHAR(12) NOT NULL,
hora VARCHAR(12) NOT NULL,
status VARCHAR(100) NOT NULL CHECK (STATUS IN ('Agendado', 'Concluído', 'Cancelado')),
id_dentista INTEGER NOT NULL,
FOREIGN KEY(id_dentista) REFERENCES Funcionario (id_funcionario),
foreign key (id_paciente) references paciente (id_paciente)
)



CREATE TABLE Paciente (
id_Paciente INTEGER NOT NULL IDENTITY (1,1)PRIMARY KEY,
Nome VARCHAR(100) NOT NULL,
Dt_Nasc VARCHAR(12) NOT NULL,
Email VARCHAR(150) NOT NULL,
Celular VARCHAR(15) NOT NULL,
RG VARCHAR(15) NOT NULL,
Tel_Fixo VARCHAR(15) NOT NULL,
Genero VARCHAR(15) NOT NULL,
Endereco VARCHAR(100) NOT NULL,
CPF VARCHAR(15) NULL,
Bairro VARCHAR(100) NOT NULL,
Complemento VARCHAR(150) NOT NULL,
numero VARCHAR(20) NULL,
CEP VARCHAR(10) NOT NULL,
UF VARCHAR(2) NOT NULL,
Cidade VARCHAR(100) NOT NULL,
Observacao TEXT NULL,
Ativo INT
)
INSERT INTO Paciente VALUES('adrian','03/03/2001','adrianamazonas2015@gmail.com','11982138584','547161979','1141449520','Masculino','rua alfa','50321748824','vila gióia','','257','06657230','sp','itapevi','',1)
INSERT INTO Paciente VALUES('Evellyn','03/03/2001','','11982138584','547161979','1141449520','Feminino','rua alfa','50321748824','vila gióia','','257','06657230','sp','itapevi','',1)
INSERT INTO Paciente VALUES('LUCAS','03/03/2001','','11982138584','547161979','1141449520','Masculino','rua alfa','50321748824','vila gióia','','257','06657230','sp','itapevi','',1)
INSERT INTO Paciente VALUES('PEDRO','03/03/2001','','11982138584','547161979','1141449520','Masculino','rua alfa','50321748824','vila gióia','','257','06657230','sp','itapevi','',1)
INSERT INTO Paciente VALUES('MARCELO','03/03/2001','','11982138584','547161979','1141449520','Masculino','rua alfa','50321748824','vila gióia','','257','06657230','sp','itapevi','',1)
INSERT INTO Paciente VALUES('MARIA','09/09/1998','','11982138584','547161979','1141449520','Feminino','rua alfa','50321748824','vila gióia','','257','06657230','sp','itapevi','',1)


CREATE TABLE Forma_Pag (
id_forma INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
Descricao VARCHAR(100) NOT NULL,
bandeira VARCHAR(50) NOT NULL,
tipo VARCHAR(50) NOT NULL
)

CREATE TABLE Pagamento (
id_pag INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY,
Valor DECIMAL(10,2) NOT NULL,
Data DATE NOT NULL,
Data_Prevista DATE NOT NULL,
id_forma_FK INTEGER NOT NULL,
FOREIGN KEY(id_forma_FK) REFERENCES Forma_Pag (id_forma),
)

CREATE TABLE Tipo_Servico (
id_servico INTEGER NOT NULL IDENTITY(1,1)PRIMARY KEY,
Des_servico VARCHAR(150) NOT NULL,
valor DECIMAL(15,2) NOT NULL
)

insert into Tipo_Servico (Des_servico, valor)
values ('Restauração',150.00);
insert into Tipo_Servico (Des_servico, valor)
values ('Limpeza',150.00);
insert into Tipo_Servico (Des_servico, valor)
values ('Extração',150.00);
insert into Tipo_Servico (Des_servico, valor)
values ('Canal',150.00);

select * from Tipo_Servico 

Create table dentista_servico(
id_dentista integer,
id_servico integer,
primary key (id_dentista, id_servico),
constraint fk_dentista_servico FOREIGN KEY(id_dentista) REFERENCES Funcionario (id_funcionario)
)



insert into dentista_servico (id_dentista, id_servico) values (1,1);
insert into dentista_servico (id_dentista, id_servico) values (1,2);
insert into dentista_servico (id_dentista, id_servico) values (1,3);
insert into dentista_servico (id_dentista, id_servico) values (2,1);
insert into dentista_servico (id_dentista, id_servico) values (2,2);
insert into dentista_servico (id_dentista, id_servico) values (3,3);



ALTER TABLE Tratamento ADD FOREIGN KEY(id_servico_FK) REFERENCES Tipo_Servico (id_servico)


CREATE TABLE [dbo].[t_UF](
	[CodUF] [int] IDENTITY(1,1) NOT NULL,
	[UF] [varchar](2) NOT NULL) ON [PRIMARY]
GO
insert into t_UF(UF) values ('AL')
insert into t_UF(UF) values ('AP')
insert into t_UF(UF) values ('AM')
insert into t_UF(UF) values ('BA')
insert into t_UF(UF) values ('CE')
insert into t_UF(UF) values ('DF')
insert into t_UF(UF) values ('ES')
insert into t_UF(UF) values ('GO')
insert into t_UF(UF) values ('MA')
insert into t_UF(UF) values ('MT')
insert into t_UF(UF) values ('MS')
insert into t_UF(UF) values ('MG')
insert into t_UF(UF) values ('PA')
insert into t_UF(UF) values ('PB')
insert into t_UF(UF) values ('PR')
insert into t_UF(UF) values ('PE')
insert into t_UF(UF) values ('PI')
insert into t_UF(UF) values ('RJ')
insert into t_UF(UF) values ('RN')
insert into t_UF(UF) values ('RS')
insert into t_UF(UF) values ('RO')
insert into t_UF(UF) values ('RR')
insert into t_UF(UF) values ('SC')
insert into t_UF(UF) values ('SP')
insert into t_UF(UF) values ('SE')
insert into t_UF(UF) values ('TO')




USE [SOS_DENTES]
GO

/****** Object:  Table [dbo].[CepFiltradas$]    Script Date: 06/14/2018 19:47:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CepFiltradas$](
	[CEP] [nvarchar](255) NULL,
	[UF] [nvarchar](255) NULL,
	[Descricao] [nvarchar](255) NULL,
	[Cidade] [nvarchar](255) NULL,
	[Bairro] [nvarchar](255) NULL
) ON [PRIMARY]

GO

CREATE TABLE logins(
id_logins INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
email VARCHAR(150),
senha VARCHAR(50),
cargo VARCHAR(100)
)
INSERT INTO logins VALUES
('ADM','123456','RECEPCIONISTA'),
('joao','123456','DENTISTA')



--SELECT E JOINS 
select f.nome 'DENTISTA', ts.Des_servico 'SERVICO' from dentista_servico ds
inner join Tipo_Servico ts on ts.id_servico = ds.id_servico
inner join Funcionario f on f.id_funcionario = ds.id_dentista
where f.CARGO = 'DENTISTA';

SELECT * FROM [dbo].[CepFiltradas$] 
SELECT * FROM Tratamento
SELECT * FROM Paciente
SELECT * FROM Tipo_Servico
SELECT * FROM dentista_servico
SELECT * FROM t_UF
SELECT * FROM Funcionario
SELECT * FROM logins
SELECT * FROM Pagamento
SELECT * FROM Forma_Pag
SELECT * FROM dentista_servico


select * from logins


