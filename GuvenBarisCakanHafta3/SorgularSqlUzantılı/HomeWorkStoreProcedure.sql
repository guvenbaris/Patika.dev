ALTER PROCEDURE InsertStudentToEducation
@studentId INT,
@educationId INT,
@informationId INT,
@workingStatus bit
AS
BEGIN
--De�i�ken tan�mlamalar� yap�lm��t�r.
	DECLARE @studentStartDate smalldatetime
	DECLARE @studentFinishDate smalldatetime
	DECLARE @educationStartDate smalldatetime
	DECLARE @educationFinishDate smalldatetime
	DECLARE @studentEducation INT
	DECLARE @sayi INT
	DECLARE @counter INT
	DECLARE @isValid bit = 0;
	
	SET @counter = 1;

	--Student'�n ka� tane Education'a kay�tl� oldu�unu sayi de�i�kenine atad�k. 
	Select @sayi = COUNT(*) From EducationStudents 
	Where StudentId = @studentId

	--Student'�n 0 dan fazla E�itimi varsa
	IF(@sayi > 0)
		BEGIN
		--Student'�n kay�t olmak istedi�i Education'�n tarhilerine de�i�kenlere atad�k.
			SELECT @educationStartDate = StartingDate  ,@educationFinishDate = ExpirationDate
				FROM Educations Where EducationId = @educationId
	
			WHILE(@counter <= @sayi)
			--Student'�n kay�tl� oldu�u e�itimler i�erisinde d�ng� olu�turduk. B�ylece her e�itiminin kay�t olaca�� 
			-- e�itim tarihi ile ayn� zamanlar i�erisinde olup olmad���n� kontrol edebilece�iz.
				BEGIN
					Select TOP(@counter) @studentEducation = EducationId From EducationStudents 
						Where StudentId = @studentId
					SELECT  @studentStartDate = StartingDate , @studentFinishDate = ExpirationDate 
						FROM Educations Where EducationId = @studentEducation
					--Student'�n E�itimlerinden her hangi biri almak istedi�i e�itim ile ayn� tarihlerdeyse 
					--@isValid = 0 yap ve hata f�rlat.
					IF(@educationStartDate between @studentStartDate and @studentFinishDate
						OR @educationFinishDate between @studentStartDate and @studentFinishDate)
						BEGIN
							SET @isValid = 0;
							THROW 51000, 'The education cannot be in the same date range as the education that the student has received before.', 1;
							BREAK
						END
					ELSE
						BEGIN
							SET @isValid = 1;
						END
				SET @counter += 1;
				END
		END
		ELSE
		--Student'a kay�tl� her hangi bir e�itim yoksa @isValid i 1 yap�yoruz. 
		--E�itime dahil olabilir.
			BEGIN
				SET @isValid = 1;
			END
    IF(@isValid = 1)
	--@isValid kontrol et e�er 1 ise ekle 0 ise hata verdi zaten.
	BEGIN
		INSERT INTO Students (InformationId, WorkingStatus )
			VALUES(@informationId,@workingStatus)
	END
END

--Test ama�l� ekleme i�lemi
EXEC InsertStudentToEducation 1,3,1,0