ALTER PROCEDURE InsertStudentToEducation
@studentId INT,
@educationId INT,
@informationId INT,
@workingStatus bit
AS
BEGIN
--Deðiþken tanýmlamalarý yapýlmýþtýr.
	DECLARE @studentStartDate smalldatetime
	DECLARE @studentFinishDate smalldatetime
	DECLARE @educationStartDate smalldatetime
	DECLARE @educationFinishDate smalldatetime
	DECLARE @studentEducation INT
	DECLARE @sayi INT
	DECLARE @counter INT
	DECLARE @isValid bit = 0;
	
	SET @counter = 1;

	--Student'ýn kaç tane Education'a kayýtlý olduðunu sayi deðiþkenine atadýk. 
	Select @sayi = COUNT(*) From EducationStudents 
	Where StudentId = @studentId

	--Student'ýn 0 dan fazla Eðitimi varsa
	IF(@sayi > 0)
		BEGIN
		--Student'ýn kayýt olmak istediði Education'ýn tarhilerine deðiþkenlere atadýk.
			SELECT @educationStartDate = StartingDate  ,@educationFinishDate = ExpirationDate
				FROM Educations Where EducationId = @educationId
	
			WHILE(@counter <= @sayi)
			--Student'ýn kayýtlý olduðu eðitimler içerisinde döngü oluþturduk. Böylece her eðitiminin kayýt olacaðý 
			-- eðitim tarihi ile ayný zamanlar içerisinde olup olmadýðýný kontrol edebileceðiz.
				BEGIN
					Select TOP(@counter) @studentEducation = EducationId From EducationStudents 
						Where StudentId = @studentId
					SELECT  @studentStartDate = StartingDate , @studentFinishDate = ExpirationDate 
						FROM Educations Where EducationId = @studentEducation
					--Student'ýn Eðitimlerinden her hangi biri almak istediði eðitim ile ayný tarihlerdeyse 
					--@isValid = 0 yap ve hata fýrlat.
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
		--Student'a kayýtlý her hangi bir eðitim yoksa @isValid i 1 yapýyoruz. 
		--Eðitime dahil olabilir.
			BEGIN
				SET @isValid = 1;
			END
    IF(@isValid = 1)
	--@isValid kontrol et eðer 1 ise ekle 0 ise hata verdi zaten.
	BEGIN
		INSERT INTO Students (InformationId, WorkingStatus )
			VALUES(@informationId,@workingStatus)
	END
END

--Test amaçlý ekleme iþlemi
EXEC InsertStudentToEducation 1,3,1,0