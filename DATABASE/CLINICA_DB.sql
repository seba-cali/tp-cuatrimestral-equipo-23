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
      ('EMPLEADO', 1);
      ('CLIENTE', 1);
GO
CREATE TABLE USUARIO(
                        ID_USUARIO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        NOMBRE VARCHAR(50) NOT NULL,
                        USERNAME VARCHAR(50) NOT NULL,
                        PASSWORD VARCHAR(100) NOT NULL,
                        CORREO VARCHAR(100) NOT NULL,
                        TELEFONO VARCHAR(20) NOT NULL,
                        ID_TIPOUSUARIO INT NOT NULL FOREIGN KEY REFERENCES TIPOUSUARIO(ID_TIPOUSUARIO),
);
GO
INSERT INTO USUARIO(NOMBRE, USERNAME, PASSWORD, CORREO, TELEFONO, ID_TIPOUSUARIO)
VALUES('NICOLAS','nico', '12345678','PROG@PROG.COM','2644000000',1),
      ('SEBASTIAN','seba','12345678','PROG@PROG.COM','2644000000',1),
      ('ERIK','erik','12345678','PROG@PROG.COM','2644000000',1);
GO