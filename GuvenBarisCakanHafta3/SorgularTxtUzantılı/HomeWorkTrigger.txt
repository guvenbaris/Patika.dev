-- Absences Tablosuna Insert iþlemi yapýldýktan sonra 
-- çalýþacak Trýgger yazýlmýþtýr. Absences tablosunda ki NumberOfWeek'e göre hesaplama 
--yapýlarak SuccessAverages tablosu güncellendi.(StudentId'lerin eþit olduðu yerde.)

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

--Test amaçlý insert iþlemi yapýlmýþtýr.
--INSERT INTO Absences(NumberOfWeek,StudentId)
--	VALUES(5,2)
