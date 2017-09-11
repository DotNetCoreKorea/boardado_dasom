--[2] 게시판에서 데이터 출력
CREATE PROCEDURE [dbo].[ListNotes]
	@Page Int
AS
	with DotNetNoteOrederedLists
	AS
	(Select 

		[Id], [Name], [Email], [Title], [PostDate], [ReadCount], 
		[Ref], [Step], [RefOrder], [AnswerNum], [ParentNum],
		[CommentCount], [FileName], [FileSize], [DownCount],
		ROW_NUMBER() Over (Order By Ref Desc, RefOrder Asc)
		As 'RowNumber'
		FROM Notes
)
Select * From DotNetNoteOrederedLists Where RowNumber Between @Page * 10 +1 And(@Page + 1) *10
	
