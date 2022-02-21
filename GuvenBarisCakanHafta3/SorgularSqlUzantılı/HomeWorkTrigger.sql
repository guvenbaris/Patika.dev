-- Absences Tablosuna Insert i�lemi yap�ld�ktan sonra 
-- �al��acak Tr�gger yaz�lm��t�r. Absences tablosunda ki NumberOfWeek'e g�re hesaplama 
--yap�larak SuccessAverages tablosu g�ncellendi.(StudentId'lerin e�it oldu�u yerde.)

ALTER TRIGGER TR_CreateAbsences
ON PatikaDev.dbo.Absences
AFTER INSERT
AS
BEGIN
	DECLARE @studentId INT
	DECLARE @continutiy INT
	DECLARE @average INT

	SELECT @studentId = StudentId,@continutiy = NumberOfWeek FROM INSERTED
	SET @average =  (@continutiy * 100)/7 ;

	UPDATE SuccessAverages SET AveragePercent = @average,StudentId = @studentId
		WHERE StudentId = @studentId
END

--Test ama�l� insert i�lemi yap�lm��t�r.
--INSERT INTO Absences(NumberOfWeek,StudentId)
--	VALUES(5,2)
