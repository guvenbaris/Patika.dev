--VIEW oluþturulmuþtur. Toplamda 4 Tablo birleþtirildi. 
--Educations ve Students tablolarý arasýnda many-to-many iliþki olduðundan dolayý ve de 
--Student Information bilgilerinin gösterilmek istenmesinden dolayý.
--Education lara göre Student larý ve de Student Infortmation lar getiriliyor. Sýralý olarak.
--Gruplu olarak kýsmýn da tam olarak ne denildiðini anlamadým. Ondan dolayý böyle bir çözüm yaptým.
CREATE VIEW EducationStudentView AS 
	SELECT Es.EducationId,P.[Name],P.Surname,P.Email,P.Telephone,P.DateJoined
	FROM EducationStudents as Es
    join Students as S on Es.StudentId = S.StudentId
	join PersonelInformations as P on S.InformationId = P.InformationId
	join Educations as E on E.EducationId = Es.EducationId
	Order By Es.EducationId  OFFSET 0 rows

SELECT * FROM EducationStudentView WHERE EducationId = 1

--Gruplu olarak Group By kullanýmýysa bu þekilde bir View oluþturulabilir.
--CREATE VIEW EducationStudentWithGroupBy AS
--	SELECT E.EducationId,COUNT(*) as TotalStudent
--	FROM EducationStudents as Es join
--	Students as S on Es.StudentId = S.StudentId
--	join PersonelInformations as P on S.InformationId = P.InformationId
--	join Educations as E on E.EducationId = Es.EducationId
--	GROUP BY E.EducationId