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
--modificar la tabla ESPECIALIDADES para que URL_IMG_ESP no acepte valores nulos
alter table ESPECIALIDADES
alter column URL_IMG_ESP varchar(255) not null
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
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn0.iconfinder.com/data/icons/scenarium-vol-10/128/019-512.png'
WHERE ID_ESP = 7;
UPDATE ESPECIALIDADES
SET URL_IMG_ESP = 'https://cdn0.iconfinder.com/data/icons/addiction-vivid-vol-1/256/Intoxication-512.png'
WHERE ID_ESP = 8;


GO
INSERT INTO ESPECIALIDADES(NOMBRE, DESCRIPCION)
VALUES('Odontología', 'Especialidad en dientes'),
      ('Kinesiología', 'Especialidad en músculos'),
      ('Oftalmología', 'Especialidad en ojos'),
      ('Traumatología', 'Especialidad en lesiones óseas'),
      ('Otorrinonaringología', 'Especialidad en oídos, nariz y garganta'),
      ('Gastroenterología', 'Especialidad en aparato digestivo');

INSERT INTO ESPECIALIDADES(NOMBRE, DESCRIPCION)
VALUES('ErikVilaplankología', 'Especialidad en motos'),
      ('NicoSanjuanología', 'Especialidad en pérdidas de la memoria por borrachera');



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

USE CLINICA_DB
GO

UPDATE Paciente
SET DNI = '34555666'
WHERE SEXO = 'V';
go

CREATE TABLE MEDICO(
                       ID_MEDICO INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
                       NOMBRE VARCHAR(50) NOT NULL,
                       APELLIDO VARCHAR(50) NOT NULL,
                       DIRECCION VARCHAR(50) NOT NULL,
                       FECHA_NACIMIENTO DATE NOT NULL,
                       SEXO VARCHAR(20) NOT NULL,
                       ESTADO BIT NOT NULL,
                       TELEFONO VARCHAR(20) NOT NULL,
                       turno INT NOT NULL,
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
                       ESTADO BIT NOT NULL,
                       ID_ESP INT NOT NULL FOREIGN KEY REFERENCES ESPECIALIDADES(ID_ESP),
                       ID_MEDICO INT NOT NULL FOREIGN KEY REFERENCES MEDICO(ID_MEDICO),
                       ID_PACIENTE INT NOT NULL FOREIGN KEY REFERENCES PACIENTE(ID_PACIENTE),
                       ID_HORA int NOT NULL,
);
GO
INSERT INTO TURNO(FECHA, ESTADO, ID_MEDICO, ID_PACIENTE)
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
create procedure ActualizarUsuario
    @Id_Usuario int,
    @dni varchar(50),
    @password varchar(50),
    @correo varchar(50),
    @estado bit,
    @tipousuario int

as
UPDATE Usuario SET dni = @dni, PASSWORD = @password, CORREO = @correo, ESTADO = @estado, ID_TIPOUSUARIO = @tipousuario WHERE ID_Usuario = @Id_Usuario

go
create procedure RegistrarEspecialidad
    @nombre varchar(50),
    @descripcion varchar(50)
    

as
insert into ESPECIALIDADES (NOMBRE, DESCRIPCION) output inserted.ID_ESP values (@nombre, @descripcion) 
go
create procedure ActualizarEspecialidad
    @Id_Esp int,
    @nombre varchar(50),
    @descripcion varchar(50)

as
UPDATE ESPECIALIDADES SET NOMBRE = @nombre, DESCRIPCION = @descripcion WHERE ID_ESP = @Id_Esp
go
select * from ESPECIALIDADES


create procedure RegistrarEspecialidad
    @nombre varchar(50),
    @descripcion varchar(50),
    @url_img_esp varchar(150)


