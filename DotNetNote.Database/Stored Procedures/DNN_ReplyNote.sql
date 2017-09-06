--[4] 게시판에 대한 글을 답변
CREATE PROCEDURE [dbo].[DNN_ReplyNote]
	@Name		Nvarchar(25),
	@Email		Nvarchar(100),
	@Title		Nvarchar(150),
	@PostIp		Nvarchar(15),
	@Content	NText,
	@Password	Nvarchar(20),
	@Encoding	Nvarchar(10),
	@Homepage	Nvarchar(100),
	@ParentNum	Int,
	@FileName	Nvarchar(255),
	@FileSize	Int
AS
	--[0] 변수 선언
	Declare @MaxRefOrder Int
	Declare @MaxRefAnswerNum Int
	Declare @ParentRef Int
	Declare @ParentStep Int
	Declare @ParentRefOrder Int

	--[1] 부모글의 답변수를 1증가
	Update Notes Set AnswerNum = AnswerNum + 1 where Id = @ParentNum

	--[2] 같은 글에 대해서 답변을 두번이상하면 먼저 답변하게 위에 나타난다.
	Select @MaxRefOrder = RefOrder, @MaxRefAnswerNum = AnswerNum From Notes
	where 
		ParentNum = @ParentNum And
		RefOrder = 
			(select Max (RefOrder) From Notes where ParentNum = @ParentNum)
	If  @MaxRefOrder Is Null
	Begin 
		Select @MaxRefOrder = RefOrder From Notes Where Id = @ParentNum
		Set @MaxRefAnswerNum = 0
	End

	--[3] 중간에 답변달 때 
	select 
		@ParentRef = Ref, @ParentStep = Step
		From Notes where Id = @ParentNum

	Update Notes
	Set
		RefOrder = RefOrder +1
	where 
		Ref = @ParentRef And RefOrder > (@MaxRefOrder + @MaxRefAnswerNum)

	--[4] 최종 저장
	Insert Notes
	(
		Name, Email, Title, PostIp, Content, Password, Encoding, 
		Homepage, Ref, Step, RefOrder, ParentNum, FileName, FileSize
	)
	values
	(
		@Name, @Email, @Title, @PostIp, @Content, @Password, @Encoding,
		@Homepage, @ParentRef, @ParentStep + 1, 
		@MaxRefOrder + @MaxRefAnswerNum +1 , @ParentNum, @FileName, @FileSize
	)
GO
	