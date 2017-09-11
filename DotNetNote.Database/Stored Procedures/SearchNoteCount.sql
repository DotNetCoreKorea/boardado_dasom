--[6] 검색 결과의 레코드 수 변환
CREATE PROCEDURE [dbo].[SearchNoteCount]
	@SearchField  Nvarchar(25),
	@SearchQuery Nvarchar(25)
AS
	Set @SearchQuery = '%' + @SearchQuery + '%'

	Select count(*)
	FROM Notes
	Where 
	(
		Case @SearchField
			When 'Name' Then [Name]
			When 'Title' Then Title
			When 'Content' Then Content
			Else @SearchQuery
		END
	)
	Like
	@SearchQuery
GO