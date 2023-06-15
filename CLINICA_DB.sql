CREATE DATABASE CLINICA_DB;
Go
USE CLINICA_DB;
GO
CREATE TABLE ESPECIALIDADES(
    ID_ESP INT NOT NULL identity (1,1),
    NOMBRE VARCHAR(50) NOT NULL,
    DESCRIPCIÓN VARCHAR(100) NOT NULL,
    PRIMARY KEY(ID_ESP)
);
GO
INSERT INTO ESPECIALIDADES(NOMBRE, DESCRIPCIÓN)
VALUES('Odontología', 'Especialidad en dientes'),
('Kinesiología', 'Especialidad en músculos'),
('Oftalmología', 'Especialidad en ojos'),
('Traumatología', 'Especialidad en lesiones óseas'),
('Otorrinonaringología', 'Especialidad en oídos, nariz y garganta'),
('Gastroenterología', 'Especialidad en aparato digestivo');
GO
