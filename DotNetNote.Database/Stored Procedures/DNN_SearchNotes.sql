--[9] 게시판에서 데이터 검색 리스트
CREATE PROCEDURE [dbo].[DNN_SearchNotes]
	@Page Int,
	@SearchField Nvarchar(25),
	@SearchQuery Nvarchar(25)
AS
	with DotNetNoteOrderedLists
	AS
	(
		Select 
			[Id], [Name], [Email], [Title], [PostDate], [ReadCount],
			 [Ref], [Step], [RefOrder], [AnswerNum], 
			[ParentNum], [CommentCount], [FileName], [FileSize],[DownCount]	,
			ROW_NUMBER() Over (Order By Ref Desc, RefOrder  ASC)
			AS 'RowNumber'
			FROM Notes
			Where
			(
				Case  @SearchField 
					When 'Name' Then [Name]
					when 'Title' Then [Title]
					When 'Content' Then [Content]
					Else
						@SearchQuery
				End
			Like '%' + @SearchQuery + '%'
			)
	)
	Select 
		[Id], [Name], [Email], [Title], [PostDate],
		[ReadCount], [Ref], [Step], [RefOrder], 
		[AnswerNum], [ParentNum], [CommentCount],
		[FileName], [FileSize],[DownCount], [RowNumber]
		From DotNetNoteOrderedLists
		Where RowNumber Between @Page * 10 +1 And (@Page + 1) * 10
		Order By Id Desc
GO
