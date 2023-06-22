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
ALTER TABLE ESPECIALIDADES
ADD URL_IMG_ESP VARCHAR(255);
go
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn4.iconfinder.com/data/icons/dental-54/64/implant-premolar-odontology-dental-dentist-512.png'
WHERE ID_ESP = 1;
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn3.iconfinder.com/data/icons/rheumatology/2039/polymyositis_inflammation_muscles_body-512.png'
WHERE ID_ESP = 2;
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn4.iconfinder.com/data/icons/optometrist-5/64/dry_eye_symptom_optometrist_ophtalmology_allergy-512.png'
WHERE ID_ESP = 3;
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn4.iconfinder.com/data/icons/medical-3-color-shadow/128/orthopedics_orthopedic-surgery_traumatology_bones-512.png'
WHERE ID_ESP = 4;
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn3.iconfinder.com/data/icons/medical-healthcare-thick-colored-outline/33/medical-07-512.png'
WHERE ID_ESP = 5;
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn3.iconfinder.com/data/icons/gastroenterology-and-hepatology-1/100/all24_05_16_severe_heartburn_stomach_pain_gastroenterology_hepatology_department-512.png'
WHERE ID_ESP = 6;


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
VALUES
    ('SUPERADMIN', 1),
    ('EMPLEADO', 1),
    ('MEDICO', 1),
    ('PACIENTE', 1);
GO
CREATE TABLE USUARIO(
                        ID_USUARIO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                        DNI VARCHAR(50) NOT NULL,
                        PASSWORD VARCHAR(100) NOT NULL,
                        CORREO VARCHAR(100) NOT NULL,
                        ESTADO BIT NOT NULL,
                        ID_TIPOUSUARIO INT NOT NULL FOREIGN KEY REFERENCES TIPOUSUARIO(ID_TIPOUSUARIO),
);
GO
INSERT INTO USUARIO(DNI, PASSWORD, CORREO, ESTADO, ID_TIPOUSUARIO)
VALUES
    ('ADMIN', '12345678','PROG@PROG.COM',1,1),
    ('ADMIN2','12345678','PROG@PROG.COM',1,1),
    ('EMPLEADO1','12345678','PROG@PROG.COM',1,2),
    ('EMPLEADO2', '12345678','PROG@PROG.COM',1,2),
    ('MEDICO1','12345678','PROG@PROG.COM',1,3),
    ('MEDICO2','12345678','PROG@PROG.COM',1,3),
    ('USER1', '12345678','PROG@PROG.COM',1,4),
    ('USER2','12345678','PROG@PROG.COM',1,4),
    ('USER3','12345678','PROG@PROG.COM',1,4);

GO


CREATE TABLE EMPLEADO(
                         ID_EMPLEADO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                         NOMBRE VARCHAR(50) NOT NULL,
                         APELLIDO VARCHAR(50) NOT NULL,
                         DIRECCION VARCHAR(50) NOT NULL,
                         FECHA_NACIMIENTO DATE NOT NULL,
                         SEXO VARCHAR(20) NOT NULL,
                         ESTADO BIT NOT NULL,
                         TELEFONO VARCHAR(20) NOT NULL,
                         ID_USUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIO(ID_USUARIO),
);
GO
INSERT INTO EMPLEADO(NOMBRE, APELLIDO, DIRECCION, FECHA_NACIMIENTO, SEXO, ESTADO,TELEFONO, ID_USUARIO)
VALUES
    ('PEPEaDM','HONGITO', '12345678','1977/01/01','V',1,'2644000000',1),
    ('PEPEaDM','HONGITO', '12345678','1977/01/01','V',1,'2644000000',2),
    ('PEPEeMP','HONGITO', '12345678','1977/01/01','V',1,'2644000000',3),
    ('PEPEeMP','HONGITO', '12345678','1997/01/01','V',1,'2644000000',4);

GO
CREATE TABLE PACIENTE(
                         ID_PACIENTE INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                         NOMBRE VARCHAR(50) NOT NULL,
                         APELLIDO VARCHAR(50) NOT NULL,
                         DIRECCION VARCHAR(50) NOT NULL,
                         FECHA_NACIMIENTO DATE NOT NULL,
                         SEXO VARCHAR(20) NOT NULL,
                         ESTADO BIT NOT NULL,
                         TELEFONO VARCHAR(20) NOT NULL,
                         ID_USUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIO(ID_USUARIO),
);
GO
INSERT INTO PACIENTE(NOMBRE, APELLIDO, DIRECCION, FECHA_NACIMIENTO, SEXO, ESTADO,TELEFONO, ID_USUARIO)
VALUES
    ('PEPE','HONGITO', '12345678','1977/01/01','V',1,'2644000000',7),
    ('PEPE','HONGITO', '12345678','1977/01/01','V',1,'2644000000',8),
    ('PEPE','HONGITO', '12345678','1977/01/01','V',1,'2644000000',9);

GO
CREATE TABLE MEDICO(
                       ID_MEDICO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                       NOMBRE VARCHAR(50) NOT NULL,
                       APELLIDO VARCHAR(50) NOT NULL,
                       DIRECCION VARCHAR(50) NOT NULL,
                       FECHA_NACIMIENTO DATE NOT NULL,
                       SEXO VARCHAR(20) NOT NULL,
                       ESTADO BIT NOT NULL,
                       TELEFONO VARCHAR(20) NOT NULL,
                       ID_ESP INT NOT NULL FOREIGN KEY REFERENCES ESPECIALIDADES(ID_ESP),
                       ID_USUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIO(ID_USUARIO),
);
GO
INSERT INTO MEDICO(NOMBRE, APELLIDO, DIRECCION, FECHA_NACIMIENTO, SEXO, ESTADO,TELEFONO, ID_ESP, ID_USUARIO)
VALUES
    ('PEPEmED','HONGITO', '12345678','1977/01/01','V',1,'2644000000',1,5),
    ('PEPEmED','HONGITO', '12345678','1977/01/01','V',1,'2644000000',2,6);

GO

CREATE TABLE TURNO (
                       ID_TURNO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                       FECHA DATE NOT NULL,
                       HORA TIME NOT NULL,
                       ESTADO BIT NOT NULL,
                       ID_MEDICO INT NOT NULL FOREIGN KEY REFERENCES MEDICO(ID_MEDICO),
                       ID_PACIENTE INT NOT NULL FOREIGN KEY REFERENCES PACIENTE(ID_PACIENTE),
);
GO
INSERT INTO TURNO(FECHA, HORA, ESTADO, ID_MEDICO, ID_PACIENTE)
VALUES
    ('2023/06/25','10:00',1,1,1),
    ('2023/01/27','10:00',1,2,2),
    ('2023/01/18','10:00',1,1,3);
go
create procedure RegistrarUsuario
    @dni varchar(50),
    @password varchar(50),
    @correo varchar(50),
    @estado bit,
    @tipousuario int

as
insert into Usuario (dni, PASSWORD, CORREO,ESTADO,ID_TIPOUSUARIO) output inserted.ID_Usuario values (@dni, @password, @correo,@estado, @tipousuario)
go

