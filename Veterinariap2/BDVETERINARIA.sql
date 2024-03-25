create database DBVETERINARIA
USE DBVETERINARIA

CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY,
    login_usuario VARCHAR(50) NOT NULL,
    clave_usuario VARCHAR(50) NOT NULL,
    nombre_usuario VARCHAR(75) NOT NULL
)
GO

CREATE TABLE Mascota (
 id_mascota INT PRIMARY KEY IDENTITY(1,1),
 nombre_mascota VARCHAR (75) NOT NULL,
 tipo_mascota VARCHAR (50) NOT NULL,
 comida_favorita VARCHAR (50) NOT NULL,
)
GO

CREATE TABLE Cita (
 id_mascota INT PRIMARY KEY,
 proxima_fecha DATE UNIQUE NOT NULL,
 medico_asiganado VARCHAR (75) NOT NULL

 CONSTRAINT Fk_idmascota FOREIGN KEY (id_mascota) REFERENCES Mascota(id_mascota)
)

INSERT INTO Mascota VAlUES('MAX', 'PITBULL', 'CARNE');
INSERT INTO Mascota VAlUES('CHESTER', 'BULLTERRIER', 'POLLO');


SELECT *FROM Mascota