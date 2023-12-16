CREATE DATABASE EncuestaUH
GO

USE EncuestaUH
GO
--Tablas
CREATE TABLE Encuesta 
(
	EncuestaID int identity (0,1) PRIMARY KEY,
	Nombre varchar (50) NOT NULL,
	Edad int NOT NULL,
	CorreoElectronico varchar (50) NOT NULL,
	Partido varchar (50) NOT NULL
)
GO

CREATE TABLE TiposPartidos 
(
	TipoPartido varchar (5) NOT NULL,
)
GO

--Procedimientos almacenados
CREATE PROCEDURE AGREGARENCUESTA

	@Nombre VARCHAR(50),
	@Edad int,
	@CorreoElectronico VARCHAR(50),
	@Partido VARCHAR(50)


AS
	BEGIN 
		INSERT INTO Encuesta (Nombre, Edad, CorreoElectronico, Partido)
		VALUES (@Nombre, @Edad, @CorreoElectronico, @Partido)
	END
GO


CREATE PROCEDURE BORRARENCUESTA

	@EncuestaID INT 
	AS
		BEGIN 
			DELETE Encuesta WHERE EncuestaID = @EncuestaID
		END
GO

CREATE PROCEDURE CONSULTAENCUESTA_FILTRO_Partido
	@Partido VARCHAR(50)
	AS
		BEGIN
			SELECT * FROM Encuesta WHERE @Partido  = @Partido
		END
GO



CREATE PROCEDURE AGREGARPARTIDOS

	@TipoPartido varchar (5)

	AS
		BEGIN 
			INSERT INTO TiposPartidos (TipoPartido)
			VALUES (@TipoPartido)
		END
GO

EXEC AGREGARPARTIDOS 'PLN'
EXEC AGREGARPARTIDOS 'PUSC'
EXEC AGREGARPARTIDOS 'PAC'


--Procedimientos de prueba

EXEC AGREGARENCUESTA 'Adrian', 26, 'Adrian@gmail.com', 'PLN'
EXEC BORRARENCUESTA 1

EXEC CONSULTAENCUESTA_FILTRO_Partido 'PLN'

SELECT * FROM Encuesta 