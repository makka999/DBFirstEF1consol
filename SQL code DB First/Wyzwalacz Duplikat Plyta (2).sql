USE KolekcjaPlyt
GO

CREATE TRIGGER WyzwalaczDuplikatPlyta
ON Plyta
INSTEAD OF INSERT

AS

	BEGIN

		DECLARE @nazwa VARCHAR(80)
		DECLARE @komentarz VARCHAR(255)		
		DECLARE @rodzaj VARCHAR(20)
		DECLARE @status VARCHAR(20)		
		DECLARE @nabycie INT	
		
		SELECT @nazwa = Nazwa, @komentarz = Komentarz, @rodzaj = RodzajPlyty,
		@status = StatusPosiadania, @nabycie = IdNabycie
		FROM inserted
		IF EXISTS (SELECT 1 FROM Plyta
		WHERE @nazwa = Nazwa AND @komentarz = Komentarz AND @rodzaj = RodzajPlyty 
		AND @status = StatusPosiadania AND @nabycie = IdNabycie)
		ROLLBACK
		PRINT N'Istnieje taka p³yta'

		IF NOT EXISTS (SELECT 1 FROM Plyta
		WHERE @nazwa = Nazwa AND @komentarz = Komentarz AND @rodzaj = RodzajPlyty 
		AND @status = StatusPosiadania AND @nabycie = IdNabycie)

			INSERT INTO Plyta
			VALUES (@nazwa, @komentarz, @rodzaj, @status, @nabycie)

	END
;