as
insert into ESPECIALIDADES (NOMBRE, DESCRIPCION,URL_IMG_ESP) output inserted.ID_ESP values (@nombre, @descripcion,@url_img_esp)
go
create procedure ActualizarEspecialidad
    @Id_Esp int,
    @nombre varchar(50),
    @descripcion varchar(50),
    @url_img_esp varchar(150)

as
UPDATE ESPECIALIDADES SET NOMBRE = @nombre, DESCRIPCION = @descripcion, URL_IMG_ESP=@url_img_esp WHERE ID_ESP = @Id_Esp

-------------- 30/06/2023 Agregar DNI a PACIENTE--------
ALTER TABLE PACIENTE
ADD DNI VARCHAR(10);


ALTER TABLE MEDICO
ADD DNI VARCHAR(10);

ALTER TABLE MEDICO
ADD MATRICULA VARCHAR(10);

  go
create procedure RegistrarPaciente
    @nombre varchar(50),
    @apellido varchar(50),
    @direccion varchar(50),
    @fecha_nacimiento date,
    @sexo varchar(20),
    @estado bit,
    @telefono varchar(20),
    @id_usuario int,
    @dni varchar(10)

as
insert into PACIENTE (NOMBRE,APELLIDO,DIRECCION,FECHA_NACIMIENTO,SEXO,ESTADO,TELEFONO,ID_USUARIO,DNI) output inserted.ID_PACIENTE
values (@nombre, @apellido, @direccion, @fecha_nacimiento, @sexo,@estado,@telefono,@id_usuario,@dni) 
go
create procedure ActualizarPaciente
    @Id_Paciente int,
    @nombre varchar(50),
    @apellido varchar(50),
    @direccion varchar(50),
    @fecha_nacimiento date,
    @sexo varchar(20),
    @estado bit,
    @telefono varchar(20),
    @id_usuario int,
    @dni varchar(10)

as
UPDATE PACIENTE SET NOMBRE=@nombre, APELLIDO=@apellido, DIRECCION=@direccion, FECHA_NACIMIENTO=@fecha_nacimiento,
SEXO=@sexo, ESTADO=@estado, TELEFONO=@telefono, ID_USUARIO=@id_usuario, DNI=@dni WHERE ID_PACIENTE = @Id_Paciente
go



--PROCEDURE PARA LISTAR CON SP LOS PACIENTES
CREATE procedure sp_listarPaciente AS
select ID_PACIENTE, NOMBRE, APELLIDO, DIRECCION, FECHA_NACIMIENTO, SEXO, ESTADO, TELEFONO, ID_USUARIO, DNI 
FROM PACIENTE


--04/07/2022
--SP DE CREAR MEDICOS y eso
  go
create procedure RegistrarMedico
    @nombre varchar(50),
    @apellido varchar(50),
    @direccion varchar(50),
    @fecha_nacimiento date,
    @sexo varchar(20),
    @estado bit,
    @telefono varchar(20),
    @id_usuario int,
    @dni varchar(10),
    @matricula varchar(10)

as
insert into MEDICO (NOMBRE,APELLIDO,DIRECCION,FECHA_NACIMIENTO,SEXO,ESTADO,TELEFONO,ID_USUARIO,DNI,TURNO,MATRICULA) output inserted.ID_MEDICO
values (@nombre, @apellido, @direccion, @fecha_nacimiento, @sexo,@estado,@telefono,@id_usuario,@dni,@matricula) 



go
create procedure ActualizarMedico
    @Id_Medico int,
    @nombre varchar(50),
    @apellido varchar(50),
    @direccion varchar(50),
    @fecha_nacimiento date,
    @sexo varchar(20),
    @estado bit,
    @telefono varchar(20),
    @id_usuario int,
    @dni varchar(10),
    @matricula varchar (10)
    
as
UPDATE MEDICO SET NOMBRE=@nombre, APELLIDO=@apellido, DIRECCION=@direccion, FECHA_NACIMIENTO=@fecha_nacimiento,
SEXO=@sexo, ESTADO=@estado, TELEFONO=@telefono, ID_USUARIO=@id_usuario, DNI=@dni, MATRICULA=@matricula WHERE ID_MEDICO = @Id_Medico
go

  -- Borrar FK_Key de ID_ESP
