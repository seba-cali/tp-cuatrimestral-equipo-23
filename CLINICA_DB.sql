CREATE DATABASE CLINICA_DB;
Go
USE CLINICA_DB;
GO
CREATE TABLE ESPECIALIDADES(
    ID_ESP INT NOT NULL identity (1,1),
    NOMBRE VARCHAR(50) NOT NULL,
    DESCRIPCION VARCHAR(100) NOT NULL,
    PRIMARY KEY(ID_ESP)
);
GO
INSERT INTO ESPECIALIDADES(NOMBRE, DESCRIPCION)
VALUES('Odontología', 'Especialidad en dientes'),
('Kinesiología', 'Especialidad en músculos'),
('Oftalmología', 'Especialidad en ojos'),
('Traumatología', 'Especialidad en lesiones óseas'),
('Otorrinonaringología', 'Especialidad en oídos, nariz y garganta'),
('Gastroenterología', 'Especialidad en aparato digestivo');

GO


CREATE TABLE TIPOUSUARIO(
                            ID_TIPOUSUARIO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                            TIPO VARCHAR(20) UNIQUE NOT NULL,
                            ESTADO BIT NOT NULL
)
GO
INSERT INTO TIPOUSUARIO(TIPO, ESTADO)
VALUES('SUPERADMIN', 1),
      ('ADMIN', 1),
      ('CLIENTE', 1);
GO
CREATE TABLE USUARIO(
                        ID_USUARIO INT NOT NULL identity (1,1),
                        PRIMARY KEY(ID_USUARIO),
                        ID_TIPOUSUARIO INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES TIPOUSUARIO(ID_TIPOUSUARIO),
                        USUARIO VARCHAR(50) NOT NULL,
                        PASSWORD VARCHAR(100) NOT NULL,
                        );
GO
INSERT INTO USUARIO(USUARIO, PASSWORD, ID_TIPOUSUARIO)
VALUES('nico', '12345678',1),
      ('seba','12345678',1),
      ('erik','12345678',1);
GO