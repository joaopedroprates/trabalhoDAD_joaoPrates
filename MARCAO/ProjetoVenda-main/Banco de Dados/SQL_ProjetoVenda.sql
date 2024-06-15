
CREATE DATABASE FUNEC24_DAD;

CREATE TABLE SEXO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(9) NOT NULL UNIQUE
);

CREATE TABLE RUA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE BAIRRO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE CEP(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NUMERO CHAR(9) NOT NULL UNIQUE
);

CREATE TABLE UF(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE,
	SIGLA CHAR(2) NOT NULL UNIQUE,
);

CREATE TABLE TRABALHO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE OPERADORA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE FUNCAO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE LOJA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE,
	CNPJ VARCHAR(80) NOT NULL UNIQUE,
	NOMEFANTASIA VARCHAR(80),
	RAZAOSOCIAL VARCHAR(80)
);

CREATE TABLE ACESSO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE MARCA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE TIPO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);
CREATE TABLE SITUACAO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(40) NOT NULL UNIQUE
);
INSERT INTO SEXO (NOME) VALUES
    ('Masculino'),
    ('Feminino'),
    ('Outro'),
    ('N�o informado'),
    ('Prefiro n�o dizer');

INSERT INTO RUA (NOME) VALUES
    ('Rua A'),
    ('Rua B'),
    ('Rua C'),
    ('Rua D'),
    ('Rua E');

INSERT INTO BAIRRO (NOME) VALUES
    ('Bairro X'),
    ('Bairro Y'),
    ('Bairro Z'),
    ('Bairro W'),
    ('Bairro V');

INSERT INTO CEP (NUMERO) VALUES
    ('12345-678'),
    ('98765-432'),
    ('54321-876'),
    ('67890-321'),
    ('23456-789');
INSERT INTO UF (NOME,SIGLA) VALUES 
	('S�O PAULO','SP'),
	('RIO DE JANEIRO', 'RJ'),
	('MINAS GERAIS', 'MG'),
	('RIO GRANDE DO SUL', 'RS'),
	('PARAN�', 'PR');
	INSERT INTO TRABALHO (NOME) VALUES
    ('Vendedor'),
    ('Gerente'),
    ('Analista'),
    ('Engenheiro'),
    ('Desenvolvedor');

INSERT INTO OPERADORA (NOME) VALUES
    ('Vivo'),
    ('Tim'),
    ('Claro'),
    ('Oi'),
    ('Nextel');

INSERT INTO FUNCAO (NOME) VALUES
    ('Atendimento ao cliente'),
    ('Gest�o de equipes'),
    ('An�lise de dados'),
    ('Desenvolvimento de software'),
    ('Engenharia de sistemas');

INSERT INTO LOJA (NOME, CNPJ, NOMEFANTASIA, RAZAOSOCIAL) VALUES
    ('Loja A', '12345678901234', 'Fantasia A', 'Razao A'),
    ('Loja B', '98765432109876', 'Fantasia B', 'Razao B'),
    ('Loja C', '45678901234567', 'Fantasia C', 'Razao C'),
    ('Loja D', '32109876543210', 'Fantasia D', 'Razao D'),
    ('Loja E', '78901234567890', 'Fantasia E', 'Razao E');

INSERT INTO ACESSO (NOME) VALUES

    ('Total'),
    ('Restrito'),
    ('Parcial'),
    ('Administrativo'),
    ('Visitante');
INSERT INTO MARCA (NOME) VALUES
    ('Marca A'),
    ('Marca B'),
    ('Marca C'),
    ('Marca D'),
    ('Marca E');
INSERT INTO TIPO (NOME) VALUES
    ('Eletr�nico'),
    ('Vestu�rio'),
    ('Aliment�cio'),
    ('M�veis'),
    ('Automotivo');

INSERT INTO SITUACAO (NOME) VALUES
    ('Ativo'),
    ('Inativo'),
    ('Em andamento'),
    ('Conclu�do'),
    ('Pendente');

