USE KolekcjaPlyt
GO

CREATE TRIGGER WyzwalaczWypozyczeniaStatus
ON Wypozyczenie
AFTER INSERT, UPDATE
NOT FOR REPLICATION
AS

	BEGIN

		DECLARE @ID INT
		DECLARE @dataWy DATE
		DECLARE @dataOd DATE		

		SELECT @dataWy = DataWypozyczenia, @dataOd = DataOddania, @ID = IdPlyta
		FROM inserted
		IF EXISTS (SELECT 1 FROM inserted
		WHERE DataWypozyczenia IS NOT NULL AND DataOddania IS NULL)
		UPDATE Plyta
		SET StatusPosiadania = 'Wypo¿yczona'
		WHERE IdPlyta = @ID

		IF EXISTS (SELECT 1 FROM inserted
		WHERE DataWypozyczenia IS NOT NULL AND DataOddania IS NOT NULL)
		UPDATE Plyta
		SET StatusPosiadania = 'Oddana'
		WHERE IdPlyta = @ID

	END
;


