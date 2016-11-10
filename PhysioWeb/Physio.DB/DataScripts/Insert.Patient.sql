begin

	PRINT 'INSERT DATA INTO PATIENT'

	EXEC [dbo].[uspTempInsertPatient]  @Lastname = 'Mackintosh',  @FirstName = 'David', @DoB = '1969-02-01', @Gender = 1
	
	PRINT 'INSERT COMPLETED'

end