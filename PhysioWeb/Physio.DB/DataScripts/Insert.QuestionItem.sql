begin

	PRINT 'INSERT DATA INTO QUESTIONITEM'

	DECLARE @PatientID1 INT
	DECLARE @PatientID2 INT

	SET @PatientID1  = ( SELECT top 1 [PatientId]
						FROM [dbo].[Patient]
					    ORDER BY [PatientId]);
	
	SET @PatientID2  = ( SELECT [PatientId]
						FROM [dbo].[QuestionItem]
					    WHERE PatientId = @PatientID1);
	
	IF @PatientID2 IS NULL
		INSERT INTO [dbo].QuestionItem(PatientId, QuestionText, AnswerVal) VALUES (@PatientID1, 'Please enter the level of pain you have experienced over the last week?  Note: A value of 1 means slight pain and 10 indicates excruciating pain.', 0);



	PRINT 'INSERT COMPLETED'

end