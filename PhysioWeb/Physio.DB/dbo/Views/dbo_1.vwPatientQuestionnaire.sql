CREATE VIEW dbo.vwPatientQuestionnaire
AS
SELECT        p.Id AS PatientId, p.LastName + ', ' + p.FirstName AS PatientName, pq.QuestionSetId, pq.Id AS PatientQuestionnaireId, pq.QuestionnaireDate, qs.QuestionSetName, q.Id AS QuestionId, q.QuestionTitle, 
                         q.QuestionAbbreviation, q.QuestionHint, q.UIcaption, qt.Description, pa.Answer
FROM            dbo.Patient AS p INNER JOIN
                         dbo.PatientQuestionnaire AS pq ON p.Id = pq.PatientId INNER JOIN
                         dbo.QuestionSet AS qs ON qs.Id = pq.QuestionSetId INNER JOIN
                         dbo.QuestionSetQuestion AS qsq ON qs.Id = qsq.QuestionSetId INNER JOIN
                         dbo.Question AS q ON qsq.QuestionId = q.Id INNER JOIN
                         dbo.QuestionSetQuestion AS qsq2 ON q.Id = qsq2.QuestionId INNER JOIN
                         dbo.QuestionType AS qt ON q.QuestionTypeId = qt.Id LEFT OUTER JOIN
                         dbo.PatientAnswer AS pa ON p.Id = pa.PatientId AND pq.Id = pa.QuestionnaireId AND q.Id = pa.QuestionId
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwPatientQuestionnaire';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'lumn = 0
         End
         Begin Table = "qsq2"
            Begin Extent = 
               Top = 120
               Left = 471
               Bottom = 233
               Right = 641
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwPatientQuestionnaire';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[66] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2) )"
      End
      ActivePaneConfig = 5
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pq"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "qsq"
            Begin Extent = 
               Top = 6
               Left = 471
               Bottom = 119
               Right = 641
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "qs"
            Begin Extent = 
               Top = 6
               Left = 679
               Bottom = 102
               Right = 864
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "q"
            Begin Extent = 
               Top = 6
               Left = 902
               Bottom = 136
               Right = 1107
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "qt"
            Begin Extent = 
               Top = 6
               Left = 1145
               Bottom = 119
               Right = 1315
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pa"
            Begin Extent = 
               Top = 102
               Left = 679
               Bottom = 232
               Right = 852
            End
            DisplayFlags = 280
            TopCo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwPatientQuestionnaire';

