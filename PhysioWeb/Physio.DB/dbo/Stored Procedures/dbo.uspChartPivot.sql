
CREATE PROCEDURE [dbo].[uspChartPivot]
@PatientId NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
		DECLARE @cols AS NVARCHAR(MAX),
				@query  AS NVARCHAR(MAX)



		select @cols = STUFF((SELECT ',' + QUOTENAME(QuestionAbbreviation) 
							from vwPatientChartData
							group by QuestionAbbreviation, QuestionId
							order by QuestionId
					FOR XML PATH(''), TYPE
					).value('.', 'NVARCHAR(MAX)') 
				,1,1,'')

		set @query = N'SELECT QuestionnaireDate, ' + @cols + N' from 
					 (
						select QuestionnaireDate, QuestionAbbreviation, Answer
						from vwPatientChartData where PatientId = ' + @PatientId + N'
					) x
					pivot 
					(
						max(Answer)
						for QuestionAbbreviation in (' + @cols + N')
					) p '

		exec sp_executesql @query;
END