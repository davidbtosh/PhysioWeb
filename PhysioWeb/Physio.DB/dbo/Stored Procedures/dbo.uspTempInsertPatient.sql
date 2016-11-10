CREATE PROCEDURE [dbo].[uspTempInsertPatient]
	@LastName varchar(50) = '',
	@FirstName varchar(50) = '',
	@DoB date,
	@Gender int = 0
AS
	

	DECLARE @PatientId  INT

	SET @PatientId  = ( SELECT [Id]
						FROM [dbo].[Patient]
					    WHERE LastName = @LastName
					    AND FirstName = @FirstName
					    AND DoB = @DoB);

	IF @PatientId IS NULL
		INSERT INTO [dbo].Patient(LastName, FirstName, DoB, GenderTypeId) VALUES (@LastName, @FirstName, @DoB, @Gender)



RETURN 0