ALTER TABLE MEDICO
DROP CONSTRAINT FK__MEDICO__ID_ESP__571DF1D5; --ojo aca, se llama distinto el numero en cada maquina

-- Borrar columna
ALTER TABLE MEDICO
DROP COLUMN ID_ESP;

--Creacion de tabla para asociar Medico a Especialidad

  CREATE TABLE EspecialidadxMedico (
    id_EspecialidadxMedico INT IDENTITY(1,1) PRIMARY KEY,
    ID_MEDICO INT,
    ID_ESPECIALIDAD INT,
    FOREIGN KEY (ID_MEDICO) REFERENCES MEDICO (ID_MEDICO),
    FOREIGN KEY (ID_ESPECIALIDAD) REFERENCES ESPECIALIDADES (ID_ESP)
);
  
    --SP PARA SP para Tabla temporal de recuperoi de password
   
    create table ResetPassword(
        ID_ResetPassword int identity(1,1) primary key,
        ID_Usuario int foreign key references Usuario(ID_Usuario),
        CODIGO varchar(100),
        FECHA date,
        ESTADO bit
    );
    go
create procedure RegistrarRecupero
    @id_ResetPassword int,
    @id_usuario int,
    @codigo varchar(100),
    @fecha date,
    @estado bit
    as 
    insert into ResetPassword (ID_Usuario,CODIGO,FECHA,ESTADO) output inserted.ID_ResetPassword values (@id_usuario,@codigo,@fecha,@estado)
go
create procedure UpdateResetPassword
    @Id_Usuario int,
    @password varchar(50)
   

    as
    UPDATE Usuario SET PASSWORD = @password  WHERE ID_Usuario = @Id_Usuario
go
create procedure UpdateRecupero
    @codigo varchar(100),
    @Estado bit

as
UPDATE ResetPassword SET Estado = @Estado  WHERE codigo = @codigo

GO

  CREATE PROCEDURE RegistrarEspecialidadxMedico
    @idmedico INT,
    @idespecialidad INT,
    @Turno int
AS
BEGIN
    INSERT INTO EspecialidadxMedico (ID_MEDICO, ID_ESPECIALIDAD, TURNO_HORARIO)
    VALUES (@idmedico, @idespecialidad, @Turno)
END

--Eliminar FK de ID_ESP en MEDICO y borrar columna
ALTER TABLE dbo.MEDICO
DROP CONSTRAINT FK__MEDICO__ID_ESP__59063A47;
GO
alter table MEDICO
    drop column ID_ESP;


alter TABLE Turno
add ObservacionMedico varchar(250) not null default 'Sin observaciones';
alter TABLE Turno
add NumGenerado int not null default 0;


    --12/07/2023
    --convertir la columna matricula en medico en unica para validar que no se repitan
ALTER TABLE MEDICO
ADD CONSTRAINT UQ_MATRICULA UNIQUE (MATRICULA)
GO
--ESTK HACE QUE LA COMBINACION ENTRE MEDICO ESPECILIDAD Y TURNO SEA UNICA Y NO PUEDA REPETIRSE DICHA COMBINACION
ALTER TABLE EspecialidadxMedico
ADD CONSTRAINT UQ_ESPXMED_COMB UNIQUE (ID_MEDICO, ID_ESPECIALIDAD, TURNO_HORARIO)
GO

ALTER TABLE USUARIO
    ADD CONSTRAINT UQ_USERNAME UNIQUE (USERNAME)

ALTER TABLE USUARIO
    ADD CONSTRAINT UQ_CORREO UNIQUE (CORREO);

alter table USUARIO
    add IMG_URL varchar(255) not null default '../assets/dist/assets/img/illustrations/profiles/profile-2.png'