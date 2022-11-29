use PersonTable

CREATE TABLE PESSOAS (
  IDTIPO          int identity(1,1)        PRIMARY KEY,
  NOME       VARCHAR(50)   NOT NULL,
  ENDEREÇO   VARCHAR(50)  NOT NULL,
);
