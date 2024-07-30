CREATE TABLE MinisterioJovens (
    IdMembro integer     NOT NULL,
	Cargo    varchar(64) NOT NULL,
	
	CONSTRAINT MinisterioJovens_IdMembro_PK PRIMARY KEY(IdMembro),
	CONSTRAINT MinisterioJovens_Membros_IdMembro_fk FOREIGN KEY(IdMembro) REFERENCES Membros(IdMembro)
);

CREATE INDEX MinisterioJovens_IdMembro_Index ON MinisterioJovens (IdMembro);