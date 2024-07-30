CREATE TABLE Membros (
    IdMembro         serial       NOT NULL,
	Nome             varchar(64)  NOT NULL,
	Genero           varchar      NOT NULL,
	Ministerio       smallint,	  
    Endereço         varchar(128) NOT NULL,
    CEP              varchar(9)   NOT NULL,
    DataDeNascimento date         NOT NULL,
    EstadoCivil      smallint     NOT NULL,
	Batizado 	     bool 		  NOT NULL,
	Celular          varchar(14),
	Telefone         varchar(13),
	
	CONSTRAINT Membros_IdMembro_PK PRIMARY KEY(IdMembro)
);

CREATE INDEX Membros_IdMembro_Index ON Membros (IdMembro);
CREATE INDEX Membros_Nome_Index ON Membros (Nome);
CREATE INDEX Membros_Genero_Index ON Membros (Genero);