CREATE TABLE CIDADE(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE,
	CODUF_FK INTEGER REFERENCES UF(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE
);

CREATE TABLE CLIENTE(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	FOTO VARBINARY(MAX),
	DATANASC DATE NOT NULL,
	CODSEXO_FK INTEGER REFERENCES SEXO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODRUA_FK INTEGER REFERENCES RUA(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODBAIRRO_FK INTEGER REFERENCES BAIRRO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODCEP_FK INTEGER REFERENCES CEP(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODCIDADE_FK INTEGER REFERENCES CIDADE(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	SALARIO NUMERIC(10,2) NOT NULL,
	CODTRABALHO_FK INTEGER REFERENCES TRABALHO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	NUMEROCASA VARCHAR(30) NOT NULL,   
);

CREATE TABLE TELEFONE(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NUMERO VARCHAR(14) NOT NULL UNIQUE,
	CODOPERADORA_FK INTEGER REFERENCES OPERADORA(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
);
CREATE TABLE VENDA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DATAVENDA DATE NOT NULL,
	CODCLIENTE_FK INTEGER REFERENCES CLIENTE(COD) ON DELETE CASCADE
	              ON UPDATE CASCADE
);
CREATE TABLE FUNCIONARIO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	NUMEROCASA VARCHAR(30) NOT NULL,
	CODRUA_FK INTEGER REFERENCES RUA(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODBAIRRO_FK INTEGER REFERENCES BAIRRO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODCEP_FK INTEGER REFERENCES CEP(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODCIDADE_FK INTEGER REFERENCES CIDADE(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	CODFUNCAO_FK INTEGER REFERENCES FUNCAO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
	SALARIO NUMERIC(10,2) NOT NULL,
	CODLOJA_FK INTEGER REFERENCES LOJA(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE,
);
CREATE TABLE LOGINS(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	SENHA VARCHAR(80) NOT NULL,
	CODFUNCIONARIO_FK INTEGER REFERENCES FUNCIONARIO(COD) ON DELETE CASCADE
	           ON UPDATE CASCADE
);
CREATE TABLE CONTROLELOGINSSISTEMA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	CODLOGINS_FK INTEGER REFERENCES LOGINS(COD) ON DELETE CASCADE
			ON UPDATE CASCADE,
	DATAS DATE NOT NULL,
	HORA TIME NOT NULL
);
INSERT INTO CONTROLELOGINSSISTEMA (CODLOGINS_FK, DATAS, HORA) VALUES
    (1, '2023-11-29', '08:30:00'),
    (1, '2023-11-29', '10:15:00'),
    (1, '2023-11-29', '12:00:00'),
    (1, '2023-11-30', '09:00:00'),
    (1, '2023-11-30', '14:45:00');
CREATE TABLE TIPOPRODUTO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE PRODUTO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	QUANT NUMERIC(10,2) NOT NULL,
	VALOR NUMERIC(10,2) NOT NULL,
	CODMARCA_FK INTEGER REFERENCES MARCA(COD) ON DELETE CASCADE
	            ON UPDATE CASCADE,
	CODTIPOPRODUTO_FK INTEGER REFERENCES TIPOPRODUTO(COD) 
	                  ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE VENDAPRODUTO(
	CODVENDA_FK INTEGER REFERENCES VENDA(COD) ON DELETE CASCADE
	            ON UPDATE CASCADE,
	CODPRODUTO_FK INTEGER REFERENCES PRODUTO(COD) ON DELETE CASCADE
	            ON UPDATE CASCADE,
	QUANTV NUMERIC(10,2) NOT NULL,
	VALORV NUMERIC(10,2) NOT NULL,
	PRIMARY KEY(CODVENDA_FK, CODPRODUTO_FK)
);

CREATE TABLE FOTOPRODUTO(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DESCRICAO VARCHAR(255) NOT NULL,
	IMAGEM VARBINARY(MAX) NOT NULL,
	CODPRODUTO_FK INTEGER REFERENCES PRODUTO(COD) ON DELETE CASCADE
	              ON UPDATE CASCADE
);



CREATE TABLE PARCELAVENDA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DATAVENCIMENTO DATE NOT NULL,
	VALORPARCELA NUMERIC(10,2) NOT NULL,
	CODSITUACAO_FK INTEGER REFERENCES SITUACAO(COD) ON DELETE CASCADE
	               ON UPDATE CASCADE, 
	CODVENDA_FK INTEGER REFERENCES VENDA(COD) ON DELETE CASCADE
	               ON UPDATE CASCADE
);


CREATE TABLE FORNECEDOR(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(80) NOT NULL,
	CNPJ CHAR(18) NOT NULL UNIQUE .
);

CREATE TABLE COMPRA(
	COD INTEGER IDENTITY(1,1) PRIMARY KEY,
	DATACOMPRA DATE NOT NULL,
	CODFORNECEDOR_FK INTEGER REFERENCES FORNECEDOR (COD) ON DELETE
	                 CASCADE ON UPDATE CASCADE
);

CREATE TABLE COMPRAPRODUTO(
	CODCOMPRA_FK INTEGER REFERENCES COMPRA(COD)  ON DELETE
	             CASCADE ON UPDATE CASCADE,
	CODPRODUTO_FK INTEGER REFERENCES PRODUTO(COD)  ON DELETE
	             CASCADE ON UPDATE CASCADE,
	QUANTC NUMERIC(10,2) NOT NULL,
	VALORC NUMERIC(10,2) NOT NULL,
	PRIMARY KEY(CODCOMPRA_FK, CODPRODUTO_FK)
);
CREATE TABLE ITENSTELCLIENTE(
	CODTELEFONE INTEGER REFERENCES TELEFONE(COD)  ON DELETE
	             CASCADE ON UPDATE CASCADE,
	CODCLIENTE INTEGER REFERENCES CLIENTE(COD)  ON DELETE
	             CASCADE ON UPDATE CASCADE,
	PRIMARY KEY(CODTELEFONE, CODCLIENTE)
);